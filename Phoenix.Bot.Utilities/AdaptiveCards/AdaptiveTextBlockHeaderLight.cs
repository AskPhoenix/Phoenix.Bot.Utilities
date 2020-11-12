using AdaptiveCards;

namespace Phoenix.Bot.Utilities.AdaptiveCards
{
    public class AdaptiveTextBlockHeaderLight : AdaptiveTextBlock
    {
        /// <summary>
        /// Initializes an empty <see cref="AdaptiveTextBlockHeaderLight"/> instance.
        /// </summary>
        public AdaptiveTextBlockHeaderLight() : this("") { }

        /// <summary>
        /// Initializes an <see cref="AdaptiveTextBlockHeaderLight"/> instance with the supplied text.
        /// </summary>
        /// <param name="text">The text of this TextBlock.</param>
        public AdaptiveTextBlockHeaderLight(string text) : base(text)
        {
            this.Color = AdaptiveTextColor.Light;
            this.HorizontalAlignment = AdaptiveHorizontalAlignment.Center;
            this.Size = AdaptiveTextSize.ExtraLarge;
            this.Weight = AdaptiveTextWeight.Bolder;
            this.Wrap = true;
        }
    }
}
