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

        private void ConvertTemperature()
        {
            throw new NotImplementedException();
        }
    }
}