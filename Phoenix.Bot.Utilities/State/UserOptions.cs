namespace Phoenix.Bot.Utilities.State
{
    public struct UserOptions
    {
        public bool IsAuthenticated { get; set; }
        public bool HasAcceptedTerms { get; set; }
        public int SmsCount { get; set; }
        public int Role { get; set; }
    }

    public static class UserOptionsDefaults
    {
        public const string PropertyName = "Options";
        public const int MaxSmsNumber = 5;
    }
}
