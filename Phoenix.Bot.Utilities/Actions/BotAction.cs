namespace Phoenix.Bot.Utilities.Actions
{
    public enum BotAction
    {
        NoAction = 0,

        Assignments,
        Supplementary,
        Schedule,
        Search,
        Grades,

        Access,

        Exercises,
        Exams,
        Broadcast,

        Help,
        Feedback
    }

    public static class BotActionExtensions
    {
        //TODO: Use locale
        public static string ToFriendlyString(this BotAction action)
        {
            return action switch
            {
                BotAction.Assignments   => "Για διάβασμα",
                BotAction.Supplementary => "Επιπλέον υλικό",
                BotAction.Schedule      => "Πρόγραμμα",
                BotAction.Search        => "Αναζήτηση εργασιών",
                BotAction.Grades        => "Βαθμοί",
                
                BotAction.Access        => "Πρόσβαση",

                BotAction.Exercises     => "Ασκήσεις",
                BotAction.Exams         => "Διαγωνίσματα",
                BotAction.Broadcast     => "Ανακοινώσεις",


                BotAction.Help          => "Βοήθεια",
                BotAction.Feedback      => "Κάνε ένα σχόλιο",
                _                       => "Καμία ενέργεια"
            };
        }
    }
}