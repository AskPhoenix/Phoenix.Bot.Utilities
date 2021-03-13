using Newtonsoft.Json;
using Phoenix.DataHandle.Main;

namespace Phoenix.Bot.Utilities.State.Options
{
    public class UserOptions
    {
        public int UserId { get; }
        public Role UserRole { get; }

        [JsonConstructor]
        public UserOptions(int userId, Role userRole)
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
