using MagicMirror.Business.Models;

namespace MagicMirror.ConsoleApp.Models
{
    public class MainViewModel
    {
        public TrafficModel Traffic { get; set; }

        public WeatherModel Weather { get; set; }

        public UserInformation User { get; set; }
    }
}
