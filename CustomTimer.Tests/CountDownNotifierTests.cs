using System;
using CustomTimer.Factories;
using NUnit.Framework;

#pragma warning disable CA1707

namespace CustomTimer.Tests
{
    public class CountDownNotifierTests
    {
        private CountDownNotifierFactory countDownNotifierFactory;
        private TimerFactory timerFactory;

        [SetUp]
        public void Setup()
        {
            this.countDownNotifierFactory = new CountDownNotifierFactory();
            this.timerFactory = new TimerFactory();
        }

        [TestCase("pie", 10)]
        [TestCase("cookies", 5)]
        [TestCase("pizza", 1)]
        public void Run_ValidTimer_AllEventsWorkAsExpected(string name, int totalTicks)
        {
            var timer = this.timerFactory.CreateTimer(name, totalTicks);
            var notifier = this.countDownNotifierFactory.CreateNotifierForTimer(timer);

            void TimerStarted(object sender, TimerEventArgs eventArgs)
            {
                Assert.AreEqual(name, eventArgs.TimerName);
                Assert.AreEqual(totalTicks, eventArgs.RemainsTicks);
                Console.WriteLine($"Start timer '{eventArgs.TimerName}', total {eventArgs.RemainsTicks} ticks");
            }

            void TimerStopped(object sender, TimerEventArgs eventArgs)
            {
                Assert.AreEqual(name, eventArgs.TimerName);
                Console.WriteLine($"Stop timer '{eventArgs.TimerName}'");
            }

            var remainsTicks = totalTicks;

            void TimerTick(object sender, TimerEventArgs eventArgs)
            {
                remainsTicks -= 1;
                Assert.AreEqual(name, eventArgs.TimerName);
                Assert.AreEqual(remainsTicks, eventArgs.RemainsTicks);
                Console.WriteLine($"Timer '{eventArgs.TimerName}', remains {eventArgs.RemainsTicks} ticks");
            }

            notifier.Init(TimerStarted, TimerStopped, TimerTick);
            notifier.Run();

            Assert.AreEqual(0, remainsTicks);
        }

        [TestCase("pie", 10)]
        [TestCase("cookies", 5)]
        [TestCase("pizza", 1)]
        public void Run_NullDelegates_TimerIsWorking(string name, int totalTicks)
        {
            var timer = this.timerFactory.CreateTimer(name, totalTicks);
            var notifier = this.countDownNotifierFactory.CreateNotifierForTimer(timer);

            Assert.DoesNotThrow(() =>
            {
                notifier.Init(null, null, null);
                notifier.Run();
            });
        }

        [Test]
        public void Ctor_TimerIsNull_ThrowsArgumentNullException()
            => Assert.Throws<ArgumentNullException>(() => this.countDownNotifierFactory.CreateNotifierForTimer(null));
    }
}
