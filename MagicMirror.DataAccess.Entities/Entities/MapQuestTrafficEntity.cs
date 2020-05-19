using MagicMirror.DataAccess.Entities.MapQuestTraffic;

namespace MagicMirror.DataAccess.Entities.Entities
{
    public class MapQuestTrafficEntity : TrafficEntity
    {
        public Route Route { get; set; }

        public Info Info { get; set; }
    }
}
