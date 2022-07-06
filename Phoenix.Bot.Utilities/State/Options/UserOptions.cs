using Newtonsoft.Json;
using Phoenix.DataHandle.Main.Types;

namespace Phoenix.Bot.Utilities.State.Options
{
    public class UserOptions
    {
        public int UserId { get; }
        public RoleRank UserRole { get; }

        [JsonConstructor]
        public UserOptions(int userId, RoleRank userRole)
        {
            this.UserId = userId;
            this.UserRole = userRole;
        }

        public UserOptions(UserOptions userOptions)
            : this(userOptions.UserId, userOptions.UserRole) { }

        public UserOptions GetUserOptions()
        {
            return new UserOptions(this.UserId, this.UserRole);
        }
    }
}
