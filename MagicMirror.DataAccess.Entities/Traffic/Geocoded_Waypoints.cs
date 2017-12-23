namespace MagicMirror.DataAccess.Entities.Traffic
{
    public class Geocoded_Waypoints
    {
        public string geocoder_status { get; set; }
        public string place_id { get; set; }
        public string[] types { get; set; }
    }
}