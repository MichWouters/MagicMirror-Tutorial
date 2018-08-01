using AutoMapper;
using AutoMapper.Configuration;
using MagicMirror.Business.Configuration;
using MagicMirror.Business.Models;
using MagicMirror.DataAccess.Entities.Entities;

namespace MagicMirror.Business.Services
{
    public abstract class MappableService<TEntity, TModel>
        where TEntity : Entity
        where TModel : Model
    {
        private IMapper mapper;

        public MappableService()
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

        public TModel MapFromEntity(TEntity entity)
        {
            var model = mapper.Map<TModel>(entity);
            return model;
        }
    }
}