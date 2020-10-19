using MagicMirror.Business.Models;
using MagicMirror.UniversalApp.Models;
using System.Threading.Tasks;

namespace MagicMirror.UniversalApp.Services
{
    public interface IMirrorService
    {
        Task<OnlineDataModel> FetchOnlineData(UserSettings information);
        TrafficModel GetOfflineTrafficData();
        WeatherModel GetOfflineWeatherData();
        Task<TrafficModel> GetTrafficModelAsync(string origin, string destination);
        Task<WeatherModel> GetWeatherModelAsync(string city);
    }
}