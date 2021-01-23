using Phoenix.Bot.Utilities.Linguistic;

namespace Phoenix.Bot.Utilities.State
{
    public struct ConversationData
    {
        public string Locale { get; set; }
        public Command Command { get; set; }
    }
}
