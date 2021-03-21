namespace Phoenix.Bot.Utilities.Actions
{
    public enum BotAction
    {
        NoAction = 0,

        Assignments,
        Supplementary,
        ScheduleWeekly,
        ScheduleDaily,
        SearchExercises,
        SearchExams,
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
        public static string ToFriendlyString(this BotAction action, bool addEmoji = false)
        {
            string actionString = string.Empty;
            if (addEmoji)
                actionString = BotActionHelper.GetActionEmoji(action) + " ";

            actionString += action switch
            {
                BotAction.Assignments       => "Για διάβασμα",
                BotAction.Supplementary     => "Επιπλέον υλικό",
                BotAction.ScheduleWeekly    => "Πρόγραμμα",
                BotAction.ScheduleDaily     => "Πρόγραμμα ημέρας",
                BotAction.SearchExercises   => "Αναζήτηση εργασιών",
                BotAction.SearchExams       => "Αναζήτηση βαθμών",
                BotAction.Grades            => "Βαθμοί",
                
                BotAction.Access            => "Πρόσβαση",

                BotAction.Exercises         => "Ασκήσεις",
                BotAction.Exams             => "Διαγωνίσματα",
                BotAction.Broadcast         => "Ανακοινώσεις",


                BotAction.Help              => "Βοήθεια",
                BotAction.Feedback          => "Κάνε ένα σχόλιο",
                _                           => "Καμία ενέργεια"
            };

            return actionString;
        }

        public static bool IsNonMenuAction(this BotAction botAction)
        {
            return BotActionHelper.GetNonMenuActions().Contains(botAction);
        }
    }
}