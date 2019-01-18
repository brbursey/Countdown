using System;
using Countdown;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class CountdownTest
    {
        private DateTime currentDay;

        [Test]
        public void Countdown_ReturnTimeLeftBetweenDates()
        {
            currentDay = new DateTime(2019, 1, 16);
            var deadLine = new DateTime(2019, 1, 17);
            var countdown = new Countdown.Countdown(deadLine, currentDay);

            var expected = new TimeSpan(1, 0, 0, 0);
            var result = countdown.GetTimeInDays();

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void Countdown_ReturnsCountdownTimer()
        {
            currentDay = new DateTime(2019, 1, 1, 0, 0, 0, 0);
            var deadLine = new DateTime(2019, 1, 29, 18, 0, 0, 0);
            var countdown = new Countdown.Countdown(deadLine, currentDay);
            
            var expected = new AnnualTime(0, 0, 28, 18, 0, 0, 0).ToString();
            var result = countdown.GetCountdownTimer().ToString();
            
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}