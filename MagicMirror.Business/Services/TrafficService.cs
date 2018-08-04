using MagicMirror.Business.Models;
using MagicMirror.DataAccess.Entities.Traffic;
using System;
using System.Threading.Tasks;

namespace MagicMirror.Business.Services
{
    public class TrafficService : MappableService<TrafficEntity, TrafficModel>, ITrafficService
    {
        public Task<TrafficModel> GetTrafficModelAsync(string origin, string destination)
        {
            throw new NotImplementedException();
        }
    }
}
