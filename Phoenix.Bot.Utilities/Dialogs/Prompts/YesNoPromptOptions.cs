using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Dialogs.Choices;
using System.Collections.Generic;

namespace Phoenix.Bot.Utilities.Dialogs.Prompts
{
    public class YesNoPromptOptions : PromptOptions
    {
        public YesNoPromptOptions() : base()
        {
            this.RetryPrompt = MessageFactory.Text("Παρακαλώ απάντησε με ένα Ναι ή Όχι:");
            this.Choices = new Choice[] 
            {
                new Choice("✔️ Ναι"),
                new Choice("❌ Όχι, ευχαριστώ") { Synonyms = new List<string> { "Όχι" } }
            };
        }

        public YesNoPromptOptions(string promptText) : this()
        {
            this.Prompt = MessageFactory.Text(promptText);
        }
    }
}
