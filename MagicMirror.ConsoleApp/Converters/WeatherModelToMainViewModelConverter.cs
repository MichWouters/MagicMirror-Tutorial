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
            destination.TemperatureUom = source.TemperatureUom.ToString();

            return destination;
        }
    }
}