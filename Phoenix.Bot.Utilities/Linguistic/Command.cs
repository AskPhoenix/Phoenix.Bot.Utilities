using Phoenix.Bot.Utilities.Actions;
using Phoenix.DataHandle.Utilities;
using Phoenix.Language.Bot.Types.Command;

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

        public static Command[] AllCommands => Enum.GetValues<Command>();
        public static Command[] ChannelCommands => AllCommands.Where(c => c.IsChannelCommand()).ToArray();
        public static Command[] GeneralCommands => AllCommands.Where(c => c.IsGeneralCommand()).ToArray();
        public static Command[] ActionCommands => AllCommands.Where(c => c.IsActionCommand()).ToArray();

        public static BotAction ToBotAction(this Command me)
        {
            if (!me.IsActionCommand())
                return BotAction.NoAction;

            return (BotAction)(me - CommandTopics.ActionCommandsBase + 1);
        }

        public static string ToNormalizedString(this Command me)
        {
            return $"__{me.ToString().ToLower()}__";
        }

        public static string[] GetSynonyms(this Command me)
        {
            string synonymsStr = me switch
            {
                Command.Greeting    => SynonymsResources.Greeting,
                Command.Home        => SynonymsResources.Home,
                Command.Cancel      => SynonymsResources.Cancel,
                Command.Reset       => SynonymsResources.Reset,
                Command.Logout      => SynonymsResources.Logout,
                Command.Exercises   => SynonymsResources.Exercises,
                Command.Exams       => SynonymsResources.Exams,
                Command.Schedule    => SynonymsResources.Schedule,
                Command.Help        => SynonymsResources.Help,
                Command.Feedback    => SynonymsResources.Feedback,
                _                   => string.Empty
            };

            if (string.IsNullOrEmpty(synonymsStr))
                return Array.Empty<string>();

            return synonymsStr.Split(
                ',', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
        }

        public static bool IsCommandFormatted(this string me) =>
            me.StartsWith("__") && me.EndsWith("__") && me.Length > 4;

        public static Command InferCommand(this string me)
        {
            string newMe = me.RemoveEmojis(postTrim: true);

            if (newMe.IsCommandFormatted() && Enum.TryParse(newMe.Trim('_'), ignoreCase: true, out Command cmdF))
                return cmdF;

            foreach (var cmd in AllCommands)
                if (cmd.GetSynonyms().Any(s => s.Equals(newMe, StringComparison.InvariantCultureIgnoreCase)))
                    return cmd;

            return Command.NoCommand;
        }
    }
}
