using Microsoft.Bot.Builder.Dialogs;

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
            public static string Spontaneous => BuildWaterfallName(nameof(Spontaneous), nameof(Feedback));
            public static string Triggered => BuildWaterfallName(nameof(Triggered), nameof(Feedback));
            public static string Comment => BuildWaterfallName(nameof(Comment), nameof(Feedback));
            public static string Rating => BuildWaterfallName(nameof(Rating), nameof(Feedback));
        }

        public static class Help
        {
            public static string Tutorial => BuildWaterfallName(nameof(Tutorial), nameof(Help));
            public static string Ask => BuildWaterfallName(nameof(Ask), nameof(Help));
        }
    }
}
