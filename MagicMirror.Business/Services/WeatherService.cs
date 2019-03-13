using MagicMirror.Business.Models;
using MagicMirror.DataAccess.Entities.Weather;
using MagicMirror.DataAccess.Repos;
using System.Threading.Tasks;
using AutoMapper;

namespace MagicMirror.Business.Services
{
    public class WeatherService :
        MappableService<WeatherEntity, WeatherModel>, IWeatherService
    {
        private readonly IWeatherRepo _repo;
        private readonly IMapper _mapper;

        public WeatherService(IWeatherRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
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