using AutoMapper;
using MagicMirror.Business.Models;
using MagicMirror.ConsoleApp.Converters;
using MagicMirror.ConsoleApp.Models;

namespace MagicMirror.ConsoleApp.Configuration
{
    public static class AutoMapperConfiguration
    {
        public static void RegisterMaps()
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<WeatherModel, MainViewModel>()
                    .ForMember(dest => dest.TemperatureUom, x => x.MapFrom(src => src.TemperatureUom.ToString()));

                config.CreateMap<TrafficModel, MainViewModel>()
                     .ConvertUsing<TrafficModelConverter>();
            });
        }
    }
}
