using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Dialogs.Choices;

namespace Phoenix.Bot.Utilities.Dialogs.Prompts.Options
{
    public class NavigationPromptOptions : PromptOptions
    {
        public const string Previous = "⤴️ Προηγούμενο";
        public const string Next = "⤵️ Επόμενο";
        public const string Completion = "⌛ Ολοκλήρωση";

        public NavigationPromptOptions(string? promptText = null, bool hasPrevious = true, bool hasNext = true)
            : base()
        {
            if (string.IsNullOrWhiteSpace(promptText))
                promptText = "Επίλεξε «Επόμενο» για να συνεχίσουμε:";

            Prompt = MessageFactory.Text(promptText);
            RetryPrompt = MessageFactory.Text("Παρακαλώ επίλεξε πώς επιθυμείς να συνεχίσουμε:");
            Choices = new List<Choice>(3)
            {
                new(Completion)
            };

            if (hasPrevious)
                Choices.Add(new(Previous));
            if (hasNext)
                Choices.Add(new(Next));
        }
    }
}
