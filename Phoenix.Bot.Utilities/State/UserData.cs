using Phoenix.DataHandle.Identity;
using Phoenix.DataHandle.Main.Models;
using Phoenix.DataHandle.Main.Types;

namespace Phoenix.Bot.Utilities.State
{
    public struct UserData
    {
        public ApplicationUser AppUser { get; set; }
        public RoleRank SelectedRole { get; set; }
        public School School { get; set; }

        public int SmsCount { get; set; }
        public int LoginAttempts { get; set; }
        public bool RevealExtensionPassword { get; set; }
        public string TempExtensionPassword { get; set; }
    }

    public static class UserDataDefaults
    {
        public const uint MaxSmsNumber = 5;
        public const uint MaxLoginAttempts = 5;
    }
}
