using MagicMirror.DataAccess.Entities.MapQuestTraffic;

namespace MagicMirror.DataAccess.Entities.Entities
{
    public class MapQuestTrafficEntity : TrafficEntity
    {
        public Route route { get; set; }
        public Info info { get; set; }
    }
}
