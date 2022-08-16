namespace Phoenix.Bot.Utilities.Errors
{
    public class BotException : Exception
    {
        public BotError Error { get; }
        public string Solution { get; }
        public string Code { get; }
        public bool ShowMessageOnly { get; set; }

        public BotException()
            : this(BotError.Unknown)
        {
        }

        public BotException(BotError botError, bool showMessageOnly = false)
            : base($"{botError.GetMessage()}")
        {
            this.Error = botError;
            this.Solution = botError.GetSolution();
            this.Code = ((int)botError).ToString("0000");
            this.ShowMessageOnly = showMessageOnly;
        }
    }
}
