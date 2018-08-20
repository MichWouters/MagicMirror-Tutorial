using System;

namespace Acme.Generic.Helpers
{
    public static class TemperatureHelper
    {
        public static double KelvinToCelsius(double valueToConvert, int precision = 2)
        {
            double converted = valueToConvert - 273.15;
            return Math.Round(converted, precision);
        }

        public static double CelsiusToKelvin(double valueToConvert, int precision = 2)
        {
            double converted = valueToConvert + 273.15;
            return Math.Round(converted, precision);
        }

        public static double KelvinToFahrenheit(double valueToConvert, int precision = 2)
        {
            double converted = 1.8 * (valueToConvert - 273.15) + 32;
            return Math.Round(converted, precision);
        }

        public static double CelsiusToFahrenheit(double valueToConvert, int precision = 2)
        {
            double converted = (valueToConvert * 1.8) + 32;
            return Math.Round(converted, precision);
        }

        public static double FahrenheitToKelvin(double valueToConvert, int precision = 2)
        {
            double converted = (5f / 9f) * (valueToConvert - 32) + 273.15;
            return Math.Round(converted, precision);
        }

        public static double FahrenheitToCelsius(double valueToConvert, int precision = 2)
        {
            double converted = (valueToConvert - 32) / 1.8;
            return Math.Round(converted, precision);
        }
    }
}