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
        // Timers
        private DispatcherTimer _dateTimer;
        private DispatcherTimer _timeTimer;
        private DispatcherTimer _complimentTimer;

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
        private string _weatherType = "Sunny";

        public MainViewModel()
        {
            RefreshAllData();
            SetUpRefreshTimers();
        }

        public event PropertyChangedEventHandler PropertyChanged;

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

        public string WeatherType
        {
            get => _weatherType; set
            {
                _weatherType = value;
                NotifyPropertyChanged();
            }
        }
        #endregion

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

        private void RefreshAllData()
        {
            GetTime();
            GetDate();
            GetCompliment();
        }

        private void SetUpRefreshTimers()
        {
            _dateTimer = new DispatcherTimer();
            _timeTimer = new DispatcherTimer();
            _complimentTimer = new DispatcherTimer();

            SetupTimer(_dateTimer, new TimeSpan(1, 0, 0), GetDate);
            SetupTimer(_timeTimer, new TimeSpan(0, 0, 1), GetTime);
            SetupTimer(_complimentTimer, new TimeSpan(0, 0, 10), GetCompliment);
        }

        private void SetupTimer(DispatcherTimer timer, TimeSpan timeSpan, EventHandler<object> method)
        {
            timer.Tick += method;
            timer.Interval = timeSpan;

            if (!timer.IsEnabled)
            {
                timer.Start();
            }
        }
    }
}