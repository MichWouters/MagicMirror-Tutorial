namespace MagicMirror.DataAccess.Entities.Traffic
{
    public class Step
    {
        public Distance Distance { get; set; }
        public Duration Duration { get; set; }
        public End_Location End_Location { get; set; }
        public string Html_Instructions { get; set; }
        public Polyline Polyline { get; set; }
        public Start_Location Start_Location { get; set; }
        public string TravelMode { get; set; }
        public string Maneuver { get; set; }
    }
}