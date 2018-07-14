using MagicMirror.Business.Models;
using System.Threading.Tasks;

namespace MagicMirror.Business.Services.Contracts
{
    public interface IWeatherService
    {
        Task<WeatherModel> GetWeatherModelAsync(string city);
    }
}
