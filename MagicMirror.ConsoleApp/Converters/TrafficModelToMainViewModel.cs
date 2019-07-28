using Acme.Generic.Helpers;
using AutoMapper;
using MagicMirror.Business.Enums;
using MagicMirror.Business.Models;
using MagicMirror.ConsoleApp.Models;

namespace MagicMirror.ConsoleApp.Converters
{
    public class TrafficModelToMainViewModelConverter : ITypeConverter<TrafficModel, MainViewModel>
    {
        public MainViewModel Convert(TrafficModel source, MainViewModel destination, ResolutionContext context)
        {
            // Converter classes cannot automap properties...
            destination.Distance = source.Distance;

            // But they do allow calculations to be performed at map-time.
            destination.DistanceUom = GetDistanceUomToString(source.DistanceUom);
            destination.TimeOfArrival = source.TimeOfArrival.ToLocalTime().ToString("HH:mm");
            destination.TravelTime = DateTimeHelper.SecondsToHoursAndMinutes(source.Duration);

            if (source.DistanceUom == DistanceUom.Metric)
            {
                destination.Distance = DistanceHelper.MetersToKilometers(source.Distance);
            }

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
    }
}