namespace Phoenix.Bot.Utilities.State
{
    public struct UserData
    {
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
