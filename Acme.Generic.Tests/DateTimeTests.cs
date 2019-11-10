using Acme.Generic.Enums;
using Acme.Generic.Helpers;
using System;
using Xunit;

namespace Acme.Generic.Tests
{
    public class DateTimeTests
    {
        [Fact]
        public void CalculateTimeOfArrival()
        {
            // Arrange
            int duration = 4;
            DateTime someDate = new DateTime(2020, 1, 1, 12, 0, 0);

            // Act
            DateTime seconds = DateTimeHelper.CalculateTime(someDate, duration, TimeInterval.Seconds);
            DateTime minutes = DateTimeHelper.CalculateTime(someDate, duration, TimeInterval.Minutes);
            DateTime hours = DateTimeHelper.CalculateTime(someDate, duration, TimeInterval.Hours);

            // Assert
            Assert.Equal(seconds, new DateTime(2020, 1, 1, 12, 0, 4));
            Assert.Equal(minutes, new DateTime(2020, 1, 1, 12, 4, 0));
            Assert.Equal(hours, new DateTime(2020, 1, 1, 16, 0, 0));

        }
    }
}
