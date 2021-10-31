using System;
using CustomTimer.Interfaces;

namespace CustomTimer.Implementation
{
    /// <inheritdoc/>
    public class CountDownNotifier : ICountDownNotifier
    {
        private readonly Timer timer;

        public CountDownNotifier(Timer timer)
        {
            this.timer = timer;
        }

        public event EventHandler<TimerEventArgs> StartHandler;

        public event EventHandler<TimerEventArgs> StopHandler;

        public event EventHandler<TimerEventArgs> TickHandler;

        /// <inheritdoc/>
        public void Init(EventHandler<TimerEventArgs> startHandler, EventHandler<TimerEventArgs> stopHandler, EventHandler<TimerEventArgs> tickHandler)
        {
            this.StartHandler += startHandler;
            this.StopHandler += stopHandler;
            this.TickHandler += tickHandler;

            this.timer.StartHandler += this.OnTimerStart;
            this.timer.TickHandler += this.OnTimerTick;
            this.timer.StopHandler += this.OnTimerStop;
        }

        /// <inheritdoc/>
        public void Run()
        {
            this.timer.Start();
        }

        private void OnTimerStart(object sender, TimerEventArgs eventArgs)
        {
            this.StartHandler?.Invoke(this, eventArgs);
        }

        private void OnTimerTick(object sender, TimerEventArgs eventArgs)
        {
            this.TickHandler?.Invoke(this, eventArgs);
        }

        private void OnTimerStop(object sender, TimerEventArgs eventArgs)
        {
            this.StopHandler?.Invoke(this, eventArgs);
        }
    }
}
