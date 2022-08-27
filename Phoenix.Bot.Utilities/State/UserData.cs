using Newtonsoft.Json;
using Phoenix.Bot.Utilities.Errors;
using Phoenix.DataHandle.Identity;
using Phoenix.DataHandle.Main.Models;
using Phoenix.DataHandle.Main.Types;
using Phoenix.DataHandle.Repositories;

namespace Phoenix.Bot.Utilities.State
{
    public class UserData
    {
        public bool IsConnected { get; set; }
        public int? UserId { get; set; }
        public bool IsBackend { get; set; }
        public RoleRank? SelectedRole { get; set; }

        [JsonIgnore]
        public User PhoenixUser { get; private set; } = null!;
        [JsonIgnore]
        public ApplicationUser AppUser { get; private set; } = null!;

        public async Task RefreshAsync(UserRepository userRepository, ApplicationUserManager userManager)
        {
            if (!this.UserId.HasValue)
                return;

            var user = await userRepository.FindPrimaryAsync(this.UserId.Value);
            if (user is null)
                throw new BotException(BotError.UserNotValid);

            this.PhoenixUser = user;
            this.AppUser = await userManager.FindByIdAsync(this.UserId.ToString());
        }

        public async Task RefreshAsync(UserConnection? userConnection, ApplicationUserManager userManager)
        {
            bool wasConnected = this.IsConnected;
            this.IsConnected = userConnection is not null && userConnection.ActivatedAt.HasValue;

            if (this.IsConnected)
            {
                this.UserId = userConnection!.TenantId;
                this.AppUser = await userManager.FindByIdAsync(userConnection.TenantId.ToString());
                this.PhoenixUser = userConnection.Tenant;

                var userRoles = await userManager.GetRoleRanksAsync(this.AppUser);
                this.IsBackend = userRoles.Any(rr => rr.IsBackend());

                if (!wasConnected)
                    this.SelectedRole = null;
            }
        }
    }
}
