using Microsoft.Bot.Builder.Dialogs;

namespace Phoenix.Bot.Utilities.Dialogs
{
    public static class WaterfallNames
    {
        public static string BuildWaterfallName(string name, string subname = null)
        {
            if (!string.IsNullOrEmpty(subname))
                subname = "_" + subname;

            return $"{name}{subname}_{nameof(WaterfallDialog)}";
        }
    }

    public static class MainWaterfallNames
    {
        public static string Main => WaterfallNames.BuildWaterfallName(nameof(Main));
    }

    public static class AuthWaterfallNames
    {
        private const string Subname    = "Auth";

        public static string Main       => WaterfallNames.BuildWaterfallName(nameof(Main), Subname);
        public static string Phone      => WaterfallNames.BuildWaterfallName(nameof(Phone), Subname);
        public static string Code       => WaterfallNames.BuildWaterfallName(nameof(Code), Subname);
        public static string SendPin    => WaterfallNames.BuildWaterfallName(nameof(SendPin), Subname);
        public static string CheckPin   => WaterfallNames.BuildWaterfallName(nameof(CheckPin), Subname);
    }

    public static class FeedbackWaterfallNames
    {
        private const string Subname        = "Feedback";

        public static string Spontaneous    => WaterfallNames.BuildWaterfallName(nameof(Spontaneous), Subname);
        public static string Triggered      => WaterfallNames.BuildWaterfallName(nameof(Triggered), Subname);
        public static string Comment        => WaterfallNames.BuildWaterfallName(nameof(Comment), Subname);
        public static string Rating         => WaterfallNames.BuildWaterfallName(nameof(Rating), Subname);
    }

    public static class WelcomeWaterfallNames
    {
        private const string Subname        = "Welcome";

        public static string AskForTutorial => WaterfallNames.BuildWaterfallName(nameof(AskForTutorial), Subname);
        public static string Tutorial       => WaterfallNames.BuildWaterfallName(nameof(Tutorial), Subname);
    }
}
