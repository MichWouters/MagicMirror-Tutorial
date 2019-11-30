namespace MagicMirror.ConsoleApp.Models
{
    public class MainViewModel
    {
        public string UserName { get; set; }

        public double Temperature { get; set; }

        public string TemperatureUom { get; set; }

        public string WeatherType { get; set; }

        public string Sunrise { get; set; }

        public string Sunset { get; set; }

        public string TimeOfArrival { get; set; }

        public string TravelTime { get; set; }

        public double Distance { get; set; }

        public string DistanceUom { get; set; }

        public bool IsOfflineData { get; set; }
    }
}