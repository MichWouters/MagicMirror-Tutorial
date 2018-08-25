using System;

namespace Acme.Generic.Helpers
{
    public static class DateTimeHelper
    {
        private static DateTime baseUnixDateTime =
            new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public static DateTime ConvertUnixTimeToGMTDateTime(int timestamp)
        {
            DateTime result = baseUnixDateTime.AddSeconds(timestamp);
            return result;
        }

        public static int ConvertGMTDateTimeToDateUnixTime(DateTime date)
        {
            TimeSpan timeSpan = date - baseUnixDateTime;
            return (int)timeSpan.TotalSeconds;
        }
    }
}