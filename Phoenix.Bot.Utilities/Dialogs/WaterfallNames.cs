using Microsoft.Bot.Builder.Dialogs;

namespace Phoenix.Bot.Utilities.Dialogs
{
    internal static class WaterfallNames
    {
        internal static string GetWaterfallName(string name, string subname = null)
        {
            if (!string.IsNullOrEmpty(subname))
                subname = "_" + subname;

            return $"{name}{subname}_{nameof(WaterfallDialog)}";
        }
    }

    public static class MainWaterfallNames
    {
        public static string Main => WaterfallNames.GetWaterfallName(nameof(Main));
    }

    public static class AuthWaterfallNames
    {
        private const string Subname    = "Auth";

        public static string Main       => WaterfallNames.GetWaterfallName(nameof(Main), Subname);
        public static string Phone      => WaterfallNames.GetWaterfallName(nameof(Phone), Subname);
        public static string Code       => WaterfallNames.GetWaterfallName(nameof(Code), Subname);
        public static string SendPin    => WaterfallNames.GetWaterfallName(nameof(SendPin), Subname);
        public static string CheckPin   => WaterfallNames.GetWaterfallName(nameof(CheckPin), Subname);
    }

    public static class FeedbackWaterfallNames
    {
        private const string Subname        = "Feedback";

        public static string Spontaneous    => WaterfallNames.GetWaterfallName(nameof(Spontaneous), Subname);
        public static string Triggered      => WaterfallNames.GetWaterfallName(nameof(Triggered), Subname);
        public static string Comment        => WaterfallNames.GetWaterfallName(nameof(Comment), Subname);
        public static string Rating         => WaterfallNames.GetWaterfallName(nameof(Rating), Subname);
    }

    public static class WelcomeWaterfallNames
    {
        private const string Subname        = "Welcome";

        public static string AskForTutorial => WaterfallNames.GetWaterfallName(nameof(AskForTutorial), Subname);
        public static string Tutorial       => WaterfallNames.GetWaterfallName(nameof(Tutorial), Subname);
    }
}
