using Newtonsoft.Json.Linq;

namespace Phoenix.Bot.Utilities.Dialogs.Helpers
{
    public static class DialogsHelper
    {
        public static async Task<string> FindGifUrlAsync(string rating, string query, int limit,
            int? offset, string key)
        {
            string giphyUrl = "http://api.giphy.com/v1/gifs/search"
                + $"?rating={rating}&q={query}&limit={limit}&offset={offset}&api_key={key}";

            string response;
            using (var httpClient = new HttpClient())
                response = await httpClient.GetAsync(giphyUrl).Result.Content.ReadAsStringAsync();

            return JObject.Parse(response)["data"]!.First!["images"]!["downsized"]!["url"]!.ToString();
        }
    }
}
