using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Dialogs.Choices;
using Phoenix.Bot.Utilities.Linguistic;
using Phoenix.Bot.Utilities.Miscellaneous;

namespace Phoenix.Bot.Utilities.Dialogs.Prompts
{
    public static class PromptValidators
    {
        public static Task<bool> PhoneNumberPromptValidator(PromptValidatorContext<long> promptCtx,
            CancellationToken canTkn = default)
        {
            long result = promptCtx.Recognized.Value;

            return Task.FromResult(
                promptCtx.Recognized.Succeeded &&
                result > 0 &&
                Math.Ceiling(Math.Log10(result)) == 10 && result / 100000000 == 69 ||
                (Math.Ceiling(Math.Log10(result)) == 12 && result / 100000000 == 3069));
        }

        public static Task<bool> VerificationCodePromptValidator(PromptValidatorContext<string> promptCtx,
            CancellationToken canTkn = default)
        {
            string result = promptCtx.Recognized.Value;

            return Task.FromResult(
                promptCtx.Recognized.Succeeded &&
                result.Length <= 9 &&
                result.All(c => char.IsDigit(c)));
        }

        public static Task<bool> IdentificationCodePromptValidator(PromptValidatorContext<string> promptCtx,
            CancellationToken canTkn = default)
        {
            string result = promptCtx.Recognized.Value;
            return Task.FromResult(
                promptCtx.Recognized.Succeeded &&
                result.Length <= 9 &&
                result.TakeWhile(c => char.IsLetter(c)).Count() == 2 &&
                result.SkipWhile(c => char.IsLetter(c)).All(c => char.IsDigit(c)));
        }

        public static Task<bool> HiddenChoicesValidator(PromptValidatorContext<FoundChoice> promptCtx,
            CancellationToken canTkn = default)
        {
            if (promptCtx.Recognized.Succeeded)
                return Task.FromResult(true);

            if (promptCtx.Options.Validations is not IList<string> hiddenChoices)
                return Task.FromResult(false);

            int i = hiddenChoices.IndexOf(promptCtx.Context.Activity.Text);
            if (i >= 0)
                promptCtx.Recognized.Value = new FoundChoice()
                {
                    Index = promptCtx.Options.Choices.Count + i,
                    Value = promptCtx.Context.Activity.Text
                };

            return Task.FromResult(i >= 0);
        }

        public static Task<bool> CustomDateTimePromptValidator(
            PromptValidatorContext<IList<DateTimeResolution>> promptCtx,
            CancellationToken canTkn = default)
        {
            if (promptCtx.Recognized.Succeeded)
                return Task.FromResult(true);
            
            string text = promptCtx.Context.Activity.Text;
            if (string.IsNullOrEmpty(text))
                return Task.FromResult(false);

            //TODO: Use locale
            //TODO: Προσοχή με το ToUpperInvariant()
            text = text.ToUnaccented().ToUpper();
            return Task.FromResult(text is "ΧΘΕΣ" || text is "ΣΗΜΕΡΑ" || text is "ΑΜΕΣΩΣ" || text is "ΑΥΡΙΟ");
        }

        public static async Task<bool> FutureDateTimePromptValidator(
            PromptValidatorContext<IList<DateTimeResolution>> promptCtx,
            CancellationToken canTkn = default)
        {
            bool tore = await CustomDateTimePromptValidator(promptCtx);

            var text = promptCtx.Context.Activity.Text.ToUnaccented().ToUpper();
            tore &= text != "ΧΘΕΣ";

            if (promptCtx.Recognized.Succeeded)
            {
                var res = ResolveHelper.ResolveDateTime(promptCtx.Recognized.Value);
                tore &= res.Date >= DateTimeOffset.UtcNow.Date;
            }

            return tore;
        }
    }
}
