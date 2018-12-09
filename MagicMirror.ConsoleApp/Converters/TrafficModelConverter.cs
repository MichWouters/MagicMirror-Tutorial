using Acme.Generic.Helpers;
using AutoMapper;
using MagicMirror.Business.Models;
using MagicMirror.ConsoleApp.Models;

namespace MagicMirror.ConsoleApp.Converters
{
    public class TrafficModelConverter : ITypeConverter<TrafficModel, MainViewModel>
    {
        public MainViewModel Convert(TrafficModel source, MainViewModel destination, ResolutionContext context)
        {
            destination.TimeOfArrival = source.TimeOfArrival.ToShortTimeString();
            destination.TravelTime = DateTimeHelper.GetHoursAndMinutes(source.Duration);

            return destination;
        }
    }
}
