using MagicMirror.Business.Models;
using MagicMirror.DataAccess.Entities.Entities;

namespace MagicMirror.Business.Services
{
    public interface IService<T> where T : Model
    {
        T MapFromEntity(Entity entity);
    }
}