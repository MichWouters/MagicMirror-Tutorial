using AutoMapper;
using MagicMirror.Business.Models;
using MagicMirror.ConsoleApp.Converters;
using MagicMirror.ConsoleApp.Models;

namespace MagicMirror.ConsoleApp.Configuration
{
    public static class MappingConfigs 
    {
        public static void RegisterMaps()
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<WeatherModel, MainViewModel>()
                    .ConvertUsing<WeatherModelConverter>();

                config.CreateMap<TrafficModel, MainViewModel>()
                    .ConvertUsing<TrafficModelConverter>();
            });
        }
    }
}