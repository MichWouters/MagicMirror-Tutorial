using AutoMapper;
using MagicMirror.Business.Models;
using MagicMirror.DataAccess.Entities.Weather;

namespace MagicMirror.Business.Configuration
{
    public class AutoMapperConfiguration: Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<WeatherEntity, WeatherModel>()
                .ForMember(x=> x.Location, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.Location, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.Sunrise, y => y.MapFrom(z => z.Sys.Sunrise))
                .ForMember(x => x.Sunset, y => y.MapFrom(z => z.Sys.Sunset))
                .ForMember(x => x.WeatherType, y => y.MapFrom(z => z.Weather[0].Main))
                .ForMember(x => x.Icon, y => y.MapFrom(z => z.Weather[0].Icon));
        }
    }
}
