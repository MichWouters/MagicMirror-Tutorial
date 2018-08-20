using System;

namespace Acme.Generic.Helpers
{
    public static class UnixTimeHelper
    {
        private static DateTime baseUnixDateTime =
            new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public static DateTime ConvertFromUnixTimeStamp(int timestamp)
        {
            DateTime result = baseUnixDateTime.AddSeconds(timestamp);
            return result;
        }

        public static int ConvertToUnixTimeStamp(DateTime date)
        {
            TimeSpan timeSpan = date - baseUnixDateTime;
            return (int)timeSpan.TotalSeconds;
        }
    }
}