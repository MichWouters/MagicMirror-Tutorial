using MagicMirror.Business.Models;
using System.Threading.Tasks;

namespace MagicMirror.Business.Services
{
    public interface ITrafficService: IService<TrafficModel>
    {
        Task<TrafficModel> GetTrafficModelAsync(string origin, string destination);
    }
}