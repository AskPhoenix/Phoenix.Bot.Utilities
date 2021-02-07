using Phoenix.Bot.Utilities.Actions;

namespace Phoenix.Bot.Utilities.State.Options
{
    public class HomeOptions
    {
        public int UserId { get; set; }
        public BotAction Action { get; set; }
    }
}
