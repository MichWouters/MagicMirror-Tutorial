using Acme.Generic.Helpers;
using System;
using Xunit;

namespace Acme.Generic.Tests
{
    public class UnixTimeTests
    {
        private int sunrise = 1534400420; //16 August 2018 06:20:20
        private int sunset = 1534454400; // 16 August 2018 21:20:00

        [Fact]
        public void Convert_From_Unix()
        {
            // Arrange
            DateTime expectedSunrise = new DateTime(2018, 8, 16, 6, 20, 20);
            DateTime expectedSunset = new DateTime(2018, 8, 16, 21, 20, 00);

            // Act
            DateTime convertedSunrise = UnixTimeHelper.ConvertFromUnixTimeStamp(sunrise);
            DateTime convertedSunset = UnixTimeHelper.ConvertFromUnixTimeStamp(sunset);

            // Assert
            Assert.Equal(expectedSunrise, convertedSunrise);
            Assert.Equal(expectedSunset, convertedSunset);
        }

        [Fact]
        public void Convert_To_Unix()
        {
            // Arrange
            DateTime sunriseDate = new DateTime(2018, 8, 16, 6, 20, 20);
            DateTime sunsetDate = new DateTime(2018, 8, 16, 21, 20, 00);

            // Act
            int convertedSunrise = UnixTimeHelper.ConvertToUnixTimeStamp(sunriseDate);
            int convertedSunset = UnixTimeHelper.ConvertToUnixTimeStamp(sunsetDate);

            // Assert
            Assert.Equal(sunrise, convertedSunrise);
            Assert.Equal(sunset, convertedSunset);
        }
    }
}