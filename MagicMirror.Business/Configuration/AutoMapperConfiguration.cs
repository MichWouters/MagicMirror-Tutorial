using System;
using System.Collections.Generic;
using System.Text;
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
                .ForMember(x => x.Temperature, y => y.MapFrom(z => z.Main.Temp))
                .ForMember(x => x.Location, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.Sunrise, y => y.MapFrom(z => z.Sys.Sunrise))
                .ForMember(x => x.Sunset, y => y.MapFrom(z => z.Sys.Sunset))
                .ForMember(x => x.WeatherType, y => y.MapFrom(z => z.Weather[0].Main));
        }
    }
}
