using Acme.Generic.Helpers;
using Xunit;

namespace Acme.Generic.Tests
{
    public class TemperatureTests
    {
        [Fact]
        public void Kelvin_To_Celsius()
        {
            double toConvert = 293.15;
            double convertedValue = TemperatureHelper.KelvinToCelsius(toConvert);
            Assert.Equal(20, convertedValue);
        }

        [Fact]
        public void Kelvin_To_Fahrenheit()
        {
            double toConvert = 293.15;
            double convertedValue = TemperatureHelper.KelvinToFahrenheit(toConvert);
            Assert.Equal(68, convertedValue);
        }

        [Fact]
        public void Celsius_To_Kelvin()
        {
            double toConvert = 20;
            double convertedValue = TemperatureHelper.CelsiusToKelvin(toConvert);
            Assert.Equal(293.15, convertedValue);
        }

        [Fact]
        public void Celsius_To_Fahrenheit()
        {
            double toConvert = 20;
            double convertedValue = TemperatureHelper.CelsiusToFahrenheit(toConvert);
            Assert.Equal(68, convertedValue);
        }

        [Fact]
        public void Fahrenheit_To_Kelvin()
        {
            double toConvert = 79.25;
            double convertedValue = TemperatureHelper.FahrenheitToKelvin(toConvert);
            Assert.Equal(299.4, convertedValue);
        }

        [Fact]
        public void Fahrenheit_To_Celsius()
        {
            double toConvert = 79.25;
            double convertedValue = TemperatureHelper.FahrenheitToCelsius(toConvert);
            Assert.Equal(26.25, convertedValue);
        }
    }
}