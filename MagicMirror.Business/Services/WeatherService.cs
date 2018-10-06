using MagicMirror.Business.Models;
using MagicMirror.DataAccess.Entities.Weather;
using MagicMirror.DataAccess.Repos;
using System.Threading.Tasks;

namespace MagicMirror.Business.Services
{
    public class WeatherService :
        MappableService<WeatherEntity, WeatherModel>, IWeatherService
    {
        private IWeatherRepo _repo;

        public WeatherService()
        {
            _repo = new WeatherRepo();
        }

        public async Task<WeatherModel> GetWeatherModelAsync(string city)
        {
            WeatherEntity entity = await _repo.GetWeatherEntityByCityAsync(city);
            WeatherModel model = MapFromEntity(entity);
            model.ConvertValues();

            return model;
        }
    }
}