using System;
using AutoMapper;
using MagicMirror.Business.Enums;
using MagicMirror.Business.Models;
using MagicMirror.ConsoleApp.Models;

namespace MagicMirror.ConsoleApp.Converters
{
    public class TrafficModelToMainViewModel : ITypeConverter<TrafficModel, MainViewModel>
    {
        public MainViewModel Convert(TrafficModel source, MainViewModel destination, ResolutionContext context)
        {
            destination.TimeOfArrival = source.TimeOfArrival.ToLocalTime().ToShortTimeString();
            destination.TravelTime = GetHoursAndMinutes(source.Duration);

            return destination;
        }

      
    }
}