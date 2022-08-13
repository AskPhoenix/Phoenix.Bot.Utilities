using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Dialogs.Choices;
using Phoenix.DataHandle.Utilities;

namespace Phoenix.Bot.Utilities.Dialogs.Prompts.Options
{
    public class YesNoPromptOptions : PromptOptions
    {
        public const string Yes = "✔️ Ναι";
        public const string No = "❌ Όχι";
        public const string NoThanks = "❌ Όχι, ευχαριστώ";

        public YesNoPromptOptions()
            : this(false) { }

        public YesNoPromptOptions(bool simpleNo)
            : base()
        {
            RetryPrompt = MessageFactory.Text("Παρακαλώ απάντησε με ένα Ναι ή Όχι:");
            Choices = new Choice[2]
            {
                new(Yes),
                new(simpleNo ? No : NoThanks) { Synonyms = new(1) { No.RemoveEmojis(postTrim: true) } }
            };
        }

        public YesNoPromptOptions(string promptText, bool simpleNo = false)
            : this(simpleNo)
        {
            Prompt = MessageFactory.Text(promptText);
        }
    }
}
