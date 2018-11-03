using Acme.Generic.Extensions;
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
            Sunrise = Sunrise.ConvertUnixTime();
            Sunset = Sunset.ConvertUnixTime();
            Temperature = ConvertTemperature(TemperatureUom.Celsius);
        }

        public double ConvertTemperature(TemperatureUom targetUom)
        {
            double result = 0;

            switch (TemperatureUom)
            {
                case TemperatureUom.Kelvin:
                    if (targetUom == TemperatureUom.Celsius)
                        result = TemperatureHelper.KelvinToCelsius(Temperature);
                    else if (targetUom == TemperatureUom.Fahrenheit)
                        result = TemperatureHelper.KelvinToFahrenheit(Temperature);
                    else
                        result = Temperature;
                    break;

                case TemperatureUom.Fahrenheit:
                    if (targetUom == TemperatureUom.Celsius)
                        result = TemperatureHelper.FahrenheitToCelsius(Temperature);
                    else if (targetUom == TemperatureUom.Kelvin)
                        result = TemperatureHelper.FahrenheitToKelvin(Temperature);
                    else
                        result = Temperature;
                    break;

                case TemperatureUom.Celsius:
                    if (targetUom == TemperatureUom.Kelvin)
                        result = TemperatureHelper.CelsiusToKelvin(Temperature);
                    else if (targetUom == TemperatureUom.Fahrenheit)
                        result = TemperatureHelper.CelsiusToFahrenheit(Temperature);
                    else
                        result = Temperature;
                    break;

                default:
                    break;
            }

            this.TemperatureUom = targetUom;
            return result;
        }
    }
}