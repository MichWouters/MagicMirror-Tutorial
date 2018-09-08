using Acme.Generic.Helpers;
using MagicMirror.Business.Enums;
using System;

namespace MagicMirror.Business.Models
{
    public class TrafficModel : Model
    {
        public string Origin { get; set; }

        public string Destination { get; set; }

        public double Distance { get; set; }

        public int Duration { get; set; }

        public DateTime TimeOfArrival { get; set; }

        public DistanceUom DistanceUom { get; set; }

        public override void ConvertValues()
        {
            TimeOfArrival = CalculateTimeOfArrival();
            Distance = ConvertDistance(DistanceUom.Metric);
        }

        public double ConvertDistance(DistanceUom targetUom)
        {
            double result = 0;

            switch (DistanceUom)
            {
                case DistanceUom.Imperial:
                    result = DistanceHelper.KilometersToMiles(Distance);
                    break;

                case DistanceUom.Metric:
                    result = DistanceHelper.MilesToKilometers(Distance);
                    break;

                default:
                    break;
            }

            return result;
        }

        public DateTime CalculateTimeOfArrival()
        {
            return DateTime.Now.AddMinutes(Duration);
        }
    }
}