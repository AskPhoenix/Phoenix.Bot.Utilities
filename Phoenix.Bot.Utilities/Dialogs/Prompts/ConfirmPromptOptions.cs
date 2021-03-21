using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Dialogs.Choices;
using System.Collections.Generic;

namespace Phoenix.Bot.Utilities.Dialogs.Prompts
{
    public class ConfirmPromptOptions : PromptOptions
    {
        public ConfirmPromptOptions() : base()
        {
            this.RetryPrompt = MessageFactory.Text("Παρακαλώ επιβεβαίωσε πατώντας \"Εντάξει\":");
            this.Choices = new Choice[1] 
            {
                new Choice("👍 Εντάξει") { Synonyms = new List<string>(2) { "οκ", "ok" } }
            };
        }

        public ConfirmPromptOptions(string promptText) : this()
        {
            this.Prompt = MessageFactory.Text(promptText);
        }
    }
}
