using MagicMirror.DataAccess.Entities.Traffic;
using System.Threading.Tasks;

namespace MagicMirror.DataAccess.Repos
{
    public interface IGoogleMapsRepo: ITrafficRepo<GoogleMapsTrafficEntity>
    {

    }
}