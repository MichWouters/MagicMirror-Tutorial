namespace MagicMirror.DataAccess.Entities.MapQuestTraffic
{
    public class Route
    {
        public bool hasTollRoad { get; set; }
        public bool hasBridge { get; set; }
        public float distance { get; set; }
        public bool hasTimedRestriction { get; set; }
        public bool hasTunnel { get; set; }
        public bool hasHighway { get; set; }
        public object[] computedWaypoints { get; set; }
        public string formattedTime { get; set; }
        public string sessionId { get; set; }
        public bool hasAccessRestriction { get; set; }
        public int realTime { get; set; }
        public bool hasSeasonalClosure { get; set; }
        public bool hasCountryCross { get; set; }
        public float fuelUsed { get; set; }
        public int time { get; set; }
        public bool hasUnpaved { get; set; }
        public int[] locationSequence { get; set; }
        public bool hasFerry { get; set; }
    }
}
