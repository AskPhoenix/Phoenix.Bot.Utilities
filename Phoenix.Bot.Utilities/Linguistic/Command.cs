namespace Phoenix.Bot.Utilities.Linguistic
{
    public enum Command
    {
        NoCommand = 0,

        // Channel related: [10, 20)
        GetStarted = CommandAttributes.ChannelCommandsBase,

        // General: [20, 30)
        Greeting = CommandAttributes.GeneralCommandsBase,
        Home,
        Cancel,
        Reset,
        Logout,
        
        // Action related: [30, 40)
        Exercises = CommandAttributes.ActionCommandsBase,
        Exams,
        Schedule,
        Help,
        Feedback
    }

    public static class CommandAttributes
    {
        public const int ChannelCommandsBase = 10;
        public const int GeneralCommandsBase = 20;
        public const int ActionCommandsBase = 30;
    }
}
