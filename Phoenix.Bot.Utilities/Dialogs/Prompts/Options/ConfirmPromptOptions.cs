using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Dialogs.Choices;

namespace Phoenix.Bot.Utilities.Dialogs.Prompts.Options
{
    public class ConfirmPromptOptions : PromptOptions
    {
        public ConfirmPromptOptions() : base()
        {
            RetryPrompt = MessageFactory.Text("Παρακαλώ επιβεβαίωσε πατώντας \"Εντάξει\":");
            Choices = new Choice[1]
            {
                new("👍 Εντάξει") { Synonyms = new(2) { "οκ", "ok" } }
            };
        }

        public ConfirmPromptOptions(string promptText) : this()
        {
            Prompt = MessageFactory.Text(promptText);
        }
    }
}
