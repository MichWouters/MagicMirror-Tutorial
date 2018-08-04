using MagicMirror.Business.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MagicMirror.Business.Models
{
    public class TrafficModel : Model
    {
        public double Distance { get; set; }

        public int TravelTime { get; set; }

        public DateTime HourOfArrival { get; set; }

        public TrafficDensity TrafficDensity { get; set; }

        public DistanceUom DistanceUom { get; set; }
    }
}