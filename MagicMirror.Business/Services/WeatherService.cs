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
        private IMapper mapper;
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

        private void SetUpMapperConfig()
        {
            var baseMappings = new MapperConfigurationExpression();
            baseMappings.AddProfile<AutoMapperConfiguration>();
            var config = new MapperConfiguration(baseMappings);

            mapper = new Mapper(config);
        }

        public WeatherModel MapFromEntity(WeatherEntity entity)
        {
            var model = mapper.Map<WeatherModel>(entity);
            return model;
        }
    }
}
