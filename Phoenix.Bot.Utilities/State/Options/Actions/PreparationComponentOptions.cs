using Phoenix.DataHandle.Main;
using Phoenix.DataHandle.Main.Models;
using System.Collections.Generic;

namespace Phoenix.Bot.Utilities.State.Options.Actions
{
    public class PreparationComponentOptions : UserOptions
    {
        public AspNetUsers User { get; }
        public Dictionary<int, string> Selectables { get; set; }
        public bool IsAffiliatedUser { get; set; } = false;

        public PreparationComponentOptions(AspNetUsers user, Role userRole)
            : base(user?.Id ?? 0, userRole)
        {
            this.User = user;
        }

        public PreparationComponentOptions(AspNetUsers user, UserOptions userOptions)
            : this(user, userOptions.UserRole) { }
    }
}
