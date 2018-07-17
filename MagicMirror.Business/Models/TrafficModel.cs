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
    }
}