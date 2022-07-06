using Newtonsoft.Json;
using Phoenix.Bot.Utilities.Actions;
using Phoenix.DataHandle.Main.Types;

namespace Phoenix.Bot.Utilities.State.Options
{
    public class HomeOptions : UserOptions
    {
        public BotAction Action { get; set; }

        [JsonConstructor]
        public HomeOptions(int userId, RoleRank userRole)
             : base(userId, userRole) { }

        public HomeOptions(UserOptions userOptions)
            : this(userOptions.UserId, userOptions.UserRole) { }
    }
}
