using Acme.Generic.Helpers;
using MagicMirror.UniversalApp.Models;
using MagicMirror.UniversalApp.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace MagicMirror.UniversalApp.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        // Properties
        private OnlineDataModel _onlineDataModel;

        private string _compliment;
        private string _date;
        private static string _time;
        private string _userName;
        private string _weatherIcon;

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

        // Services
        private IMirrorService _service = (Application.Current as App)?.Container.GetRequiredService<IMirrorService>();

        public async Task InitializeAsync()
        {
            await RefreshOnlineData();
            // TODO: Refresh data periodically

            Refresh();
            InitializeRefreshTimers();

            WeatherIcon = SetUpImagePath(OnlineDataModel.WeatherIcon);
        }

        private void GetCompliment(object sender = null, object e = null)
        {
            Compliment = new ComplimentService().GenerateCompliment();
        }

        private void GetDate(object sender = null, object e = null)
        {
            Date = DateTimeHelper.GetCurrentDate();
        }

        private async Task<OnlineDataModel> GetOnlineDataModel(object sender = null, object e = null)
        {
            return await _service.FetchOnlineData(UserSettings.GetUserSettings());
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
        }

        private async Task RefreshOnlineData(object sender = null, object e = null)
        {
            OnlineDataModel = await GetOnlineDataModel();
        }

        private void InitializeRefreshTimers()
        {
            SetTimeIntervalBetweenCalls(GetDate, new TimeSpan(1, 0, 0));
            SetTimeIntervalBetweenCalls(GetTime, new TimeSpan(0, 0, 1));
            SetTimeIntervalBetweenCalls(GetCompliment, new TimeSpan(0, 10, 0));

            //TODO: Refresh data periodically
            //SetTimeIntervalBetweenCalls(RefreshOnlineData, new TimeSpan(0, 10, 0));
        }

        // Todo: Place in reusable location.
        private string SetUpImagePath(string icon, string theme = "Dark")
        {
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
    }
}