using System;
using System.Threading;

namespace CustomTimer
{
    /// <summary>
    /// A custom class for simulating a countdown clock, which implements the ability to send a messages and additional
    /// information about the Started, Tick and Stopped events to any types that are subscribing the specified events.
    /// 
    /// - When creating a CustomTimer object, it must be assigned:
    ///     - name (not null or empty string, otherwise ArgumentException will be thrown);
    ///     - the number of ticks (the number must be greater than 0 otherwise an exception will throw an ArgumentException).
    /// 
    /// - After the timer has been created, it should fire the Started event, the event should contain information about
    /// the name of the timer and the number of ticks to start.
    /// 
    /// - After starting the timer, it fires Tick events, which contain information about the name of the timer and
    /// the number of ticks left for triggering, there should be delays between Tick events, delays are modeled by Thread.Sleep.
    /// 
    /// - After all Tick events are triggered, the timer should start the Stopped event, the event should contain information about
    /// the name of the timer.
    /// </summary>
    public class Timer
    {
        private readonly string timerName;
        private readonly int ticks;

        public Timer(string timerName, int ticks)
        {
            this.timerName = timerName;
            this.ticks = ticks;
        }

        public event Action<string, int> StartHandler;

        public event Action<string> StopHandler;

        public event Action<string, int> TickHandler;

        public void Start()
        {
            this.OnTimerStart();

            for (int i = this.ticks; i > 0;)
            {
                Thread.Sleep(10);
                i--;
                this.OnTimerTick(i);
            }

            this.OnTimerStop();
        }

        private void OnTimerStart()
        {
            this.StartHandler?.Invoke(this.timerName, this.ticks);
        }

        private void OnTimerTick(int ticks)
        {
            this.TickHandler?.Invoke(this.timerName, ticks);
        }

        private void OnTimerStop()
        {
            this.StopHandler?.Invoke(this.timerName);
        }
    }
}
