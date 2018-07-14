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
        private IMapper Mapper;

        public WeatherService(IWeatherRepo repo)
        {
            // Dependency Injection
            _repo = repo;

            // Configure AutoMapper
            SetUpMapperConfiguration();
        }

        private void SetUpMapperConfiguration()
        {
            var baseMappings = new MapperConfigurationExpression();
            baseMappings.AddProfile<AutoMapperConfiguration>();
            var config = new MapperConfiguration(baseMappings);

            Mapper = new Mapper(config);
        }

        public async Task<WeatherModel> GetWeatherModelAsync(string city)
        {
            WeatherEntity entity = await _repo.GetWeatherEntityByCityAsync(city);
            var model = MapFromEntity(entity);

            return model;
        }

        public WeatherModel MapFromEntity(WeatherEntity entity)
        {
            var model = Mapper.Map<WeatherModel>(entity);
            return model;
        }
    }
}
