using Microsoft.Bot.Schema;
using System;

namespace Phoenix.Bot.Utilities.Miscellaneous
{
    public static class ProviderExtensions
    {
        public static Tuple<string, string> GetProviderInfo(this Activity activity)
        {
            return new Tuple<string, string>(activity.ChannelId, activity.From.Id);
        }
    }
}
