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
        private IMapper _mapper;

        protected MappableService()
        {
            SetUpMapperConfig();
        }

        protected void SetUpMapperConfig()
        {
            var baseMappings = new MapperConfigurationExpression();
            baseMappings.AddProfile<AutoMapperConfiguration>();
            var config = new MapperConfiguration(baseMappings);

            _mapper = new Mapper(config);
        }

        public TModel MapFromEntity(TEntity entity)
        {
            var model = _mapper.Map<TModel>(entity);
            return model;
        }
    }
}