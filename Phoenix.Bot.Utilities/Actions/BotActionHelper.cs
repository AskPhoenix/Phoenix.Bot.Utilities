using Microsoft.Bot.Builder.Dialogs.Choices;
using Phoenix.DataHandle.Main;
using System.Collections.Generic;
using System.Linq;

namespace Phoenix.Bot.Utilities.Actions
{
    public static class BotActionHelper
    {
        public static IList<BotAction> GetMenuActions(Role role, bool removePendingActions = false, bool removeAccessAction = false)
        {
            IList<BotAction> actions = new List<BotAction>();

            switch (role)
            {
                case Role.Parent:
                    actions.Add(BotAction.Access);
                    goto case Role.Student;
                case Role.Student:
                    actions.Add(BotAction.Assignments);
                    actions.Add(BotAction.Supplementary);
                    actions.Add(BotAction.Grades);
                    actions.Add(BotAction.ScheduleWeekly);
                    actions.Add(BotAction.SearchExercises);
                    goto default;

                case Role.SchoolOwner:
                case Role.SchoolAdmin:
                case Role.Secretary:
                case Role.Teacher:
                    actions.Add(BotAction.Assignments);
                    actions.Add(BotAction.Broadcast);
                    actions.Add(BotAction.Exercises);
                    actions.Add(BotAction.Supplementary);
                    actions.Add(BotAction.Exams);
                    actions.Add(BotAction.Grades);
                    actions.Add(BotAction.ScheduleWeekly);
                    goto default;

                // Testers select the Role they want to connect as
                case Role.SuperAdmin:
                case Role.SuperTester:
                case Role.SchoolTester:
                    goto case Role.Student;

                default:
                    actions.Add(BotAction.Help);
                    actions.Add(BotAction.Feedback);
                    break;
            }

            if (removePendingActions)
                foreach (var action in GetPendingActions())
                    actions.Remove(action);
            if (removeAccessAction)
                actions.Remove(BotAction.Access);

            return actions;
        }

        public static string GetActionEmoji(BotAction action)
        {
            return action switch
            {
                BotAction.Assignments       => "📋",
                BotAction.Supplementary     => "➕",
                BotAction.ScheduleWeekly    => "📅",
                BotAction.ScheduleDaily     => "📅",
                BotAction.SearchExercises   => "🔎",
                BotAction.SearchExams       => "🔎",
                BotAction.Grades            => "💯",

                BotAction.Access            => "🗝",

                BotAction.Exercises         => "📚",
                BotAction.Exams             => "📝",
                BotAction.Broadcast         => "🔔",


                BotAction.Help              => "💪",
                BotAction.Feedback          => "👍",
                _                           => string.Empty
            };
        }

        public static IList<Choice> GetActionChoices(Role role, bool removePendingActions = false, bool removeAccessAction = false)
        {
            var actionNames = GetMenuActions(role, removePendingActions, removeAccessAction).Select(a => GetActionEmoji(a) + " " + a.ToFriendlyString());
            return ChoiceFactory.ToChoices(actionNames.ToList());
        }

        public static IList<BotAction> GetPendingActions()
        {
            return new List<BotAction> 
            {
                BotAction.Broadcast,
                BotAction.Supplementary,
                BotAction.Grades
            };
        }

        public static IList<BotAction> GetNonMenuActions()
        {
            return new List<BotAction>(2)
            {
                BotAction.SearchExams,
                BotAction.ScheduleDaily
            };
        }
    }
}