using MagicMirror.Business.Models;
using MagicMirror.UniversalApp.Models;
using MagicMirror.UniversalApp.ViewModels;
using System.Threading.Tasks;

namespace MagicMirror.UniversalApp.Services
{
    public interface IMirrorService
    {
        Task<MainViewModel> GenerateViewModel(UserSettings information);
        TrafficModel GetOfflineTrafficData();
        WeatherModel GetOfflineWeatherData();
        Task<TrafficModel> GetTrafficModelAsync(string origin, string destination);
        Task<WeatherModel> GetWeatherModelAsync(string city);
    }
}