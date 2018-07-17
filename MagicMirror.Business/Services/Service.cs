using AutoMapper;
using AutoMapper.Configuration;
using MagicMirror.Business.Configuration;
using MagicMirror.Business.Models;
using MagicMirror.DataAccess.Entities.Entities;

namespace MagicMirror.Business.Services
{
    public abstract class Service<T> : IService<T> where T : Model
    {
        protected IMapper Mapper;

        protected Service()
        {
            // Configure AutoMapper
            SetUpMapperConfiguration();
        }

        protected void SetUpMapperConfiguration()
        {
            var baseMappings = new MapperConfigurationExpression();
            baseMappings.AddProfile<AutoMapperConfiguration>();
            var config = new MapperConfiguration(baseMappings);

            Mapper = new Mapper(config);
        }

        public T MapFromEntity(Entity entity)
        {
            var model = Mapper.Map<T>(entity);
            return model;
        }
    }
}