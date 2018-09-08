using System;
using Acme.Generic.Helpers;
using MagicMirror.Business.Enums;

namespace MagicMirror.Business.Models
{
    public class WeatherModel : Model
    {
        public string Location { get; set; }

        public string Icon { get; set; }

        public double Temperature { get; set; }

        public string WeatherType { get; set; }

        public string Sunrise { get; set; }

        public string Sunset { get; set; }

        public TemperatureUom TemperatureUom { get; set; }

        public override void ConvertValues()
        {
            ConvertUnixTimes();
            ConvertTemperature();
        }

        private void ConvertUnixTimes()
        {
            if (int.TryParse(Sunrise, out int sunrise))
            {
                Sunrise = DateTimeHelper.ConvertUnixTimeToGMTDateTime(sunrise)
                    .ToShortTimeString();
            }

            if (int.TryParse(Sunset, out int sunset))
            {
                Sunset = DateTimeHelper.ConvertUnixTimeToGMTDateTime(sunset)
                    .ToShortTimeString();
            }
        }

        private void ConvertTemperature(double degreesToConvert, TemperatureUom targetTemperatureUom)
        {
            double result = 0;

            switch (TemperatureUom)
            {
                case TemperatureUom.Kelvin:
                    if (targetTemperatureUom == TemperatureUom.Kelvin)
                        result = degreesToConvert;
                    else if (targetTemperatureUom == TemperatureUom.Fahrenheit)
                        result = TemperatureHelper.KelvinToFahrenheit(degreesToConvert);
                    else if (targetTemperatureUom == TemperatureUom.Celsius)
                        result = TemperatureHelper.KelvinToCelsius(degreesToConvert);
                    break;
                case TemperatureUom.Fahrenheit:
                    if (targetTemperatureUom == TemperatureUom.Kelvin)
                        result = TemperatureHelper.FahrenheitToKelvin(degreesToConvert);
                    else if (targetTemperatureUom == TemperatureUom.Fahrenheit)
                        result = degreesToConvert;
                    else if (targetTemperatureUom == TemperatureUom.Celsius)
                        result = TemperatureHelper.FahrenheitToCelsius(degreesToConvert);
                    break;
                case TemperatureUom.Celsius:
                    if (targetTemperatureUom == TemperatureUom.Kelvin)
                        result = TemperatureHelper.CelsiusToKelvin(degreesToConvert);
                    else if (targetTemperatureUom == TemperatureUom.Fahrenheit)
                        result = TemperatureHelper.CelsiusToFahrenheit(degreesToConvert);
                    else if (targetTemperatureUom == TemperatureUom.Celsius)
                        result = degreesToConvert;
                    break;
                default:
                    break;
            }
        }
    }
}