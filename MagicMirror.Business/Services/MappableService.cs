using AutoMapper;
using MagicMirror.Business.Models;
using MagicMirror.DataAccess.Entities.Entities;

namespace MagicMirror.Business.Services
{
    public abstract class MappableService<TEntity, TModel>
        where TEntity : Entity
        where TModel : Model
    {
        protected IMapper _mapper;

        public TModel MapFromEntity(TEntity entity)
        {
            var model = _mapper.Map<TModel>(entity);
            return model;
        }
    }
}