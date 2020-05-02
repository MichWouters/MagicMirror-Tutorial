using MagicMirror.DataAccess.Entities.OpenMapTraffic;

namespace MagicMirror.DataAccess.Entities.Entities
{
    public class OpenMapTraffic: TrafficEntity
    {
        public Route Route { get; set; }
    }
}