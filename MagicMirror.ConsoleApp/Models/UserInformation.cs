namespace MagicMirror.ConsoleApp.Models
{
    public class UserInformation
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public string Zipcode { get; set; }

        public string Town { get; set; }

        public string WorkAddress { get; set; }

        public TrafficApiProvider TrafficApiProvider { get; set; }
    }

    public enum TrafficApiProvider
    {
        MapQuest = 0,
        GoogleMaps = 1
    }
}