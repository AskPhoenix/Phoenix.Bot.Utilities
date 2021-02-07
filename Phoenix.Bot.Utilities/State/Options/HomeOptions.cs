using Phoenix.Bot.Utilities.Actions;
using Phoenix.DataHandle.Main;

namespace Phoenix.Bot.Utilities.State.Options
{
    public class HomeOptions
    {
        public int UserId { get; set; }
        public Role UserRole { get; set; }
        public BotAction Action { get; set; }
    }
}
