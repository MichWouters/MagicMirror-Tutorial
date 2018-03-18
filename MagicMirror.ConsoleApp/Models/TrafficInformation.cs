using System;

namespace MagicMirror.ConsoleApp.Models
{
    public class TrafficInformation
    {
        public string Destination { get; set; }

        public double Distance { get; set; }

        public string DistanceUOM { get; set; }

        public int Minutes { get; set; }

        public DateTime TimeOfArrival
        {
            get
            {
                return DateTime.Now.AddMinutes(Minutes);
            }
        }
    }
}