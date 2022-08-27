using AdaptiveCards;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;
using Newtonsoft.Json.Linq;

namespace Phoenix.Bot.Utilities.AdaptiveCards
{
    public class AdaptivePhoenixCard : AdaptiveCard
    {
        public AdaptivePhoenixCard()
            : base(new AdaptiveSchemaVersion(1, 2))
        {
            BackgroundImage = new("https://bot.askphoenix.gr/assets/4f5d75_sq.png");
        }

        public AdaptivePhoenixCard(AdaptiveElement adaptiveElement)
            : this()
        {
            Body.Add(adaptiveElement);
        }

        public AdaptivePhoenixCard(IEnumerable<AdaptiveElement> adaptiveElements)
            : this()
        {
            Body.AddRange(adaptiveElements);
        }

        public Attachment ToAttachment()
        {
            return new(contentType: AdaptiveCard.ContentType, content: JObject.FromObject(this));
        }

        public IMessageActivity ToActivity(string? text = null)
        {
            return MessageFactory.Attachment(this.ToAttachment(), text);
        }
    }
}
