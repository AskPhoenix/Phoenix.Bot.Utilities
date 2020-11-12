using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Phoenix.Bot.Utilities.Dialogs
{
    public static class PromptValidators
    {
        public static Task<bool> PhoneNumberPromptValidator(PromptValidatorContext<long> promptContext, CancellationToken _)
        {
            return Task.FromResult(
                promptContext.Recognized.Succeeded &&
                promptContext.Recognized.Value > 0 &&
                (Math.Ceiling(Math.Log10(promptContext.Recognized.Value)) == 10 && promptContext.Recognized.Value / 100000000 == 69) ||
                (Math.Ceiling(Math.Log10(promptContext.Recognized.Value)) == 12 && promptContext.Recognized.Value / 100000000 == 3069));
        }

        public static Task<bool> PinPromptValidator(PromptValidatorContext<int> promptContext, CancellationToken _)
        {
            //TODO: Take TestPin from appsettings
            int digits = Convert.ToInt32(promptContext.Options.Validations);
            return Task.FromResult(promptContext.Recognized.Succeeded &&
                ((int)Math.Ceiling(Math.Log10(promptContext.Recognized.Value)) == digits || promptContext.Recognized.Value == 15422198));
        }
    }
}
