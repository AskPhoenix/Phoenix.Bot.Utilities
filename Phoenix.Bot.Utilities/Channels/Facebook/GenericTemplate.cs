using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Phoenix.Bot.Utilities.Channels.Facebook
{
    [JsonObject]
    public class GenericTemplate : Template
    {
        private string imageAspectRatio = "horizontal";

        [JsonProperty("template_type")]
        public override string Type { get => "generic"; }

        /// <summary>
        /// Optional. The aspect ratio used to render images specified by element.image_url.
        /// Must be horizontal (1.91:1) or square (1:1).
        /// Defaults to horizontal.
        /// </summary>
        [JsonProperty("image_aspect_ratio")]
        public string ImageAspectRatio
        {
            get => imageAspectRatio;
            set => imageAspectRatio = value == "horizontal" || value == "square" ? value :
                throw new FacebookException("image_aspect_ratio value must either horizontal or square.");
        }

        /// <summary>
        /// An array of element objects that describe instances of the generic template to be sent.
        /// Specifying multiple elements will send a horizontally scrollable carousel of templates.
        /// A maximum of 10 elements is supported.
        /// </summary>
        [JsonProperty("elements")]
        [MaxLength(10, ErrorMessage = "There must be up to 10 elements in a Generic Template Caraousel.")]
        public GenericElement[] Elements { get; set; }

        public GenericTemplate() { }

        public GenericTemplate(GenericElement[] elements, string imageAspectRatio = "horizontal")
        {
            this.ImageAspectRatio = imageAspectRatio;
            this.Elements = elements;
        }
    }
}
