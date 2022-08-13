namespace Phoenix.Bot.Utilities.Errors
{
    public class BotException : Exception
    {
        public BotError Error { get; }
        public string Solution { get; }
        public string Code { get; }

        public BotException()
            : this(BotError.Unknown)
        {
        }

        public BotException(BotError botError)
            : base($"{botError.GetMessage()}")
        {
            this.Error = botError;
            this.Solution = botError.GetSolution();
            this.Code = ((int)botError).ToString("0000");
        }
    }
}
