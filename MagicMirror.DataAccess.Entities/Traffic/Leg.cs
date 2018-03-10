namespace MagicMirror.DataAccess.Entities.Traffic
{
    public class Leg
    {
        public Distance distance { get; set; }
        public Duration duration { get; set; }
        public Duration_In_Traffic duration_in_traffic { get; set; }
        public string end_address { get; set; }
        public End_Location end_location { get; set; }
        public string start_address { get; set; }
        public Start_Location start_location { get; set; }
        public Step[] steps { get; set; }
        public object[] traffic_speed_entry { get; set; }
        public object[] via_waypoint { get; set; }
    }
}