namespace MagicMirror.UniversalApp
{
    internal class UpcomingDay
    {
        public string Day { get; set; }

        public string Icon { get; set; }

        public int MinTemp { get; set; }

        public int MaxTemp { get; set; }

        public UpcomingDay(string day, string icon, int minTemp, int maxTemp)
        {
            Day = day;
            Icon = icon;
            MinTemp = minTemp;
            MaxTemp = maxTemp;
        }
    }
}