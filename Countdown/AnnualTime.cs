using System;

namespace Countdown
{
    public class AnnualTime

    {
        private readonly int years;
        private readonly int months;
        private readonly int days;
        private readonly int hours;
        private readonly int minutes;
        private readonly int seconds;
        private readonly int milliseconds;   
        
        public AnnualTime(int years, int months, int days, int hours, int minutes, int seconds, int milliseconds)
        {
            this.years = years;
            this.months = months;
            this.days = days;
            this.hours = hours;
            this.minutes = minutes;
            this.seconds = seconds;
            this.milliseconds = milliseconds;
        }

        public override string ToString()
        {
            return $"{years} : {months} : {days} : {hours} : {minutes} : {seconds} : {milliseconds}";
        }
    }
}