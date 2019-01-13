using AutoMapper;
using MagicMirror.Business.Models;
using MagicMirror.DataAccess.Entities.Traffic;
using MagicMirror.DataAccess.Entities.Weather;

namespace MagicMirror.Business.Configuration
{
    public class AutoMapperBusinessProfile : Profile
    {
        public AutoMapperBusinessProfile()
        {
            CreateMap<WeatherEntity, WeatherModel>()
                .ForMember(x => x.Location, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.Temperature, y => y.MapFrom(z => z.Main.Temp))
                .ForMember(x => x.Sunrise, y => y.MapFrom(z => z.Sys.Sunrise))
                .ForMember(x => x.Sunset, y => y.MapFrom(z => z.Sys.Sunset))
                .ForMember(x => x.WeatherType, y => y.MapFrom(z => z.Weather[0].Main))
                .ForMember(x => x.Icon, y => y.MapFrom(z => z.Weather[0].Icon));

            CreateMap<TrafficEntity, TrafficModel>()
                .ForMember(x => x.Destination, y => y.MapFrom(z => z.Destination_addresses[0]))
                .ForMember(x => x.Origin, y => y.MapFrom(z => z.Origin_addresses[0]))
                .ForMember(x => x.Distance, y => y.MapFrom(z => z.Rows[0].Elements[0].Distance.Value))
                .ForMember(x => x.Duration, y => y.MapFrom(z => z.Rows[0].Elements[0].Duration.Value));
        }
    }
}