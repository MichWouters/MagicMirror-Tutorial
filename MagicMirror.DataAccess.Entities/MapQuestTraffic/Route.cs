namespace MagicMirror.DataAccess.Entities.MapQuestTraffic
{
    public class Route
    {
        public object[] ComputedWaypoints { get; set; }

        public float Distance { get; set; }

        public string FormattedTime { get; set; }

        public float FuelUsed { get; set; }

        public bool HasAccessRestriction { get; set; }

        public bool HasBridge { get; set; }

        public bool HasCountryCross { get; set; }

        public bool HasFerry { get; set; }

        public bool HasHighway { get; set; }

        public bool HasSeasonalClosure { get; set; }

        public bool HasTimedRestriction { get; set; }

        public bool hasTollRoad { get; set; }

        public bool HasTunnel { get; set; }

        public bool HasUnpaved { get; set; }

        public int[] LocationSequence { get; set; }

        public int RealTime { get; set; }

        public string SessionId { get; set; }
        
        public int Time { get; set; }
    }
}