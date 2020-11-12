using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Phoenix.Bot.Utilities.Channels.Facebook.FacebookEvents
{
    [JsonObject]
    public class GenericElement
    {
        /// <summary>
        /// The title to display in the template. 80 character limit.
        /// </summary>
        [JsonProperty("title")]
        [StringLength(80, ErrorMessage = "Element's title must be no more than 80 characters.")]
        public string Title { get; set; }

        /// <summary>
        /// Optional. The subtitle to display in the template. 80 character limit.
        /// </summary>
        [JsonProperty("subtitle")]
        [StringLength(80, ErrorMessage = "Element's subtitle must be no more than 80 characters.")]
        public string Subtitle { get; set; }

        /// <summary>
        /// Optional. The URL of the image to display in the template.
        /// </summary>
        [JsonProperty("image_url")]
        [Url]
        public string ImageUrl { get; set; }

        /// <summary>
        /// Optional. The default action executed when the template is tapped.
        /// Accepts the same properties as URL button, except title.
        /// </summary>
        [JsonProperty("default_action")]
        public UrlAction DefaultAction { get; set; }

        /// <summary>
        /// Optional. An array of buttons to append to the template.
        /// A maximum of 3 buttons per element is supported.
        /// </summary>
        [JsonProperty("buttons")]
        [MaxLength(3, ErrorMessage = "A maximum of 3 buttons per element is supported.")]
        public Button[] Buttons { get; set; }

        public GenericElement() { }

        public GenericElement(string title, string subtitle = null, string imageUrl = null, UrlAction defaultAction = null, Button[] buttons = null)
        {
            this.Title = title;
            this.Subtitle = subtitle;
            this.ImageUrl = imageUrl;
            this.DefaultAction = defaultAction;
            this.Buttons = buttons;
        }
    }
}
