namespace MagicMirror.DataAccess.Entities.Traffic
{
    public class TrafficEntity : Entities.Entity
    {
        public Geocoded_Waypoints[] Geocoded_waypoints { get; set; }
        public Route[] Routes { get; set; }
        public string Status { get; set; }
    }
}