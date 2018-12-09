using MagicMirror.Business.Models;
using MagicMirror.DataAccess.Entities.Weather;
using System.Threading.Tasks;

namespace MagicMirror.Business.Services
{
    public interface IWeatherService
    {
        Task<WeatherModel> GetWeatherModelAsync(string city);
        WeatherModel MapFromEntity(WeatherEntity entity);
    }
}