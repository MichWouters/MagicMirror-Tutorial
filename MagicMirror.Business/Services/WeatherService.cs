using AutoMapper;
using AutoMapper.Configuration;
using MagicMirror.Business.Configuration;
using MagicMirror.Business.Models;
using MagicMirror.DataAccess.Entities.Weather;
using MagicMirror.DataAccess.Repos;
using System.Threading.Tasks;

namespace MagicMirror.Business.Services
{
    public class WeatherService : IWeatherService
    {
        
        private IWeatherRepo _repo;

        public WeatherService()
        {
            SetUpMapperConfig();
            _repo = new WeatherRepo();
        }

        public async Task<WeatherModel>GetWeatherModelAsync(string city)
        {
            WeatherEntity entity = await _repo.GetWeatherEntityByCityAsync(city);
            WeatherModel model = MapFromEntity(entity);

            return model;
        }

        
    }
}
