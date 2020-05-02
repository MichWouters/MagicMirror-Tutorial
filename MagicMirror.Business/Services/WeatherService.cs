using AutoMapper;
using MagicMirror.Business.Models;
using MagicMirror.DataAccess.Entities.Weather;
using MagicMirror.DataAccess.Repos;
using System.Threading.Tasks;

namespace MagicMirror.Business.Services
{
    public class WeatherService :
        MappableService<WeatherEntity, WeatherModel>, IWeatherService
    {
        private readonly IWeatherRepo _repo;

        public WeatherService(IWeatherRepo repo, IMapper mapper)
        {
            _repo = repo;
            Mapper = mapper;
        }

        public async Task<WeatherModel> GetWeatherModelAsync(string city)
        {
            WeatherEntity entity = await _repo.GetWeatherEntityByCityAsync(city);
            WeatherModel model = MapFromEntity(entity);
            model.InitializeModel();

            return model;
        }
    }
}