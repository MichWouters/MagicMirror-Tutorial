using AutoMapper;
using MagicMirror.Business.Models;
using MagicMirror.UniversalApp.Converters;
using MagicMirror.UniversalApp.Models;

namespace MagicMirror.UniversalApp.Configuration
{
    public class AutoMapperPresentationProfile : Profile
    {
        public AutoMapperPresentationProfile()
        {
            CreateMap<WeatherModel, OnlineDataModel>()
                .ForMember(x => x.TemperatureUom, y => y.MapFrom(z => z.TemperatureUom.ToString()))
                .ForMember(x => x.Sunrise, y => y.MapFrom(z => z.Sunrise.ToLocalTime().ToString("HH:mm")))
                .ForMember(x => x.Sunset, y => y.MapFrom(z => z.Sunset.ToLocalTime().ToString("HH:mm")))
                .ForMember(x => x.WeatherIcon, y => y.MapFrom(z => z.Icon));

            CreateMap<TrafficModel, OnlineDataModel>()
                .ConvertUsing<TrafficModelToMainViewModelConverter>();
        }
    }
}