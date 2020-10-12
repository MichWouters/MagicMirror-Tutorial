using AutoMapper;
using MagicMirror.Business.Models;
using MagicMirror.UniversalApp.Converters;
using MagicMirror.UniversalApp.ViewModels;

namespace MagicMirror.UniversalApp.Configuration
{
    public class AutoMapperPresentationProfile : Profile
    {
        public AutoMapperPresentationProfile()
        {
            CreateMap<WeatherModel, MainViewModel>()
                .ForMember(x => x.TemperatureUom, y => y.MapFrom(z => z.TemperatureUom.ToString()))
                .ForMember(x => x.Sunrise, y => y.MapFrom(z => z.Sunrise.ToLocalTime().ToString("HH:mm")))
                .ForMember(x => x.Sunset, y => y.MapFrom(z => z.Sunset.ToLocalTime().ToString("HH:mm")));

            CreateMap<TrafficModel, MainViewModel>()
                .ConvertUsing<TrafficModelToMainViewModelConverter>();
        }
    }
}