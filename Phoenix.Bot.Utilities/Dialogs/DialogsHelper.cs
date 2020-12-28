using Microsoft.Bot.Builder.Dialogs;
using Newtonsoft.Json.Linq;
using Phoenix.Bot.Utilities.Linguistic;
using Phoenix.Bot.Utilities.Miscellaneous;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

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

        public static async Task<string> CreateGifUrlAsync(string rating, string query, int limit, int? offset, string key)
        {
            string giphyUrl = "http://api.giphy.com/v1/gifs/search" + $"?rating={rating}&q={query}&limit={limit}&offset={offset}&api_key={key}";
            string response;

            using (var httpClient = new HttpClient())
            {
                response = await httpClient.GetAsync(giphyUrl).Result.Content.ReadAsStringAsync();
            }

            return JObject.Parse(response)["data"].First["images"]["downsized"]["url"].ToString();
        }

        public static int GenerateVerificationPin(uint digitsNum = 4)
        {
            if (digitsNum > 9)
                throw new Exception("The number of digits must be less than or equal to 9.");

            int min = (int)Math.Pow(10, digitsNum-1);
            int max = min * 10 - 1;

            return new Random().Next(min, max);
        }

        public static string GenerateVerificationCode(string token, uint digitsNum = 2)
        {
            return token.Substring(0, 2).ToUnaccented().ToUpper() + GenerateVerificationPin(digitsNum);
        }
    }
}
