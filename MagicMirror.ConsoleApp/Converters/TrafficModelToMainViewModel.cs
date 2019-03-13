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
            // Converter classes cannot automap properties...
            destination.Distance = source.Distance;

            // But they do allow calculations to be performed at map-time.
            destination.DistanceUom = GetDistanceUomToString(source.DistanceUom);
            destination.TimeOfArrival = source.TimeOfArrival.ToLocalTime().ToShortTimeString();
            destination.TravelTime = GetHoursAndMinutes(source.Duration);

            return destination;
        }

        private string GetDistanceUomToString(DistanceUom distanceUom)
        {
            if (distanceUom == DistanceUom.Imperial)
            {
                return "miles";
            }
            else
            {
                return "kilometers";
            }
        }

        private string GetHoursAndMinutes(int seconds)
        {
            int minutes = seconds / 60;
            int hours = minutes / 60;
            int remainingMinutes = minutes % 60;

            if (hours > 0)
            {
                return $"{hours} hours and {remainingMinutes} minutes";
            }
            else
            {
                return $"{remainingMinutes} minutes";
            }
        }
    }
}