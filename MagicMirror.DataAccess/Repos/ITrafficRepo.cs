using MagicMirror.DataAccess.Entities.Entities;
using System.Threading.Tasks;

namespace MagicMirror.DataAccess.Repos
{
    public interface ITrafficRepo<T> where T : TrafficEntity
    {
        Task<T> GetTrafficInfoAsync(string start, string destination);
    }
}