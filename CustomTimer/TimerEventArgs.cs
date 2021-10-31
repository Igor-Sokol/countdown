using System;
using System.Collections.Generic;
using System.Text;

namespace CustomTimer
{
    public class TimerEventArgs : EventArgs
    {
        public TimerEventArgs(string timerName, int remainsTicks)
        {
            this.TimerName = timerName;
            this.RemainsTicks = remainsTicks;
        }

        public string TimerName { get; set; }

        public int RemainsTicks { get; set; }
    }
}
