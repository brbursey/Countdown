using System;

namespace Countdown
{
    public class Countdown 
    {
        private DateTime Deadline { get; }
        private DateTime CurrentTime { get; }
        
        public Countdown(DateTime deadline, DateTime currentTime)
        {
            Deadline = deadline;
            CurrentTime = currentTime;
        }

        public TimeSpan GetTimeInDays()
        {
            return Deadline - CurrentTime;
        }

        public AnnualTime GetCountdownTimer()
        {
            var timeBetween = Deadline - CurrentTime;
            return timeBetween.TimeLeft(CurrentTime);
        }
    }
}