using MagicMirror.Business.Models;
using MagicMirror.DataAccess.Entities.Weather;
using MagicMirror.DataAccess.Repos;
using System.Threading.Tasks;

namespace MagicMirror.Business.Services
{
    public class WeatherService : Service<WeatherModel>, IWeatherService
    {
        private IWeatherRepo _repo;

        public WeatherService(IWeatherRepo repo)
        {
            // Dependency Injection
            _repo = repo;
        }

        public async Task<WeatherModel> GetWeatherModelAsync(string city)
        {
            WeatherEntity entity = await _repo.GetWeatherEntityByCityAsync(city);
            var model = MapFromEntity(entity);

            return model;
        }
    }
}