using Acme.Generic.Helpers;
using MagicMirror.UniversalApp.Models;
using MagicMirror.UniversalApp.Services;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Windows.UI.Xaml;

namespace MagicMirror.UniversalApp.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        // Properties
        private string _compliment = $"Hello {UserSettings.GetUserSettings().Name}!";

        private string _date = "March 16";
        private double _distance = 42.0;
        private string _distanceUom = "kilometers";
        private bool _isOfflineData = false;
        private string _location = "San Francisco";
        private string _sunrise = "7:03";
        private string _sunset = "19:22";
        private double _temperature = 18;
        private string _temperatureUom = "celsius";
        private string _time = "9:59";
        private string _timeOfArrival;
        private string _travelTime = "28 minutes including heavy traffic";
        private string _userName = "John Doe";
        private string _weather = "Clear sky";
        private string _weatherIcon = "01d";
        private string _weatherType = "Sunny";

        public MainViewModel()
        {
            Refresh();
            SetUpRefreshTimers();

            WeatherIcon = SetUpImagePath(_weatherIcon);
        }

        private string SetUpImagePath(string icon)
        {
            string theme = "Dark";
            string result;
            switch (icon)
            {
                case "01d":
                case "01n":
                case "09n":
                case "09d":
                case "10d":
                case "10n":
                case "11d":
                case "11n":
                case "13d":
                case "13n":
                case "50n":
                case "50d":
                    result = $"{icon}.png";
                    break;

                case "03d":
                case "03n":
                case "04d":
                case "04n":
                    result = "03or4.png";
                    break;

                default:
                    result = "051.png";
                    break;
            }

            return $"/Assets/Weather/{theme}/{result}";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged([CallerMemberName] string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        private void GetDate(object sender = null, object e = null)
        {
            Date = DateTimeHelper.GetCurrentDate();
        }

        private void GetTime(object sender = null, object e = null)
        {
            Time = DateTimeHelper.GetCurrentTime();
        }

        private void GetCompliment(object sender = null, object e = null)
        {
            Compliment = new ComplimentService().GenerateCompliment();
        }

        private void Refresh()
        {
            GetTime();
            GetDate();
            GetCompliment();
        }

        private void SetUpRefreshTimers()
        {
            InitializeTimer(GetDate, new TimeSpan(1, 0, 0));
            InitializeTimer(GetTime, new TimeSpan(0, 0, 1));
            InitializeTimer(GetCompliment, new TimeSpan(0, 10, 0));
        }

        private void InitializeTimer(EventHandler<object> methodToRepeatOnTick, TimeSpan timeSpan)
        {
            DispatcherTimer timer = new DispatcherTimer();

            timer.Tick += methodToRepeatOnTick;
            timer.Interval = timeSpan;

            if (!timer.IsEnabled)
            {
                timer.Start();
            }
        }

        #region Properties

        public string Compliment
        {
            get => _compliment; set
            {
                _compliment = value;
                NotifyPropertyChanged();
            }
        }

        public string Date
        {
            get => _date; set
            {
                _date = value;
                NotifyPropertyChanged();
            }
        }

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

        public string Time
        {
            get => _time; set
            {
                _time = value;
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

        public string UserName
        {
            get => _userName; set
            {
                _userName = value;
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

        public string WeatherIcon
        {
            get => _weatherIcon; set
            {
                _weatherIcon = value;
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