using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace Phoenix.Bot.Utilities.Channels.Facebook.FacebookEvents
{
    [JsonObject]
    public class ButtonTemplate : Template
    {
        [JsonProperty("template_type")]
        public override string Type { get => "button"; }

        /// <summary>
        /// UTF-8-encoded text of up to 640 characters.
        /// Text will appear above the buttons.
        /// </summary>
        [JsonProperty("text")]
        [StringLength(640, ErrorMessage = "ButtonTemplate's text must contain less than 640 characters.")]
        public string Text { get; set; }

        /// <summary>
        /// Set of 1-3 buttons that appear as call-to-actions.
        /// </summary>
        [JsonProperty("buttons")]
        [MaxLength(3, ErrorMessage = "ButtonTemplate must contain up to 3 buttons.")]
        public Button[] Buttons { get; set; }

        public ButtonTemplate(string text, Button[] buttons)
        {
            this.Text = text;
            this.Buttons = buttons;
        }

        public ButtonTemplate(string text)
            : this(text, Array.Empty<Button>())
        {
        }
    }
}
