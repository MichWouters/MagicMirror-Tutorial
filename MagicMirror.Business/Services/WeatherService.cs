using AutoMapper;
using MagicMirror.Business.Models;
using MagicMirror.Business.Services.Contracts;
using MagicMirror.DataAccess.Entities.Weather;
using MagicMirror.DataAccess.Repos;
using System;
using System.Threading.Tasks;

namespace MagicMirror.Business.Services
{
    public class WeatherService : IWeatherService
    {
        private IWeatherRepo _repo;
        private IMapper Mapper;

        public WeatherService(IWeatherRepo repo)
        {
            // Dependency Injection
            _repo = repo;
        }

        public async Task<WeatherModel> GetWeatherModelAsync(string city)
        {
            WeatherEntity entity = await _repo.GetWeatherEntityByCityAsync(city);

            throw new NotImplementedException();
        }

        public WeatherModel MapFromEntity(WeatherEntity entity)
        {

        }
    }
}
