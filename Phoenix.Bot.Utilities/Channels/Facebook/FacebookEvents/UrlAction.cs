using Newtonsoft.Json;

namespace Phoenix.Bot.Utilities.Channels.Facebook.FacebookEvents
{
    [JsonObject]
    public class UrlAction : UrlButton
    {
        [JsonIgnore]
        public new string Title { get; set; } = null!;

        public UrlAction(string url,
            string webviewHeightRatio = "full",
            bool messengerExtensions = false,
            string? fallback_Url = null,
            string? webviewShareButton = null) :
            base(null!, url, webviewHeightRatio, messengerExtensions, fallback_Url, webviewShareButton)
        {
        }
    }
}
