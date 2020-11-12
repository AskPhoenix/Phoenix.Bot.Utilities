using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Phoenix.Bot.Utilities.Channels.Facebook.FacebookEvents
{
    [JsonObject]
    public abstract class Button
    {
        public abstract string Type { get; }

        /// <summary>
        /// Button title. 20 character limit.
        /// </summary>
        [JsonProperty("title")]
        [StringLength(20, ErrorMessage = "Button title must contain up to 20 characters.")]
        public string Title { get; set; }
    }
}
