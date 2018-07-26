using AutoMapper;
using AutoMapper.Configuration;
using MagicMirror.Business.Configuration;
using MagicMirror.Business.Models;
using MagicMirror.DataAccess.Entities.Entities;

namespace MagicMirror.Business.Services
{
    public abstract class MappableService<TDest, TSource> 
        where TDest : Entity
        where TSource : Model
    {
        protected IMapper Mapper;

        protected MappableService()
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

        public TDest MapFromEntity(TSource entity)
        {
            var model = Mapper.Map<TDest>(entity);
            return model;
        }
    }
}