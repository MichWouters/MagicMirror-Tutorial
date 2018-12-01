using AutoMapper;
using MagicMirror.Business.Models;
using MagicMirror.ConsoleApp.Converters;
using MagicMirror.ConsoleApp.Models;

namespace MagicMirror.Business.Configuration
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
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