using Acme.Generic.Helpers;
using MagicMirror.UniversalApp.Models;
using MagicMirror.UniversalApp.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using Windows.UI.Xaml;

namespace MagicMirror.UniversalApp.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        // Properties
        private string _compliment = $"Hello {UserSettings.GetUserSettings().Name}!";

        private string _date = "March 16";
        private OnlineDataModel _onlineDataModel;
        private static string _time = "9:59";
        private string _userName = "John Doe";
        private string _weatherIcon = "01d";

        // Services
        private IMirrorService _service = (Application.Current as App).Container.GetRequiredService<IMirrorService>();

        public MainViewModel()
        {
            GetOnlineDataModel();
            Refresh();
            InitializeRefreshTimers();

            WeatherIcon = SetUpImagePath(_weatherIcon);
        }

        private void GetCompliment(object sender = null, object e = null)
        {
            Compliment = new ComplimentService().GenerateCompliment();
        }

        private void GetDate(object sender = null, object e = null)
        {
            Date = DateTimeHelper.GetCurrentDate();
        }

        private async void GetOnlineDataModel(object sender = null, object e = null)
        {
            OnlineDataModel = await _service.FetchOnlineData(UserSettings.GetUserSettings());
        }

        private void GetTime(object sender = null, object e = null)
        {
            Time = DateTimeHelper.GetCurrentTime();
        }

        private void SetTimeIntervalBetweenCalls(EventHandler<object> methodToRepeatOnTick, TimeSpan timeSpan)
        {
            DispatcherTimer timer = new DispatcherTimer();

            timer.Tick += methodToRepeatOnTick;
            timer.Interval = timeSpan;

            if (!timer.IsEnabled)
            {
                timer.Start();
            }
        }

        private void Refresh()
        {
            GetTime();
            GetDate();
            GetCompliment();
            GetOnlineDataModel();
        }

        private void InitializeRefreshTimers()
        {
            SetTimeIntervalBetweenCalls(GetDate, new TimeSpan(1, 0, 0));
            SetTimeIntervalBetweenCalls(GetTime, new TimeSpan(0, 0, 1));
            SetTimeIntervalBetweenCalls(GetCompliment, new TimeSpan(0, 10, 0));
            SetTimeIntervalBetweenCalls(GetOnlineDataModel, new TimeSpan(0, 15, 0));
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

        public OnlineDataModel OnlineDataModel
        {
            get => _onlineDataModel; set
            {
                _onlineDataModel = value;
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

        public string UserName
        {
            get => _userName; set
            {
                _userName = value ?? "Anonymous";
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

        #endregion Properties
    }
}