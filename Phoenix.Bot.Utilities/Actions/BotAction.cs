using Phoenix.Language.Types;

namespace Phoenix.Bot.Utilities.Actions
{
    public enum BotAction
    {
        NoAction = 0,

        Assignments,
        Supplementary,
        ScheduleWeek,
        ScheduleDay,
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
        public static string ToFriendlyString(this BotAction action, bool addEmoji = false)
        {
            string actionString = string.Empty;
            if (addEmoji)
                actionString = BotActionHelper.GetActionEmoji(action) + " ";

            actionString += action switch
            {
                BotAction.Assignments       => BotActionResources.Assignments,
                BotAction.Supplementary     => BotActionResources.Supplementary,
                BotAction.ScheduleWeek      => BotActionResources.ScheduleWeek,
                BotAction.ScheduleDay       => BotActionResources.ScheduleDay,
                BotAction.SearchExercises   => BotActionResources.SearchExercises,
                BotAction.SearchExams       => BotActionResources.SearchExams,
                BotAction.Grades            => BotActionResources.Grades,

                BotAction.Access            => BotActionResources.Access,

                BotAction.Exercises         => BotActionResources.Exercises,
                BotAction.Exams             => BotActionResources.Exams,
                BotAction.Broadcast         => BotActionResources.Broadcast,

                BotAction.Help              => BotActionResources.Help,
                BotAction.Feedback          => BotActionResources.Feedback,
                _                           => BotActionResources.NoAction
            };

            return actionString;
        }

        public static bool IsNonMenuAction(this BotAction botAction)
        {
            return BotActionHelper.GetNonMenuActions().Contains(botAction);
        }
    }
}