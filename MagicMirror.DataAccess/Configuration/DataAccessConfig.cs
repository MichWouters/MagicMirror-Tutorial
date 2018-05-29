namespace MagicMirror.DataAccess.Configuration
{
    public static class DataAccessConfig
    {
        public static string OpenWeatherMapApiId
        {
            get
            {
                return "14785d234ad5cf3a84fb674779edf62e";
            }
        }

        public static string OpenWeatherMapApiUrl
        {
            get
            {
                return "http://api.openweathermap.org/data/2.5";
            }
        }

        public static string TrafficApiUrl
        {
            get
            {
                return "https://maps.googleapis.com/maps/api/distancematrix/json";
            }
        }

        public static string TrafficApiId
        {
            get
            {
                return "AIzaSyBGoN7HTIWBLk6N9CqEqvJsV_KGFmwt8tw";
            }
        }
    }
}