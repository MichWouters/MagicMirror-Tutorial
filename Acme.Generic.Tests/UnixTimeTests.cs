using Acme.Generic.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Acme.Generic.Tests
{
    public class UnixTimeTests
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
    }
}
