using AutoMapper;
using AutoMapper.Configuration;
using MagicMirror.Business.Configuration;
using MagicMirror.Business.Models;
using MagicMirror.DataAccess.Entities.Weather;
using MagicMirror.DataAccess.Repos;

namespace MagicMirror.Business.Services
{
    public class WeatherService
    {
        private IMapper mapper;
        private IWeatherRepo _repo;

        public WeatherService()
        {
            SetUpMapperConfig();
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
