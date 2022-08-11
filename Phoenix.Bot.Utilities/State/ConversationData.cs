using Phoenix.Bot.Utilities.Linguistic;
using Phoenix.DataHandle.Main.Models;

namespace Phoenix.Bot.Utilities.State
{
    public class ConversationData
    {
        public School School { get; set; } = null!;
        public string? Locale { get; set; }
        public Command Command { get; set; }
    }
}
