namespace MagicMirror.DataAccess.Entities.Traffic
{
    public class TrafficEntity
    {
        public Geocoded_Waypoints[] geocoded_waypoints { get; set; }
        public Route[] routes { get; set; }
        public string status { get; set; }
    }
}