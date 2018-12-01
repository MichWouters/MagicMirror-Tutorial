using Acme.Generic.Helpers;
using AutoMapper;
using MagicMirror.Business.Models;
using MagicMirror.ConsoleApp.Models;

namespace MagicMirror.ConsoleApp.Converters
{
    public class WeatherModelConverter : ITypeConverter<WeatherModel, MainViewModel>
    {
        public MainViewModel Convert(WeatherModel source, MainViewModel destination, ResolutionContext context)
        {
            destination.Sunrise = source.Sunrise;
            destination.Sunset = source.Sunset;
            destination.Temperature = source.Temperature;
            destination.TemperatureUom = source.TemperatureUom.ToString();
            destination.WeatherType = source.WeatherType;
            destination.TimeOfDay = DateTimeHelper.GetTimeOfDay();

            return destination;
        }
    }
}
