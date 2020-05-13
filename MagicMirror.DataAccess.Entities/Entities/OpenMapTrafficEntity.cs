using MagicMirror.DataAccess.Entities.OpenMapTraffic;

namespace MagicMirror.DataAccess.Entities.Entities
{
    public class OpenMapTrafficEntity: TrafficEntity
    {
        public Route Route { get; set; }

        public Info Info { get; set; }
    }

    public class Info
    {
        public int Statuscode { get; set; }
        public object[] Messages { get; set; }
    }
}