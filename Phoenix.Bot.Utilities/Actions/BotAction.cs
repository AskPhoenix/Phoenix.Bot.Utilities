namespace Phoenix.Bot.Utilities.Actions
{
    public enum BotAction
    {
        NoAction = 0,

        Exercise,
        Exam,
        Schedule,
        Access,

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
                BotAction.Exercise  => "Ασκήσεις",
                BotAction.Exam      => "Διαγωνίσματα",
                BotAction.Schedule  => "Πρόγραμμα",
                BotAction.Access    => "Πρόσβαση",
                BotAction.Help      => "Βοήθεια",
                BotAction.Feedback  => "Κάνε ένα σχόλιο",
                _                   => "Καμία ενέργεια",
            };
        }
    }
}