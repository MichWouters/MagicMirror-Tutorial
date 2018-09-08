using System;
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
            throw new NotImplementedException();
        }

        private void ConvertTemperature()
        {
            throw new NotImplementedException();
        }
    }
}