using Phoenix.DataHandle.Main;

namespace Phoenix.Bot.Utilities.State
{
    public struct UserData
    {
        public int SmsCount { get; set; }
        public Role SelectedTesterRole { get; set; }
        public int LoginAttempts { get; set; }
    }

    public static class UserDataDefaults
    {
        public const uint MaxSmsNumber = 5;
        public const uint MaxLoginAttempts = 5;
    }
}
