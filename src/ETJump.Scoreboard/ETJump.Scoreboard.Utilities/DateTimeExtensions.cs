using System;
using System.Collections.Generic;
using System.Text;

namespace ETJump.Scoreboard.Utilities
{
    public static class DateTimeExtensions
    {
        private static readonly DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);

        public static DateTime FromUnixTimestamp(this int unixTimestamp)
        {
            // ReSharper disable once ImpureMethodCallOnReadonlyValueField
            return Epoch.AddSeconds(unixTimestamp);
        }

        public static int ToUnixTimestamp(this DateTime dateTime)
        {
            return (int)(dateTime - Epoch).TotalSeconds;
        }
    }
}
