using Phoenix.DataHandle.Identity;
using Phoenix.DataHandle.Main.Models;
using Phoenix.DataHandle.Main.Types;

namespace Phoenix.Bot.Utilities.State
{
    public class UserData
    {
        public bool IsConnected { get; set; }

        public ApplicationUser? AppUser { get; set; }
        public User? PhoenixUser { get; set; }
        public bool IsBackend { get; set; }
        public RoleRank? SelectedRole { get; set; }
        public School School { get; set; } = null!;
    }
}
