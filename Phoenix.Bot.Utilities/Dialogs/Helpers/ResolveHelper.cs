﻿using Microsoft.Bot.Builder.Dialogs;
using Phoenix.Bot.Utilities.Linguistic;

namespace Phoenix.Bot.Utilities.Dialogs.Helpers
{
    public static class ResolveHelper
    {
        public static DateTimeOffset ResolveDateTime(IList<DateTimeResolution> dateTimeResolution)
        {
            if (dateTimeResolution == null || dateTimeResolution.Count == 0)
                throw new ArgumentNullException(nameof(dateTimeResolution));
            if (dateTimeResolution.Count == 1)
                return DateTimeOffset.Parse(dateTimeResolution.Single().Value);

            // The result gives 2 Dates with different year.
            // If the date is past for the current year, then the results are (1) for the current year and (2) for the previous one.
            // If the date is not past for the current year, then the results are (1) for the previous year and (2) for the current one.

            var dateTimes = dateTimeResolution.Select(r => DateTimeOffset.Parse(r.Value)).OrderBy(d => d.Year);

            //bool isPastDate = dateTimes.All(d => d.Month < grDateTime.Month || (d.Month == grDateTime.Month && d.Day == grDateTime.Day));
            //return isPastDate ? dateTimes.FirstOrDefault(d => d.Year == grDateTime.Year) : dateTimes.LastOrDefault();

            // Just return the closest date including its year.
            return dateTimes.Aggregate((d, cd) => Math.Abs((d - DateTimeOffset.UtcNow).Days) < Math.Abs((cd - DateTimeOffset.UtcNow).Days) ? d : cd);
        }

        public static DateTimeOffset ResolveDateTime(string relativeDateText)
        {
            if (string.IsNullOrEmpty(relativeDateText))
                throw new ArgumentNullException(nameof(relativeDateText));

            return relativeDateText.ToDateLiteral() switch
            {
                DateLiteral.Yesterday   => DateTimeOffset.UtcNow.AddDays(-1.0),
                DateLiteral.Today       => DateTimeOffset.UtcNow,
                DateLiteral.Tomorrow    => DateTimeOffset.UtcNow.AddDays(1.0),
                _                       => throw new ArgumentException(
                    $"Date literal is not valid. The valid values are: {Enum.GetNames<DateLiteral>()}."),
            };
        }

        public static DateTimeOffset ResolveDateTimePromptResult(IList<DateTimeResolution> result, string msg)
        {
            if (result is null && string.IsNullOrEmpty(msg))
                throw new InvalidOperationException();

            if (result is null || !result.Any())
                return ResolveDateTime(msg);

            return ResolveDateTime(result);
        }
    }
}
