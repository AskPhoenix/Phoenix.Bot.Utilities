namespace Phoenix.Bot.Utilities.State
{
    public struct UserOptions
    {
        public const int MaxSmsNumber = 5;

        public bool IsAuthenticated { get; set; }
        public bool HasAcceptedTerms { get; set; }
        public int SmsCount { get; set; }
        public int Role { get; set; }
    }
}
