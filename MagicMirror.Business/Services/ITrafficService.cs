using MagicMirror.Business.Models;
using MagicMirror.DataAccess.Entities.Entities;
using System.Threading.Tasks;

namespace MagicMirror.Business.Services
{
    public interface ITrafficService
    {
        Task<TrafficModel> GetTrafficModelAsync(string origin, string destination);

        TrafficModel MapFromEntity(Entity entity);
    }
}
