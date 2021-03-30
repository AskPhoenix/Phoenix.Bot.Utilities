using Newtonsoft.Json.Linq;
using Phoenix.Bot.Utilities.Linguistic;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Phoenix.Bot.Utilities.Dialogs
{
    public static class DialogsHelper
    {
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

        public static string GeneratePasscode(int size)
        {
            char[] invalidPasswordChars = { 'l', 'I', 'O', '0', '1' };

            string passcode = Convert.ToBase64String(Guid.NewGuid().ToByteArray());
            passcode = new string(passcode.Where(c => !invalidPasswordChars.Contains(c)).ToArray()).Substring(0, size);

            return passcode;
        }
    }
}
