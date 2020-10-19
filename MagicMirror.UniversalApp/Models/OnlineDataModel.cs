using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MagicMirror.UniversalApp.Models
{
    public class OnlineDataModel : INotifyPropertyChanged
    {
        private double _distance = 42.0;
        private string _distanceUom = "kilometers";
        private bool _isOfflineData = true;
        private string _location = "San Francisco";
        private string _sunrise = "7:03";
        private string _sunset = "19:22";
        private double _temperature = 18;
        private string _temperatureUom = "celsius";
        private string _timeOfArrival;
        private string _travelTime = "28 minutes including heavy traffic";
        private string _weather = "Clear sky";
        private string _weatherType = "Sunny";

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged([CallerMemberName] string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        #region Properties

        public double Distance
        {
            get => _distance; set
            {
                _distance = value;
                NotifyPropertyChanged();
            }
        }

        public string DistanceUom
        {
            get => _distanceUom; set
            {
                _distanceUom = value;
                NotifyPropertyChanged();
            }
        }

        public bool IsOfflineData
        {
            get => _isOfflineData; set
            {
                _isOfflineData = value;
                NotifyPropertyChanged();
            }
        }

        public string Location
        {
            get => _location; set
            {
                _location = value;
                NotifyPropertyChanged();
            }
        }

        public string Sunrise
        {
            get => _sunrise; set
            {
                _sunrise = value;
                NotifyPropertyChanged();
            }
        }

        public string Sunset
        {
            get => _sunset; set
            {
                _sunset = value;
                NotifyPropertyChanged();
            }
        }

        public double Temperature
        {
            get => _temperature; set
            {
                _temperature = value;
                NotifyPropertyChanged();
            }
        }

        public string TemperatureUom
        {
            get => _temperatureUom; set
            {
                _temperatureUom = value;
                NotifyPropertyChanged();
            }
        }

        public string TimeOfArrival
        {
            get => _timeOfArrival; set
            {
                _timeOfArrival = value;
                NotifyPropertyChanged();
            }
        }

        public string TravelTime
        {
            get => _travelTime; set
            {
                _travelTime = value;
                NotifyPropertyChanged();
            }
        }

        public string Weather
        {
            get => _weather; set
            {
                _weather = value;
                NotifyPropertyChanged();
            }
        }

        public string WeatherType
        {
            get => _weatherType; set
            {
                _weatherType = value;
                NotifyPropertyChanged();
            }
        }

        #endregion Properties
    }
}