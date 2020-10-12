namespace MagicMirror.UniversalApp.ViewModels
{
    public class MainViewModel
    {
        public string Compliment { get; set; } = "Hello Josh!";
        public string Date { get; set; } = "March 16";
        public string Day { get; set; } = "Wednesday";
        public double Distance { get; set; } = 42.0;
        public string DistanceUom { get; set; }
        public bool IsOfflineData { get; set; }
        public string Location { get; set; } = "San Francisco";
        public string Sunrise { get; set; } = "7:03";
        public string Sunset { get; set; } = "19:22";
        public double Temperature { get; set; } = 18;
        public string TemperatureUom { get; set; }
        public string Time { get; set; } = "9:59";
        public string TimeOfArrival { get; set; }
        public string TravelTime { get; set; } = "28 minutes including heavy traffic";
        public string UserName { get; set; } = "John Doe";
        public string Weather { get; set; } = "Clear sky";
        public string WeatherType { get; set; }
    }
}