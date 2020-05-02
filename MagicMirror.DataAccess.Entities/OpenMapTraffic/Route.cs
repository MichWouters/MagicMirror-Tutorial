namespace MagicMirror.DataAccess.Entities.OpenMapTraffic
{
    public class Route
    {
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

        public bool HasTollRoad { get; set; }

        public bool HasTunnel { get; set; }

        public bool HasUnpaved { get; set; }

        public int Time { get; set; }
    }
}