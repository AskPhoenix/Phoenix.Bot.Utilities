using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Phoenix.Bot.Utilities.Dialogs.Prompts
{
    public static class PromptValidators
    {
        public static Task<bool> PhoneNumberPromptValidator(PromptValidatorContext<long> promptContext, CancellationToken _)
        {
            long result = promptContext.Recognized.Value;

            return Task.FromResult(
                promptContext.Recognized.Succeeded &&
                result > 0 &&
                (Math.Ceiling(Math.Log10(result)) == 10 && result / 100000000 == 69) ||
                (Math.Ceiling(Math.Log10(result)) == 12 && result / 100000000 == 3069));
        }

        public static Task<bool> CodePromptValidator(PromptValidatorContext<string> promptContext, CancellationToken _)
        {
            if (!(promptContext.Options.Validations is string))
                return Task.FromResult(false);

            string result = promptContext.Recognized.Value;
            string validationType = promptContext.Options.Validations as string;

            if (validationType == "pin")
                return Task.FromResult(
                    promptContext.Recognized.Succeeded &&
                    result.Length <= 9 &&
                    result.All(c => char.IsDigit(c)));
            else
                return Task.FromResult(
                    promptContext.Recognized.Succeeded &&
                    result.Substring(0, 2).All(c => char.IsLetter(c)) &&
                    result[2..].Length <= 9 &&
                    result[2..].All(c => char.IsDigit(c)));
        }

        public static Task<bool> HiddenChoicesValidator(PromptValidatorContext<string> promptContext, CancellationToken _)
        {
            if (promptContext.Recognized.Succeeded)
                return Task.FromResult(true);

            if (!(promptContext.Options.Validations is IList<string> hiddenChoices))
                return Task.FromResult(false);

            int i = hiddenChoices.IndexOf(promptContext.Context.Activity.Text);
            if (i >= 0)
                promptContext.Recognized.Value = (promptContext.Options.Choices.Count() + i).ToString();

            return Task.FromResult(i >= 0);
        }
    }
}
