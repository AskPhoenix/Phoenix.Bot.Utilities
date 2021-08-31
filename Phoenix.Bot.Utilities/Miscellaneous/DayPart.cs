namespace Phoenix.Bot.Utilities.Miscellaneous
{
    public enum DayPart
    {
        Morning = 0,    // 09:00
        Midday,         // 12:00
        Afternoon,      // 17:00
        Evening         // 20:00
    }

    public static class DayPartExtensions
    {
        //TODO: Locale
        public static string ToFriendlyString(this DayPart me)
        {
            return me switch
            {
                DayPart.Morning => "Πρωί",
                DayPart.Midday => "Μεσημέρι",
                DayPart.Afternoon => "Απόγευμα",
                DayPart.Evening => "Βραδάκι",
                _ => string.Empty
            };
        }
    }
}
