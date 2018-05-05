using System.Threading.Tasks;
using MagicMirror.DataAccess.Entities.Weather;

namespace MagicMirror.DataAccess.Repos
{
    public interface IWeatherRepo
    {
        Task<WeatherEntity> GetWeatherEntityByCityAsync(string city);
    }
}