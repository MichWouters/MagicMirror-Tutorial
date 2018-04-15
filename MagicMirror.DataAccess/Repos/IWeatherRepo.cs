using MagicMirror.DataAccess.Entities.Weather;
using System.Threading.Tasks;

namespace MagicMirror.DataAccess.Repos
{
    public interface IWeatherRepo
    {
        Task<WeatherEntity> GetWeatherEntityByCityAsync(string city);
    }
}