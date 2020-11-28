namespace Phoenix.Bot.Utilities.State
{
    public struct UserOptions
    {
        public bool IsAuthenticated { get; set; }
        public bool HasAcceptedTerms { get; set; }
        public int SmsUsed { get; set; }
        public int Role { get; set; }
    }
}
