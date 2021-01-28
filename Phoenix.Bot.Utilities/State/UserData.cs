using Phoenix.DataHandle.Main;

namespace Phoenix.Bot.Utilities.State
{
    public struct UserData
    {
        public bool IsAuthenticated { get; set; }
        public bool HasAcceptedTerms { get; set; }
        public int SmsCount { get; set; }
        public Role Role { get; set; }
        public int LoginAttempts { get; set; }
    }

    public static class UserDataDefaults
    {
        public const uint MaxSmsNumber = 5;
        public const uint MaxLoginAttempts = 5;
    }
}
