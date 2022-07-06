﻿using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Dialogs.Choices;
using Phoenix.Bot.Utilities.Linguistic;
using Phoenix.Bot.Utilities.Miscellaneous;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phoenix.Bot.Utilities.Dialogs.Prompts
{
    public static class PromptValidators
    {
        public static Task<bool> PhoneNumberPromptValidator(PromptValidatorContext<long> promptContext)
        {
            long result = promptContext.Recognized.Value;

            return Task.FromResult(
                promptContext.Recognized.Succeeded &&
                result > 0 &&
                Math.Ceiling(Math.Log10(result)) == 10 && result / 100000000 == 69 ||
                (Math.Ceiling(Math.Log10(result)) == 12 && result / 100000000 == 3069));
        }

        public static Task<bool> PinPromptValidator(PromptValidatorContext<string> promptContext)
        {
            string result = promptContext.Recognized.Value;
            return Task.FromResult(
                promptContext.Recognized.Succeeded &&
                result.Length <= 9 &&
                result.All(c => char.IsDigit(c)));
        }

        public static Task<bool> HiddenChoicesValidator(PromptValidatorContext<FoundChoice> promptContext)
        {
            if (promptContext.Recognized.Succeeded)
                return Task.FromResult(true);

            if (promptContext.Options.Validations is not IList<string> hiddenChoices)
                return Task.FromResult(false);

            int i = hiddenChoices.IndexOf(promptContext.Context.Activity.Text);
            if (i >= 0)
                promptContext.Recognized.Value = new FoundChoice()
                {
                    Index = promptContext.Options.Choices.Count + i,
                    Value = promptContext.Context.Activity.Text
                };

            return Task.FromResult(i >= 0);
        }

        public static Task<bool> CustomDateTimePromptValidator(
            PromptValidatorContext<IList<DateTimeResolution>> promptContext)
        {
            if (promptContext.Recognized.Succeeded)
                return Task.FromResult(true);
            
            string text = promptContext.Context.Activity.Text;
            if (string.IsNullOrEmpty(text))
                return Task.FromResult(false);

            //TODO: Use locale
            //TODO: Προσοχή με το ToUpperInvariant()
            text = text.ToUnaccented().ToUpper();
            return Task.FromResult(text is "ΧΘΕΣ" || text is "ΣΗΜΕΡΑ" || text is "ΑΜΕΣΩΣ" || text is "ΑΥΡΙΟ");
        }

        public static async Task<bool> FutureDateTimePromptValidator(
            PromptValidatorContext<IList<DateTimeResolution>> promptContext)
        {
            bool tore = await CustomDateTimePromptValidator(promptContext);

            var text = promptContext.Context.Activity.Text.ToUnaccented().ToUpper();
            tore &= text != "ΧΘΕΣ";

            if (promptContext.Recognized.Succeeded)
            {
                var res = CalendarExtensions.ResolveDateTime(promptContext.Recognized.Value);
                tore &= res.Date >= DateTimeOffset.UtcNow.Date;
            }

            return tore;
        }
    }
}
