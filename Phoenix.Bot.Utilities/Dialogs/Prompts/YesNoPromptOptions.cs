using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Dialogs.Choices;
using Phoenix.Bot.Utilities.Linguistic;
using System.Collections.Generic;

namespace Phoenix.Bot.Utilities.Dialogs.Prompts
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
            this.RetryPrompt = MessageFactory.Text("Παρακαλώ απάντησε με ένα Ναι ή Όχι:");
            this.Choices = new Choice[2] 
            {
                new Choice(Yes),
                new Choice(simpleNo ? No : NoThanks) { Synonyms = new List<string>(1) { No.RemoveEmojis() } }
            };
        }

        public YesNoPromptOptions(string promptText, bool simpleNo = false)
            : this(simpleNo)
        {
            this.Prompt = MessageFactory.Text(promptText);
        }
    }
}
