namespace MagicMirror.UniversalApp.Models
{
    public sealed class UserSettings
    {
        private static UserSettings _instance;

        public string Address { get; set; }

        public string Name { get; set; }

        public string Town { get; set; }

        public TrafficApiProvider TrafficApiProvider { get; set; }

        public string WorkAddress { get; set; }

        public string Zipcode { get; set; }

        // Singleton
        public static UserSettings GetUserSettings()
        {
            if (_instance == null)
            {
                _instance = new UserSettings();
            }

            return _instance;
        }

        private UserSettings()
        {
            Address = "1 Paris Garden";
            Name = "Michiel";
            Town = "London";
            Zipcode = "SE1 8NU";
            WorkAddress = "Tower Of London";
            TrafficApiProvider = TrafficApiProvider.MapQuest;
        }
    }
}