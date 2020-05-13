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
            destination.Distance = ConvertDistance(source.Distance, source.DistanceUom);

            // But they do allow calculations to be performed at map-time.
            destination.DistanceUom = GetDistanceUomToString(source.DistanceUom);
            destination.TimeOfArrival = source.TimeOfArrival.ToLocalTime().ToShortTimeString();
            destination.TravelTime = DateTimeHelper.SecondsToHoursAndMinutes(source.Duration);

            
            
            return destination;
        }

        ///
        private double ConvertDistance(double distance, DistanceUom distanceUom)
        {
            double convertedDistance = distance;

            if (distanceUom == DistanceUom.Metric && UserInformation.GetUserInformation().TrafficProvider == TrafficProvider.GoogleMaps)
            {
                convertedDistance = DistanceHelper.MetersToKilometers(distance);
            }

            return convertedDistance;
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