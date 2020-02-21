using MagicMirror.DataAccess.Entities;
using MagicMirror.DataAccess.Entities.Traffic;
using System.Threading.Tasks;

namespace MagicMirror.DataAccess.Repos
{
    public interface IGoogleMapsRepo: ITrafficRepo<GoogleMapsTrafficEntity>
    {
        Task<GoogleMapsTrafficEntity> GetTrafficInfoAsync(string start, string destination);
    }
}