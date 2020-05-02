using MagicMirror.Business.Models;
using System.Threading.Tasks;

namespace MagicMirror.Business.Services
{
    public interface ITrafficService
    {
        Task<GoogleMapsTrafficModel> GetTrafficModelAsync(string origin, string destination);
    }
}