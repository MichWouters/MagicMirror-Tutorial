using Acme.Generic.Helpers;
using Xunit;

namespace Acme.Generic.Tests
{
    public class TemperatureTests
    {
        [Fact]
        public void Can_Convert_Kelvin_To_Celsius()
        {
            // Arrange
            double toConvert = 293.15;

            // Act
            double convertedValue = TemperatureHelper.KelvinToCelsius(toConvert);

            // Assert
            Assert.Equal(20, convertedValue);
        }

        [Fact]
        public void Can_Convert_Celsius_To_Kelvin()
        {
            // Arrange
            double toConvert = 20;

            // Act
            double convertedValue = TemperatureHelper.CelsiusToKelvin(toConvert);

            // Assert
            Assert.Equal(293.15, convertedValue);
        }
    }
}
