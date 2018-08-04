using MagicMirror.Business.Models;
using MagicMirror.DataAccess.Entities.Traffic;
using System.Threading.Tasks;

namespace MagicMirror.Business.Services
{
    public interface ITrafficService
    {
        Task<TrafficModel> GetTrafficModelAsync(string origin, string destination);

        TrafficModel MapFromEntity(TrafficEntity entity);
    }
}