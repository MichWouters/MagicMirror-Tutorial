using Acme.Generic.Helpers;
using System;
using Xunit;

namespace Acme.Generic.Tests
{
    public class DateTimeTests
    {
        private int unixSunrise = 1535189400; // 25 August 2018 09:30:00
        private int unixSunset = 1535232600; // 25 August 2018 21:30:00

        private DateTime sunriseDateTime = new DateTime(2018, 8, 25, 9, 30, 0);
        private DateTime sunsetDateTime = new DateTime(2018, 8, 25, 21, 30, 0);

        [Fact]
        public void Convert_From_Unix()
        {
            // Act
            DateTime convertedSunrise = DateTimeHelper.ConvertUnixTimeToGMTDateTime(unixSunrise);
            DateTime convertedSunset = DateTimeHelper.ConvertUnixTimeToGMTDateTime(unixSunset);

            // Assert
            Assert.Equal(sunriseDateTime, convertedSunrise);
            Assert.Equal(sunsetDateTime, convertedSunset);
        }

        [Fact]
        public void Convert_To_Unix()
        {
            // Act
            int convertedSunrise = DateTimeHelper.ConvertGMTDateTimeToDateUnixTime(sunriseDateTime);
            int convertedSunset = DateTimeHelper.ConvertGMTDateTimeToDateUnixTime(sunsetDateTime);

            // Assert
            Assert.Equal(unixSunrise, convertedSunrise);
            Assert.Equal(unixSunset, convertedSunset);
        }

        [Fact]
        public void TimeOfDay_Returns_CorrectValue()
        {
            var morning = new DateTime(2019, 6, 1, 9, 0, 0);
            string result = DateTimeHelper.GetTimeOfDay(morning);
            Assert.Equal("morning", result);

            var day = new DateTime(2019, 6, 1, 12, 0, 0);
            result = DateTimeHelper.GetTimeOfDay(day);
            Assert.Equal("day", result);

            var afternoon = new DateTime(2019, 6, 1, 14, 0, 0);
            result = DateTimeHelper.GetTimeOfDay(afternoon);
            Assert.Equal("afternoon", result);

            var evening = new DateTime(2019, 6, 1, 21, 0, 0);
            result = DateTimeHelper.GetTimeOfDay(evening);
            Assert.Equal("evening", result);

            var night = new DateTime(2019, 6, 1, 23, 0, 0);
            result = DateTimeHelper.GetTimeOfDay(night);
            Assert.Equal("night", result);
        }
    }
}