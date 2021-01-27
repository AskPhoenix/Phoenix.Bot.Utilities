using Microsoft.Bot.Builder.Dialogs;
using Phoenix.Bot.Utilities.Dialogs.Prompts;

namespace Phoenix.Bot.Utilities.Dialogs
{
    public static class PromptNames
    {
        public const string Phone = nameof(Phone) + nameof(NumberPrompt<int>); // generic type T is not included
        public const string Code = nameof(Code) + nameof(NumberPrompt<int>);
        public const string HiddenChoices = nameof(HiddenChoices) + nameof(UnaccentedChoicePrompt);
    }
}
