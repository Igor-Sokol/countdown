using System;
using CustomTimer.Interfaces;

namespace CustomTimer.Implementation
{
    /// <inheritdoc/>
    public class CountDownNotifier : ICountDownNotifier
    {
        private readonly Timer timer;
        private Action<string, int> startHandler = (arg1, arg2) => { };
        private Action<string> stopHandler = (arg1) => { };
        private Action<string, int> tickHandler = (arg1, arg2) => { };

        public CountDownNotifier(Timer timer)
        {
            this.timer = timer;
        }

        /// <inheritdoc/>
        public void Init(Action<string, int> startHandler, Action<string> stopHandler, Action<string, int> tickHandler)
        {
            this.startHandler += startHandler;
            this.stopHandler += stopHandler;
            this.tickHandler += tickHandler;
        }

        /// <inheritdoc/>
        public void Run()
        {
            this.timer.StartHandler += this.startHandler;
            this.timer.StopHandler += this.stopHandler;
            this.timer.TickHandler += this.tickHandler;
            this.timer.Start();
        }
    }
}
