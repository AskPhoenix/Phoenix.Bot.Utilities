using Phoenix.DataHandle.Main.Types;
using Phoenix.Language.Bot.Types.BotAction;

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
        public static string GetEmoji(this BotAction me)
        {
            return me switch
            {
                BotAction.Assignments => "📋",
                BotAction.Supplementary => "➕",
                BotAction.ScheduleWeek => "📅",
                BotAction.ScheduleDay => "📅",
                BotAction.SearchExercises => "🔎",
                BotAction.SearchExams => "🔎",
                BotAction.Grades => "💯",

                BotAction.Access => "🗝",

                BotAction.Exercises => "📚",
                BotAction.Exams => "📝",
                BotAction.Broadcast => "📢",


                BotAction.Help => "💪",
                BotAction.Feedback => "👍",
                _ => string.Empty
            };
        }

        public static string ToFriendlyString(this BotAction me, bool addEmoji = false)
        {
            string actionString = string.Empty;
            if (addEmoji)
                actionString = me.GetEmoji() + " ";

            actionString += me switch
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

        public static BotAction[] PendingActions => new[] { BotAction.Supplementary, BotAction.Grades };
        public static BotAction[] NonMenuActions => new[] { BotAction.SearchExams, BotAction.ScheduleDay };

        public static bool IsPendingAction(this BotAction me) => PendingActions.Contains(me);
        public static bool IsNonMenuAction(this BotAction me) => NonMenuActions.Contains(me);

        public static BotAction[] FindMenuActions(RoleRank roleRank, bool includePending = false)
        {
            var actions = new List<BotAction>();

            switch (roleRank)
            {
                case RoleRank.Parent:
                    actions.Add(BotAction.Access);
                    goto case RoleRank.Student;
                case RoleRank.Student:
                    actions.Add(BotAction.Assignments);
                    actions.Add(BotAction.Supplementary);
                    actions.Add(BotAction.Grades);
                    actions.Add(BotAction.ScheduleWeek);
                    actions.Add(BotAction.SearchExercises);
                    break;

                case RoleRank.SchoolOwner:
                case RoleRank.SchoolAdmin:
                case RoleRank.Secretary:
                    actions.Add(BotAction.Broadcast);
                    goto case RoleRank.Teacher;

                case RoleRank.Teacher:
                    actions.Add(BotAction.Assignments);
                    actions.Add(BotAction.Exercises);
                    actions.Add(BotAction.Supplementary);
                    actions.Add(BotAction.Exams);
                    actions.Add(BotAction.Grades);
                    actions.Add(BotAction.ScheduleWeek);
                    break;

                // Testers select the RoleRank they want to connect as
                case RoleRank.SuperAdmin:
                case RoleRank.SuperTester:
                case RoleRank.SchoolTester:
                default:
                    break;
            }

            actions.Add(BotAction.Help);
            actions.Add(BotAction.Feedback);

            if (!includePending)
                foreach (var action in PendingActions)
                    actions.Remove(action);

            return actions.ToArray();
        }

        public static BotActionPreparation[] FindPreparations(this BotAction me, RoleRank roleRank)
        {
            var preparations = new List<BotActionPreparation>();

            switch (roleRank)
            {
                case RoleRank.Parent:
                    switch (me)
                    {
                        case BotAction.Assignments:
                        case BotAction.Grades:
                        case BotAction.Supplementary:
                        case BotAction.SearchExercises:
                        case BotAction.SearchExams:
                        case BotAction.ScheduleWeek:
                            preparations.Add(BotActionPreparation.AffiliatedUserSelection);
                            break;
                        default:
                            break;
                    }
                    goto case RoleRank.Student;

                case RoleRank.Student:
                    switch (me)
                    {
                        case BotAction.SearchExercises:
                            preparations.Add(BotActionPreparation.CourseSelection);
                            preparations.Add(BotActionPreparation.DateSelection);
                            preparations.Add(BotActionPreparation.LectureSelection);
                            break;
                        case BotAction.SearchExams:
                            preparations.Add(BotActionPreparation.CourseSelection);
                            preparations.Add(BotActionPreparation.DateExamSelection);
                            preparations.Add(BotActionPreparation.LectureExamSelection);
                            break;
                        case BotAction.ScheduleDay:
                            preparations.Add(BotActionPreparation.DateSelection);
                            break;
                        default:
                            preparations.Add(BotActionPreparation.NoPreparation);
                            break;
                    }
                    break;

                case RoleRank.SchoolOwner:
                case RoleRank.SchoolAdmin:
                case RoleRank.Secretary:
                case RoleRank.Teacher:
                    switch (me)
                    {
                        case BotAction.Assignments:
                        case BotAction.Supplementary:
                            preparations.Add(BotActionPreparation.DateSelection);
                            preparations.Add(BotActionPreparation.LectureSelection);
                            break;
                        case BotAction.Grades:
                            preparations.Add(BotActionPreparation.DateExamSelection);
                            preparations.Add(BotActionPreparation.LectureExamSelection);
                            break;
                        case BotAction.ScheduleDay:
                            preparations.Add(BotActionPreparation.DateSelection);
                            break;
                        default:
                            preparations.Add(BotActionPreparation.NoPreparation);
                            break;
                    }
                    break;

                case RoleRank.SchoolTester:
                case RoleRank.SchoolDeveloper:
                case RoleRank.SuperTester:
                case RoleRank.SuperAdmin:
                    goto default;

                case RoleRank.None:
                default:
                    preparations.Add(BotActionPreparation.NoPreparation);
                    break;
            }

            if (preparations.Count > 1 && preparations.Contains(BotActionPreparation.NoPreparation))
                preparations.Remove(BotActionPreparation.NoPreparation);

            return preparations.ToArray();
        }
    }
}