using Newtonsoft.Json;
using Phoenix.DataHandle.Main;

namespace Phoenix.Bot.Utilities.State.Options
{
    public class UserOptions
    {
        public int UserId { get; }
        public Role[] UserRoles { get; }

        [JsonConstructor]
        public UserOptions(int userId, Role[] userRoles)
        {
            this.UserId = userId;
            this.UserRoles = userRoles;
        }

        public UserOptions(UserOptions userOptions)
            : this(userOptions.UserId, userOptions.UserRoles) { }

        public UserOptions GetUserOptions()
        {
            return new UserOptions(this.UserId, this.UserRoles);
        }
    }
}
