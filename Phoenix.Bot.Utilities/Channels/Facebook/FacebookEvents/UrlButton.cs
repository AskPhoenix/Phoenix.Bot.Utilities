using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Phoenix.Bot.Utilities.Channels.Facebook.FacebookEvents
{
    [JsonObject]
    public class UrlButton : Button
    {
        private string webviewHeightRatio = "full";
        private string? webviewShareButton = null;

        [JsonProperty("type")]
        public override string Type { get => "web_url"; }

        /// <summary>
        /// This URL is opened in a mobile browser when the button is tapped.
        /// Must use HTTPS protocol if messenger_extensions is true.
        /// </summary>
        [JsonProperty("url")]
        [Url]
        public string Url { get; set; }

        /// <summary>
        /// Optional. Height of the Webview.
        /// Valid values: compact, tall, full.
        /// Defaults to full.
        /// </summary>
        [JsonProperty("webview_height_ratio")]
        public string WebviewHeightRatio
        {
            get => webviewHeightRatio;
            set => webviewHeightRatio = value == "compact" || value == "tall" || value == "full" ? value :
                throw new FacebookException("Valid values for webview_height_ratio in Url Button are compact, tall, full");
        }

        /// <summary>
        /// Optional. Must be true if using Messenger Extensions.
        /// </summary>
        [JsonProperty("messenger_extensions")]
        public bool MessengerExtensions { get; set; } = false;

        /// <summary>
        /// The URL to use on clients that don't support Messenger Extensions.
        /// If this is not defined, the url will be used as the fallback.
        /// It may only be specified if messenger_extensions is true.
        /// </summary>
        [JsonProperty("fallback_url")]
        public string? FallbackUrl { get; set; }

        /// <summary>
        /// Optional. Set to hide to disable the share button in the Webview (for sensitive info).
        /// This does not affect any shares initiated by the developer using Extensions.
        /// </summary>
        [JsonProperty("webview_share_button")]
        public string? WebviewShareButton
        {
            get => webviewShareButton;
            set => webviewShareButton = value == null || value == "hide" ? value :
                throw new FacebookException("webview_share_button value of Url Button must be hide if set.");
        }

        public UrlButton(string title, string url,
            string webviewHeightRatio = "full",
            bool messengerExtensions = false,
            string? fallback_Url = null,
            string? webviewShareButton = null)
            : base(title)
        {
            this.Url = url;
            this.WebviewHeightRatio = webviewHeightRatio;
            this.MessengerExtensions = messengerExtensions;
            this.FallbackUrl = fallback_Url;
            this.WebviewShareButton = webviewShareButton;
        }

        public UrlAction ToUrlAction() => new UrlAction(Url, WebviewHeightRatio, MessengerExtensions, FallbackUrl, WebviewShareButton);
    }
}
