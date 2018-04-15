using MagicMirror.DataAccess.Entities;
using MagicMirror.DataAccess.Entities.Weather;
using System.Threading.Tasks;

namespace MagicMirror.DataAccess.Repos
{
    public interface IWeatherRepo
    {
        Task<WeatherEntity> GetApiData(string city);
    }

    public interface IWeatherRepoAlt<T> where T : Entity
    {
        Task<T> GetApiData();
    }
}