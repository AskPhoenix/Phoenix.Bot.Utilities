using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Dialogs.Choices;
using Phoenix.Bot.Utilities.Dialogs.Helpers;
using Phoenix.Bot.Utilities.Linguistic;
using System.Text.RegularExpressions;

#pragma warning disable IDE0060

namespace Phoenix.Bot.Utilities.Dialogs.Prompts
{
    public static class PromptValidators
    {
        public static Task<bool> PhonePromptValidator(PromptValidatorContext<string> promptCtx,
            CancellationToken canTkn = default)
        {
            var phone = promptCtx.Recognized.Value.Replace(" ", "");
            var regex = new Regex(@"^\+?\d{1,15}$");

            return Task.FromResult(
                promptCtx.Recognized.Succeeded && regex.IsMatch(phone));
        }

        public static Task<bool> CodePromptValidator(PromptValidatorContext<string> promptCtx,
            CancellationToken canTkn = default)
        {
            string result = promptCtx.Recognized.Value;

            return Task.FromResult(
                promptCtx.Recognized.Succeeded &&
                result.Length <= 9 &&
                result.All(c => char.IsDigit(c)));
        }

        public static Task<bool> AlphaCodePromptValidator(PromptValidatorContext<string> promptCtx,
            CancellationToken canTkn = default)
        {
            string result = promptCtx.Recognized.Value;

            var alphaPart = result.TakeWhile(c => char.IsLetter(c));
            var numPart = result.SkipWhile(c => char.IsLetter(c));

            return Task.FromResult(
                promptCtx.Recognized.Succeeded &&
                alphaPart.Any() &&
                numPart.All(c => char.IsDigit(c)) &&
                numPart.Count() <= 9);
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

            bool isDateLiteral = text.TryToDateLiteral(out DateLiteral dateLiteral);

            return Task.FromResult(isDateLiteral && dateLiteral != DateLiteral.Never);
        }

        public static async Task<bool> FutureDateTimePromptValidator(
            PromptValidatorContext<IList<DateTimeResolution>> promptCtx,
            CancellationToken canTkn = default)
        {
            string text = promptCtx.Context.Activity.Text;

            bool tore = await CustomDateTimePromptValidator(promptCtx, canTkn);

            bool isDateLiteral = text.TryToDateLiteral(out DateLiteral dateLiteral);
            if (isDateLiteral)
                tore &= dateLiteral > 0;
            else
            {
                var res = ResolveHelper.ResolveDateTime(promptCtx.Recognized.Value);
                tore &= res.Date >= DateTimeOffset.UtcNow.Date;
            }

            return tore;
        }
    }
}
