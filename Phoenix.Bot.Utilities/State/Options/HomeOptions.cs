using Newtonsoft.Json;
using Phoenix.Bot.Utilities.Actions;
using Phoenix.DataHandle.Main;

namespace Phoenix.Bot.Utilities.State.Options
{
    public class HomeOptions : UserOptions
    {
        public BotAction Action { get; set; }

        [JsonConstructor]
        public HomeOptions(int userId, Role[] userRoles)
             : base(userId, userRoles) { }

        public HomeOptions(UserOptions userOptions)
            : this(userOptions.UserId, userOptions.UserRoles) { }
    }
}
