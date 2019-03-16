using System;

namespace Acme.Generic.Helpers
{
    public static class DistanceHelper
    {
        public static double MilesToKilometers(double valueToConvert, int precision = 2)
        {
            double converted = valueToConvert * 1.60934;
            converted = Math.Round(converted, precision);

            return converted;
        }

        public static double KilometersToMiles(double valueToConvert, int precision = 2)
        {
            double converted = valueToConvert * 0.62137;
            converted = Math.Round(converted, precision);

            return converted;
        }

        public static double MetersToKilometers(double valueToConvert, int precision = 2)
        {
            double converted = valueToConvert / 1000;
            converted = Math.Round(converted, precision);

            return converted;
        }
    }
}