using System;
using System.Collections.Generic;
using System.Text;

namespace MagicMirror.DataAccess.Entities.Traffic
{
    public class Leg
    {
        public Distance Distance { get; set; }
        public Duration Duration { get; set; }
        public string End_Address { get; set; }
        public End_Location End_Location { get; set; }
        public string Start_Address { get; set; }
        public Start_Location Start_Location { get; set; }
        public Step[] Steps { get; set; }
        public object[] Traffic_Speed_Entry { get; set; }
        public object[] Via_Waypoint { get; set; }
    }
}