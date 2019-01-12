using AutoMapper;
using MagicMirror.Business.Enums;
using MagicMirror.Business.Models;
using MagicMirror.ConsoleApp.Models;

namespace MagicMirror.ConsoleApp.Converters
{
    public class WeatherModelToMainViewModelConverter : ITypeConverter<WeatherModel, MainViewModel>
    {
        public MainViewModel Convert(WeatherModel source, MainViewModel destination, ResolutionContext context)
        {
            // When using ITypeConverter, all properties need to mapped by hand.
            destination.Sunrise = source.Sunrise;
            destination.Sunset = source.Sunset;

            // ITypeConverter allows for calculations to happen during mapping.
            destination.Temperature = source.ConvertTemperature(TemperatureUom.Celsius);
            destination.TemperatureUom = source.TemperatureUom.ToString();

            return destination;
        }
    }
}