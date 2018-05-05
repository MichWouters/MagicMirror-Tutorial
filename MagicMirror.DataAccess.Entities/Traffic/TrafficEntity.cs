namespace MagicMirror.DataAccess.Entities.Traffic
{
    public class TrafficEntity
    {
        public Geocoded_Waypoints[] Geocoded_waypoints { get; set; }
        public Route[] Routes { get; set; }
        public string Status { get; set; }
    }
}