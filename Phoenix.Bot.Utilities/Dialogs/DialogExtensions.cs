using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;
using Phoenix.DataHandle.Main.Types;

namespace Phoenix.Bot.Utilities.Dialogs
{
    public static class DialogExtensions
    {
        public static ChannelProvider GetProvider(this ITurnContext turnContext)
        {
            return turnContext.Activity.ChannelId.ToChannelProvider();
        }

        public static ChannelProvider GetProvider(this WaterfallStepContext stepContext)
        {
            return GetProvider(stepContext.Context);
        }

        public static string GetProviderKey(this ITurnContext turnContext)
        {
            return turnContext.Activity.From.Id;
        }

        public static string GetProviderKey(this WaterfallStepContext stepContext)
        {
            return GetProviderKey(stepContext.Context);
        }

        public static string GetRecipientKey(this ITurnContext turnContext)
        {
            return turnContext.Activity.Recipient.Id;
        }

        public static string GetRecipientKey(this WaterfallStepContext stepContext)
        {
            return GetRecipientKey(stepContext.Context);
        }
    }
}
