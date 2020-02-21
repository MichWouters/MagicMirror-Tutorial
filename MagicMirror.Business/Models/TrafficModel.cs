using Acme.Generic.Enums;
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

        public override void InitializeModel()
        {
            TimeOfArrival = DateTimeHelper.CalculateTimeOfArrival(Duration, DateTime.Now, TimeInterval.Seconds);
            Distance = ConvertDistance(Distance, this.DistanceUom, DistanceUom.Metric);
        }

        public double ConvertDistance(double distance, DistanceUom sourceUom, DistanceUom targetUom)
        {
            double result = 0;

            if (sourceUom == DistanceUom.Imperial)
            {
                switch (targetUom)
                {
                    case DistanceUom.Imperial:
                        result = Distance;
                        break;

                    case DistanceUom.Metric:
                        result = DistanceHelper.MilesToKilometers(distance);
                        break;

                    default:
                        break;
                }
            }
            else
            {
                switch (targetUom)
                {
                    case DistanceUom.Imperial:
                        result = DistanceHelper.KilometersToMiles(distance);
                        break;

                    case DistanceUom.Metric:
                        result = Distance;
                        break;

                    default:
                        break;
                }
            }

            Distance = result;
            DistanceUom = targetUom;
            return result;
        }
    }
}