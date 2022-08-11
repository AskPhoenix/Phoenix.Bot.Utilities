using Phoenix.Bot.Utilities.Actions;

namespace Phoenix.Bot.Utilities.Linguistic
{
    public enum Command
    {
        NoCommand = 0,

        // Channel related: [10, 20)
        GetStarted = CommandTopics.ChannelCommandsBase,

        // General: [20, 30)
        Greeting = CommandTopics.GeneralCommandsBase,
        Home,
        Cancel,
        Reset,
        Logout,
        
        // Action related: [30, 40)
        Exercises = CommandTopics.ActionCommandsBase,
        Exams,
        Schedule,
        Help,
        Feedback
    }

    public static class CommandTopics
    {
        public const int ChannelCommandsBase = 10;
        public const int GeneralCommandsBase = 20;
        public const int ActionCommandsBase = 30;
    }

    public static class CommandExtensions
    {
        public static bool IsChannelCommand(this Command me) =>
            (int)me >= CommandTopics.ChannelCommandsBase && (int)me < CommandTopics.GeneralCommandsBase;
        public static bool IsGeneralCommand(this Command me) =>
            (int)me >= CommandTopics.GeneralCommandsBase && (int)me < CommandTopics.ActionCommandsBase;
        public static bool IsActionCommand(this Command me) =>
            (int)me >= CommandTopics.ActionCommandsBase;

        public static BotAction ToBotAction(this Command me)
        {
            if (!me.IsActionCommand())
                return BotAction.NoAction;

            return (BotAction)(me - CommandTopics.ActionCommandsBase + 1);
        }
    }
}
