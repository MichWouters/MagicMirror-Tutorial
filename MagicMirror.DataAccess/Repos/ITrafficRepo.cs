using MagicMirror.DataAccess.Entities.Traffic;
using System.Threading.Tasks;

namespace MagicMirror.DataAccess.Repos
{
    public interface ITrafficRepo
    {
        Task<TrafficEntity> GetTrafficInfoAsync(string start, string destination);
    }
}