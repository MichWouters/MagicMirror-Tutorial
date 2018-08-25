using System;

namespace Acme.Generic.Helpers
{
    public static class DateTimeHelper
    {
        private static DateTime baseUnixTime =
            new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public static DateTime ConvertUnixTimeToGMTDateTime(int timeStamp)
        {
            throw new NotImplementedException();
        }

        public static int ConvertGMTDateTimeToUnixTime(DateTime date)
        {
            throw new NotImplementedException();
        }
    }
}
