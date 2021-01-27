using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Dialogs.Choices;
using System.Collections.Generic;

namespace Phoenix.Bot.Utilities.Dialogs.Prompts
{
    public class NavigationPromptOptions : PromptOptions
    {
        public NavigationPromptOptions(string promptText = null, bool hasPrevious = true, bool hasNext = true) 
            : base()
        {
            if (string.IsNullOrWhiteSpace(promptText))
                promptText = "Επίλεξε «Επόμενο» για να συνεχίσουμε:";

            this.Prompt = MessageFactory.Text(promptText);
            this.RetryPrompt = MessageFactory.Text("Παρακαλώ επίλεξε πώς επιθυμείς να συνεχίσουμε:");
            this.Choices = new List<Choice>(3);
            
            if (hasNext)
                this.Choices.Add(new Choice("⤵️ Επόμενο"));
            else
                this.Choices.Add(new Choice("⌛ Ολοκλήρωση"));
            if (hasPrevious)
                this.Choices.Add(new Choice("⤴️ Προηγούμενο"));
            
            if (hasNext)
                this.Choices.Add(new Choice("🛑 Τέλος"));
        }
    }
}
