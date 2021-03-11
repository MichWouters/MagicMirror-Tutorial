using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MagicMirror.UniversalApp.Models
{
    public class OnlineDataModel : INotifyPropertyChanged
    {
        private double _distance;
        private string _distanceUom;
        private bool _isOfflineData = true;
        private string _location;
        private string _sunrise;
        private string _sunset;
        private double _temperature;
        private string _temperatureUom;
        private string _timeOfArrival;
        private string _travelTime;
        private string _weatherIcon;
        private string _weatherType;
        public event PropertyChangedEventHandler PropertyChanged;

        public string WeatherIcon
        {
            get { return _weatherIcon; }
            set
            {
                _weatherIcon = value;
                NotifyPropertyChanged();
            }
        }
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