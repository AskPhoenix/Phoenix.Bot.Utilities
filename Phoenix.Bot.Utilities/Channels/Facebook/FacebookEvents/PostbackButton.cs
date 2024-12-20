﻿using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Phoenix.Bot.Utilities.Channels.Facebook.FacebookEvents
{
    [JsonObject]
    public class PostbackButton : Button
    {
        [JsonProperty("type")]
        public override string Type { get => "postback"; }

        /// <summary>
        /// This data will be sent back to your webhook. 1000 character limit.
        /// </summary>
        [JsonProperty("payload")]
        [StringLength(1000, ErrorMessage = "Payload cannot exceed 1000 characters in length.")]
        public string Payload { get; set; }

        public PostbackButton(string title, string payload)
            : base(title)
        {
            this.Payload = payload;
        }

        public PostbackButton(string title)
            : this(title, title)
        {
        }
    }
}
