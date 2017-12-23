namespace MagicMirror.DataAccess.Entities.Traffic
{
    public class Step
    {
        public Distance distance { get; set; }
        public Duration duration { get; set; }
        public End_Location end_location { get; set; }
        public string html_instructions { get; set; }
        public Polyline polyline { get; set; }
        public Start_Location start_location { get; set; }
        public string travel_mode { get; set; }
        public string maneuver { get; set; }
    }
}