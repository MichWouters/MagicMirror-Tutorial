using Acme.Generic.Helpers;
using AutoMapper;
using MagicMirror.Business.Models;
using MagicMirror.ConsoleApp.Models;

namespace MagicMirror.ConsoleApp.Converters
{
    public class TrafficModelConverter: ITypeConverter<TrafficModel, MainViewModel>
    {
        public MainViewModel Convert(TrafficModel source, MainViewModel dest, ResolutionContext context)
        {
            dest.TravelTime = DateTimeHelper.GetHoursAndMinutes(source.Duration);
            dest.TimeOfArrival = source.TimeOfArrival.ToShortTimeString();

            return dest;
        }
    }
}
