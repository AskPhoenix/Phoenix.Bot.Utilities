using AdaptiveCards;
using System.Collections.Generic;

namespace Phoenix.Bot.Utilities.AdaptiveCards
{
    public class AdaptiveRichFactSetLight : AdaptiveRichTextBlock
    {
        /// <summary>
        /// Initializes an empty <see cref="AdaptiveRichFactSetLight"/>.
        /// </summary>
        public AdaptiveRichFactSetLight() : base()
        {
            this.Inlines = new List<AdaptiveInline>()
                {
                    new AdaptiveTextRun()
                    {
                        Color = AdaptiveTextColor.Light,
                        Size = AdaptiveTextSize.Large,
                        Weight = AdaptiveTextWeight.Bolder
                    },
                    new AdaptiveTextRun()
                    {
                        Color = AdaptiveTextColor.Light,
                        Size = AdaptiveTextSize.Large,
                        Weight = AdaptiveTextWeight.Lighter
                    }
                };
        }

        /// <summary>
        /// Initializes an <see cref="AdaptiveRichFactSetLight"/> instance with the supplied properties.
        /// </summary>
        /// <param name="fact">The fact text of the FactSet.</param>
        /// <param name="value">The value of the FactSet.</param>
        /// <param name="separator">Include a separator after the FactSet, or not.</param>
        public AdaptiveRichFactSetLight(string fact, string value, bool separator = false) : base()
        {
            this.Inlines = new List<AdaptiveInline>()
                {
                    new AdaptiveTextRun()
                    {
                        Text = fact,
                        Color = AdaptiveTextColor.Light,
                        Size = AdaptiveTextSize.Large,
                        Weight = AdaptiveTextWeight.Bolder
                    },
                    new AdaptiveTextRun()
                    {
                        Text = value,
                        Color = AdaptiveTextColor.Light,
                        Size = AdaptiveTextSize.Large,
                        Weight = AdaptiveTextWeight.Lighter
                    }
                };
            this.Separator = separator;
        }
    }
}
