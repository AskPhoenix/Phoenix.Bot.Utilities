using Microsoft.Bot.Builder.Dialogs;

namespace Phoenix.Bot.Utilities.Dialogs.Prompts
{
    public static class PromptNames
    {
        public const string Phone = nameof(Phone) + nameof(NumberPrompt<int>); // generic type T is not included in the name
        public const string VerificationCode = nameof(VerificationCode) + nameof(TextPrompt);
        public const string IdentificationCode = nameof(IdentificationCode) + nameof(TextPrompt);
        public const string HiddenChoices = nameof(HiddenChoices) + nameof(UnaccentedChoicePrompt);
    }
}
