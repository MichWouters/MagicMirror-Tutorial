namespace MagicMirror.ConsoleApp.Models
{
    public enum TrafficProvider
    {
        OpenTrafficMap = 0,
        GoogleMaps = 1,
    }

    public sealed class UserInformation
    {
        private static UserInformation _information;

        private UserInformation()
        {
            Address = "1 Paris Garden";
            Name = "Michiel";
            Town = "London";
            Zipcode = "SE1 8NU";
            WorkAddress = "Tower Of London";
            TrafficProvider = TrafficProvider.OpenTrafficMap;
        }

        public string Address { get; set; }

        public string Name { get; set; }

        public string Town { get; set; }

        public TrafficProvider TrafficProvider { get; set; }

        public string WorkAddress { get; set; }

        public string Zipcode { get; set; }

        // Local method can access local constructor.
        // Check if object exists -> If not, create new one, otherwise return the unique object.
        public static UserInformation GetUserInformation()
        {
            return _information ?? (_information = new UserInformation());
        }
    }
}