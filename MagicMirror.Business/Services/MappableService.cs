using AutoMapper;
using AutoMapper.Configuration;
using MagicMirror.Business.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace MagicMirror.Business.Services
{
    public abstract class MappableService
    {
        private IMapper mapper;

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
