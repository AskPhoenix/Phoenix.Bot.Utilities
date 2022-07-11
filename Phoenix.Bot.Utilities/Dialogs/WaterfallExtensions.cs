using Microsoft.Bot.Builder.Dialogs;
using Phoenix.DataHandle.Main.Types;

namespace Phoenix.Bot.Utilities.Dialogs
{
    public static class WaterfallExtensions
    {
        public static ChannelProvider GetProvider(this WaterfallStepContext stepContext)
        {
            return stepContext.Context.Activity.ChannelId.ToChannelProvider();
        }

        public static string GetProviderKey(this WaterfallStepContext stepContext)
        {
            return stepContext.Context.Activity.From.Id;
        }

        public static string GetRecipientKey(this WaterfallStepContext stepContext)
        {
            return stepContext.Context.Activity.Recipient.Id;
        }
    }
}
