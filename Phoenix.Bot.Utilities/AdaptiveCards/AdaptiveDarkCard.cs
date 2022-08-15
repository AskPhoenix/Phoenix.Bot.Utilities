using AdaptiveCards;

namespace Phoenix.Bot.Utilities.AdaptiveCards
{
    public class AdaptiveDarkCard : AdaptiveCard
    {
        public AdaptiveDarkCard()
            : base(new AdaptiveSchemaVersion(1, 2))
        {
            BackgroundImage = new("https://bot.askphoenix.gr/assets/4f5d75_sq.png");
        }

        public AdaptiveDarkCard(AdaptiveElement adaptiveElement)
            : this()
        {
            Body.Add(adaptiveElement);
        }

        public AdaptiveDarkCard(IEnumerable<AdaptiveElement> adaptiveElements)
            : this()
        {
            Body.AddRange(adaptiveElements);
        }
    }
}
