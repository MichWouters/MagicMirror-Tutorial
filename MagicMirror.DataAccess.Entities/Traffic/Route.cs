namespace MagicMirror.DataAccess.Entities.Traffic
{
    public class Route
    {
        public float Distance { get; set; }

        public string FormattedTime { get; set; }

        public int RealTime { get; set; }

        public int Time { get; set; }

        public string Status { get; set; }
    }
}