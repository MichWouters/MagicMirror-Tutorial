using AutoMapper;
using MagicMirror.Business.Models;
using MagicMirror.DataAccess.Entities.Entities;

namespace MagicMirror.Business.Services
{
    public abstract class MappableService<TEntity, TModel>
        where TEntity : Entity
        where TModel : Model
    {
        protected IMapper Mapper;

        protected TModel MapFromEntity(TEntity entity)
        {
            var model = Mapper.Map<TModel>(entity);
            return model;
        }
    }
}