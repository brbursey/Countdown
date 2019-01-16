using System;
using Countdown.Properties.util;
using NUnit.Framework;

namespace Countdown
{
    [TestFixture]
    public class CountdownTest
    {
        private DateTime currentDay;
        
        [SetUp]
        public void Setup()
        {
            currentDay = new DateTime(2019, 1, 16);
        }
        

        [Test]
        public void Countdown_ReturnTimeLeftBetweenDates()
        {
            
            var deadLine = new DateTime(2019, 1, 17);
            var countdown = new Countdown(deadLine, currentDay);
            
            var expected = new TimeSpan(1, 0, 0, 0);
            var result = countdown.TimeLeft();

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void Countdown_ReturnTimeLeftBetweenDates_WhenOverAMonth()
        {
            var deadLine = new DateTime(2019, 3, 16);
            var countdown = new Countdown(deadLine, currentDay);
            
            var daysBetween = new TimeSpan(59, 0, 0, 0);
            var expected = TimeSpanConverter.DaysToYears(daysBetween);
            var result = countdown.TimeLeft();
            
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}