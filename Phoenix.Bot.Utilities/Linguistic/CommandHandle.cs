using System;
using System.Globalization;
using System.Linq;

namespace Phoenix.Bot.Utilities.Linguistic
{
    public static class CommandHandle
    {
        //TODO: Deprecated
        public static bool TryGetCommand(string text, out Command cmd)
        {
            cmd = text switch
            {
                "--get-started--"   => Command.GetStarted,

                "--greeting--"      => Command.Greeting,
                "--home--"          => Command.Home,
                "--cancel--"        => Command.Cancel,
                "--reset--"         => Command.Reset,
                "--logout--"        => Command.Logout,

                "--exercises--"     => Command.Exercises,
                "--exams--"         => Command.Exams,
                "--schedule"        => Command.Schedule,
                "--help--"          => Command.Help,
                "--feedback--"      => Command.Feedback,

                _ => Command.NoCommand
            };

            return cmd > 0;
        }

        public static bool TryInferCommand(string text, out Command cmd)
        {
            string trimmedText = text.RemoveEmojis();
            cmd = Command.NoCommand;
            
            var cmdNames = Enum.GetNames(typeof(Command));
            foreach (var cmdName in cmdNames)
            {
                var cmdSynonyms = typeof(Synonyms).GetField(cmdName)?.GetValue(null) as string[];
                if (cmdSynonyms == null)
                    continue;
                
                if (cmdSynonyms.Any(s => s.IsTheSameWith(text, CultureInfo.CurrentCulture, CompareOptions.IgnoreNonSpace | CompareOptions.IgnoreCase)))
                {
                    cmd = (Command)Enum.Parse(typeof(Command), cmdName);
                    break;
                }
            }

            return cmd > 0;
        }

        //TODO: Deprecated
        public static bool IsCommand(string text) => text.StartsWith("--") && text.EndsWith("--");
    }
}
