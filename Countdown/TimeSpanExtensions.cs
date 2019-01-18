using System;
using System.Runtime.InteropServices;
using Microsoft.SqlServer.Server;

namespace Countdown
{
    public static class TimeSpanExtensions
    {
        private enum Months
        {
            January = 31,
            February = 28,
            March = 31,
            April = 30,
            May = 31,
            June = 30,
            July = 31,
            August = 31,
            September = 30,
            October = 31,
            November = 30,
            December = 31
        };

        public static AnnualTime TimeLeft(this TimeSpan timeLeft, DateTime startDate)
        {
            var daysLeft = timeLeft.Days;
            var currentMonth = startDate.Month;
           
            var years = GetYears(daysLeft);
            daysLeft = daysLeft - years * 365;
            
            var months = 0;
            var days = 0;
            
            while (daysLeft > 0)
            {
                var daysInMonth = DaysInCurrentMonth(currentMonth);
                if (daysLeft >= daysInMonth)
                {
                    months++;
                    daysLeft = daysLeft - daysInMonth;
                    currentMonth++;
                }
                else
                {
                    days = daysLeft;
                    daysLeft = 0;
                }
            }
            
            var totalTimeLeft = new AnnualTime(years, months, days, timeLeft.Hours, timeLeft.Minutes, timeLeft.Seconds, timeLeft.Milliseconds);
            return totalTimeLeft;
        }

        private static int GetYears(int daysLeft)
        {
            var years = daysLeft / 365;
            return years; 
        }

        private static int DaysInCurrentMonth(int currentMonth)
        {
            currentMonth = currentMonth % 12;
            var daysInMonth = 0;
            switch (currentMonth)
            {
                default:
                    break;
                case 1:
                    daysInMonth = (int) Months.January;
                    break;
                case 2:
                    daysInMonth = (int) Months.February;
                    break;
                case 3:
                    daysInMonth = (int) Months.March;
                    break;
                case 4:
                    daysInMonth = (int) Months.April;
                    break;
                case 5:
                    daysInMonth = (int) Months.May;
                    break;
                case 6:
                    daysInMonth = (int) Months.June;
                    break;
                case 7:
                    daysInMonth = (int) Months.July;
                    break;
                case 8:
                    daysInMonth = (int) Months.August;
                    break;
                case 9:
                    daysInMonth = (int) Months.September;
                    break;
                case 10:
                    daysInMonth = (int) Months.October;
                    break;
                case 11:
                    daysInMonth = (int) Months.November;
                    break;
                case 0:
                    daysInMonth = (int) Months.December;
                    break;
            }

            return daysInMonth;
        }
    }
}