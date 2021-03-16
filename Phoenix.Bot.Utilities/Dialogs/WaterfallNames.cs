using Microsoft.Bot.Builder.Dialogs;
using Phoenix.Bot.Utilities.Actions;

namespace Phoenix.Bot.Utilities.Dialogs
{
    public static class WaterfallNames
    {
        private static string BuildWaterfallName(string name, string subname = null)
        {
            if (!string.IsNullOrEmpty(subname))
                subname = "_" + subname;

            return $"{name}{subname}_{nameof(WaterfallDialog)}";
        }

        public static class Main
        {
            public static string Top => BuildWaterfallName(nameof(Top), nameof(Main));
            public static string Role => BuildWaterfallName(nameof(Role), nameof(Main));
        }

        public static class Introduction
        {
            public static string Top => BuildWaterfallName(nameof(Top), nameof(Introduction));
        }

        public static class Auth
        {
            public static string Top => BuildWaterfallName(nameof(Top), nameof(Auth));

            public static class Credentials
            {
                public static string Phone => BuildWaterfallName(nameof(Phone), nameof(Auth));
            }

            public static class Verification
            {
                public static string SendCode => BuildWaterfallName(nameof(SendCode), nameof(Auth));
                public static string CheckCode => BuildWaterfallName(nameof(CheckCode), nameof(Auth));
            }
        }

        public static class Feedback
        {
            public static string Ask => BuildWaterfallName(nameof(Ask), nameof(Feedback));
            public static string Top => BuildWaterfallName(nameof(Top), nameof(Feedback));
            public static string Comment => BuildWaterfallName(nameof(Comment), nameof(Feedback));
            public static string Rating => BuildWaterfallName(nameof(Rating), nameof(Feedback));
        }

        public static class Help
        {
            public static string Ask => BuildWaterfallName(nameof(Ask), nameof(Help));
            public static string Intro => BuildWaterfallName(nameof(Intro), nameof(Help));
            public static string Menu => BuildWaterfallName(nameof(Menu), nameof(Help));
            public static string Actions => BuildWaterfallName(nameof(Actions), nameof(Help));
            public static string ActionDetails => BuildWaterfallName(nameof(ActionDetails), nameof(Help));
            public static string Commands => BuildWaterfallName(nameof(Commands), nameof(Help));
        }

        public static class Home
        {
            public static string Top => BuildWaterfallName(nameof(Top), nameof(Home));
        }

        public static class Actions
        {
            public static class Preparation
            {
                public static string Top => BuildWaterfallName(nameof(Top), nameof(Preparation));
                public static string PreparationWaterfallName(BotActionPreparation preparation)
                {
                    return BuildWaterfallName(preparation.ToString(), nameof(Preparation));
                }
            }

            public static class Assignments
            {
                public static string Top => BuildWaterfallName(nameof(Top), nameof(Assignments));
                public static string Homework => BuildWaterfallName(nameof(Homework), nameof(Assignments));
                public static string Search => BuildWaterfallName(nameof(Search), nameof(Assignments));
            }
        }
    }
}
