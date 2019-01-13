using AutoMapper;
using MagicMirror.Business.Models;
using MagicMirror.ConsoleApp.Converters;
using MagicMirror.ConsoleApp.Models;

namespace MagicMirror.ConsoleApp.Configuration
{
    public class AutoMapperPresentationProfile: Profile
    {
        public AutoMapperPresentationProfile()
        {
            CreateMap<WeatherModel, MainViewModel>()
                .ForMember(x => x.TemperatureUom, y => y.MapFrom(z => z.TemperatureUom.ToString()));

            CreateMap<TrafficModel, MainViewModel>()
                .ConvertUsing<TrafficModelToMainViewModel>();
        }
    }
}
