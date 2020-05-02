using AutoMapper;
using MagicMirror.Business.Models;
using MagicMirror.ConsoleApp.Converters;
using MagicMirror.ConsoleApp.Models;

namespace MagicMirror.ConsoleApp.Configuration
{
    public class AutoMapperPresentationProfile : Profile
    {
        public AutoMapperPresentationProfile()
        {
            CreateMap<WeatherModel, MainViewModel>()
                .ForMember(x => x.TemperatureUom, y => y.MapFrom(z => z.TemperatureUom.ToString()))
                .ForMember(x => x.Sunrise, y => y.MapFrom(z => z.Sunrise.ToLocalTime().ToString("HH:mm")))
                .ForMember(x => x.Sunset, y => y.MapFrom(z => z.Sunset.ToLocalTime().ToString("HH:mm")));

            CreateMap<GoogleMapsTrafficModel, MainViewModel>()
                .ConvertUsing<TrafficModelToMainViewModelConverter>();
        }
    }
}