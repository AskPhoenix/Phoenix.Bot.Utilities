﻿using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Dialogs.Choices;
using Phoenix.DataHandle.Utilities;

namespace Phoenix.Bot.Utilities.Dialogs.Prompts
{
    public class UnaccentedChoicePrompt : ChoicePrompt
    {
        public UnaccentedChoicePrompt(string dialogId,
            PromptValidator<FoundChoice>? validator = null, string? defaultLocale = null)
            : base(dialogId, validator, defaultLocale) { }

        public UnaccentedChoicePrompt(string dialogId,
            Dictionary<string, ChoiceFactoryOptions> choiceDefaults,
            PromptValidator<FoundChoice>? validator = null, string? defaultLocale = null)
            : base(dialogId, choiceDefaults, validator, defaultLocale) { }

        protected override Task<PromptRecognizerResult<FoundChoice>> OnRecognizeAsync(
            ITurnContext turnContext, IDictionary<string, object> state, PromptOptions options,
            CancellationToken cancellationToken = default)
        {
            //Adds the unaccented version of every choice after removing any potential emojis as its synonym
            //If there are synonyms, their unaccented version (without checking for emojis) is also stored
            for (int i = 0; i < options.Choices.Count; i++)
            {
                if (options.Choices[i].Synonyms != null)
                {
                    int startLength = options.Choices[i].Synonyms.Count;
                    var unaccentedSynonyms = new List<string>(startLength);

                    for (int j = 0; j < startLength; j++)
                    {
                        string unaccentedSynonym = options.Choices[i].Synonyms[j].ToUnaccented();
                        if (unaccentedSynonym != options.Choices[i].Synonyms[j])
                            unaccentedSynonyms.Add(unaccentedSynonym);
                    }

                    options.Choices[i].Synonyms.AddRange(unaccentedSynonyms);
                }
                else
                    options.Choices[i].Synonyms = new List<string>();

                //Remove any emojis
                string noEmojiChoice = options.Choices[i].Value.RemoveEmojis();
                string unaccentedChoice = noEmojiChoice.ToUnaccented();
                if (noEmojiChoice != options.Choices[i].Value)
                    options.Choices[i].Synonyms.Add(noEmojiChoice);
                if (unaccentedChoice != options.Choices[i].Value)
                    options.Choices[i].Synonyms.Add(unaccentedChoice);
            }

            return base.OnRecognizeAsync(turnContext, state, options, cancellationToken);
        }
    }
}
