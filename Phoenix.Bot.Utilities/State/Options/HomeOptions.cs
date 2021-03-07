using Phoenix.Bot.Utilities.Actions;
using Phoenix.DataHandle.Main;

namespace Phoenix.Bot.Utilities.State.Options
{
    public class HomeOptions : UserOptions
    {
        public BotAction Action { get; set; }

        public HomeOptions(int userId, Role userRole)
             : base(userId, userRole) { }

        public HomeOptions(UserOptions userOptions)
            : this(userOptions.UserId, userOptions.UserRole) { }
    }
}
