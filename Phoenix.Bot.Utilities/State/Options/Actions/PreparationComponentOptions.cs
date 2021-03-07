using Phoenix.DataHandle.Main;
using Phoenix.DataHandle.Main.Models;

namespace Phoenix.Bot.Utilities.State.Options.Actions
{
    public class PreparationComponentOptions : UserOptions
    {
        public AspNetUsers User { get; }

        public PreparationComponentOptions(AspNetUsers user, Role userRole)
            : base(user?.Id ?? 0, userRole)
        {
            this.User = user;
        }

        public PreparationComponentOptions(AspNetUsers user, UserOptions userOptions)
            : this(user, userOptions.UserRole) { }
    }
}
