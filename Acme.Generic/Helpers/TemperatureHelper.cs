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
    }
}
