using System;
using Countdown;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class TimeSpanExtensionsTest
    {
        [Test]
        public void TimeSpan_ReturnTimeLeftBetweenDates_WhenOverAMonth()
        {
            var startDate = new DateTime(2019, 1, 16, 0, 0, 0, 0);
            var endDate = new DateTime(2019, 3, 16, 0, 0, 0, 0);

            var expected = new AnnualTime(0, 2, 0, 0, 0, 0, 0).ToString();
            var daysLeft = endDate - startDate;
            var result = daysLeft.TimeLeft(startDate).ToString();
            
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void TimeSpan_ReturnTimeLeftBetweenDates_WhenOverAYear()
        {
            var startDate = new DateTime(2018, 1, 1, 0, 0, 0, 0);
            var endDate = new DateTime(2019, 5, 1, 0, 0, 0, 0);
            
            var expected = new AnnualTime(1, 4, 0, 0, 0, 0, 0).ToString();
            var daysLeft = endDate - startDate;
            var result = daysLeft.TimeLeft(startDate).ToString();
            
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void TimeSpan_ReturnTimeLeftBetweenDates_WhenTimeIsHoursApart()
        {
            var startDate = new DateTime(2018, 1, 1, 0, 0, 0, 0);
            var endDate = new DateTime(2018, 1, 1, 7, 0, 0, 0);
            
            var expected = new AnnualTime(0, 0, 0, 7, 0, 0, 0).ToString();
            var daysLeft = endDate - startDate;
            var result = daysLeft.TimeLeft(startDate).ToString();

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void TimeSpan_ReturnsTimeLeftBetweenDates_WhenAllUnitsAreDifferent()
        {
            var startDate = new DateTime(2018, 1, 30, 0, 57, 26, 12);
            var endDate = new DateTime(2019, 4, 27, 7, 8, 59, 48);
            
            var expected = new AnnualTime(1, 2, 28, 6, 11, 33, 36).ToString();
            var daysLeft = endDate - startDate;
            var result = daysLeft.TimeLeft(startDate).ToString();

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}