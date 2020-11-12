using Microsoft.Bot.Builder.Dialogs;
using Phoenix.Bot.Utilities.Miscellaneous;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Phoenix.Bot.Utilities.Dialogs
{
    public static class DialogsHelper
    {
        public static DateTime ResolveDateTime(IList<DateTimeResolution> dateTimeResolution)
        {
            if (dateTimeResolution == null || dateTimeResolution.Count == 0)
                throw new Exception("Date Time Resolution cannot be null or empty.");
            if (dateTimeResolution.Count == 1)
                return DateTime.Parse(dateTimeResolution.Single().Value);

            // The result gives 2 Dates with different year.
            // If the date is past for the current year, then the results are (1) for the current year and (2) for the previous one.
            // If the date is not past for the current year, then the results are (1) for the previous year and (2) for the current one.

            var dateTimes = dateTimeResolution.Select(r => DateTime.Parse(r.Value)).OrderBy(d => d.Year);
            var grDateTime = CalendarExtensions.GreeceLocalTime();

            //bool isPastDate = dateTimes.All(d => d.Month < grDateTime.Month || (d.Month == grDateTime.Month && d.Day == grDateTime.Day));
            //return isPastDate ? dateTimes.FirstOrDefault(d => d.Year == grDateTime.Year) : dateTimes.LastOrDefault();

            // Just return the closest date including its year.
            return dateTimes.Aggregate((d, cd) => Math.Abs((d - grDateTime).Days) < Math.Abs((cd - grDateTime).Days) ? d : cd);
        }
    }
}
