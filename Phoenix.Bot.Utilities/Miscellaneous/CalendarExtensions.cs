using System;

namespace Phoenix.Bot.Utilities.Miscellaneous
{
    public static class CalendarExtensions
    {
        public static DateTime GreeceLocalTime()
               => TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("E. Europe Standard Time"));
    }
}
