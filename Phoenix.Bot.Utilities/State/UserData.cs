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
    }

    public static class UserDataExtensions
    {
        public static async Task RefreshAsync(this UserData me,
            UserConnection? userConnection, ApplicationUserManager userManager)
        {
            bool wasConnected = me.IsConnected;
            me.IsConnected = userConnection is not null && userConnection.ActivatedAt.HasValue;

            if (me.IsConnected)
            {
                me.AppUser = await userManager.FindByIdAsync(userConnection!.TenantId.ToString());
                me.PhoenixUser = userConnection.Tenant;

                var userRoles = await userManager.GetRoleRanksAsync(me.AppUser);
                me.IsBackend = userRoles.Any(rr => rr.IsBackend());

                if (!wasConnected)
                    me.SelectedRole = null;
            }
        }
    }
}
