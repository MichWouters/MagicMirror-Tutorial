﻿using System.ComponentModel.Design;
using Acme.Generic.Helpers;
using AutoMapper;
using MagicMirror.Business.Models;
using MagicMirror.DataAccess.Entities.Entities;
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
                .ForMember(x => x.Sunrise, y => y.MapFrom(z => DateTimeHelper.ConvertUnixTimeToGMTDateTime(z.Sys.Sunrise)))
                .ForMember(x => x.Sunset, y => y.MapFrom(z => DateTimeHelper.ConvertUnixTimeToGMTDateTime(z.Sys.Sunset)))
                .ForMember(x => x.WeatherType, y => y.MapFrom(z => z.Weather[0].Main))
                .ForMember(x => x.Icon, y => y.MapFrom(z => z.Weather[0].Icon));

            CreateMap<GoogleMapsTrafficEntity, TrafficModel>()
                .ForMember(x => x.Destination, y => y.MapFrom(z => z.Destination_addresses[0]))
                .ForMember(x => x.Origin, y => y.MapFrom(z => z.Origin_addresses[0]))
                .ForMember(x => x.Distance, y => y.MapFrom(z => z.Rows[0].Elements[0].Distance.Value))
                .ForMember(x => x.DistanceUom, y => y.MapFrom(z => Enums.DistanceUom.Metric))
                .ForMember(x => x.Duration, y => y.MapFrom(z => z.Rows[0].Elements[0].Duration.Value));


            CreateMap<OpenMapTraffic, TrafficModel>()
                .ForMember(x => x.Distance, y => y.MapFrom(z => z.Route.Distance))
                .ForMember(x => x.DistanceUom, y => y.MapFrom(z => Enums.DistanceUom.Imperial))
                .ForMember(x => x., y => y.MapFrom(z => Enums.DistanceUom.Imperial))
                .ForMember(x => x.Duration, y => y.MapFrom(z => z.Route.Time));
        }   
    }
}