using System;
using CustomTimer.Interfaces;

namespace CustomTimer.Implementation
{
    /// <inheritdoc/>
    public class CountDownNotifier : ICountDownNotifier
    {
        /// <inheritdoc/>
        public void Init(Action<string, int> startHandler, Action<string> stopHandler, Action<string, int> tickHandler)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public void Run()
        {
            throw new NotImplementedException();
        }
    }
}
