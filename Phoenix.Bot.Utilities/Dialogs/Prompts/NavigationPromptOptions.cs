using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Dialogs.Choices;
using System.Collections.Generic;

namespace Phoenix.Bot.Utilities.Dialogs.Prompts
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

            this.Prompt = MessageFactory.Text(promptText);
            this.RetryPrompt = MessageFactory.Text("Παρακαλώ επίλεξε πώς επιθυμείς να συνεχίσουμε:");
            this.Choices = new List<Choice>(3)
            {
                new(Completion)
            };

            if (hasPrevious)
                this.Choices.Add(new Choice(Previous));
            if (hasNext)
                this.Choices.Add(new Choice(Next));
        }
    }
}
