using System;
using System.Globalization;
using System.Linq;

namespace Phoenix.Bot.Utilities.Linguistic
{
    public static class CommandHandle
    {
        public static bool TryGetCommand(string text, out Command cmd)
        {
            cmd = text switch
            {
                "--get-started--"   => Command.GetStarted,

                "--greeting--"      => Command.Greeting,
                "--home--"          => Command.Home,
                "--feedback--"      => Command.Feedback,
                "--cancel--"        =>Command.Cancel,

                "--help--"          => Command.Help,
                "--exercises--"     => Command.Exercises,
                "--exams--"         => Command.Exams,
                "--schedule"        => Command.Schedule,

                _                   => Command.NoCommand
            };

            return cmd > 0;
        }

        public static bool TryInferCommand(string text, out Command cmd)
        {
            cmd = Command.NoCommand;
            var words = text.Split(' ');

            var cmdNames = Enum.GetNames(typeof(Command));
            foreach (var cmdName in cmdNames)
            {
                var cmdSynonyms = typeof(Synonyms).GetField(cmdName)?.GetValue(null) as string[];
                if (cmdSynonyms == null)
                    continue;

                bool containsSynonyms = words.Any(w => cmdSynonyms.
                    Any(s => s.IsTheSameWith(w, CultureInfo.CurrentCulture, CompareOptions.IgnoreNonSpace | CompareOptions.IgnoreCase)));

                if (containsSynonyms)
                {
                    cmd = (Command)Enum.Parse(typeof(Command), cmdName);
                    break;
                }
            }

            return cmd > 0;
        }

        public static bool IsCommand(string text) => text.StartsWith("--") && text.EndsWith("--");
    }
}
