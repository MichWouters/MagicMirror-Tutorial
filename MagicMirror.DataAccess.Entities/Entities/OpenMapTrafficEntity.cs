using MagicMirror.DataAccess.Entities.OpenMapTraffic;

namespace MagicMirror.DataAccess.Entities.Entities
{
    public class OpenMapTrafficEntity: TrafficEntity
    {
        public Route Route { get; set; }
    }
}