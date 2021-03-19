using Microsoft.Bot.Builder.Dialogs.Choices;
using Phoenix.DataHandle.Main;
using System.Collections.Generic;
using System.Linq;

namespace Phoenix.Bot.Utilities.Actions
{
    public static class BotActionHelper
    {
        public static IList<BotAction> GetMenuActions(Role role, bool removePendingActions = false)
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
                    actions.Add(BotAction.Schedule);
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
                    actions.Add(BotAction.Schedule);
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

            return actions;
        }

        public static string GetActionEmoji(BotAction action)
        {
            return action switch
            {
                BotAction.Assignments       => "📋",
                BotAction.Supplementary     => "➕",
                BotAction.Schedule          => "📅",
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

        public static IList<Choice> GetActionChoices(Role role, bool removePendingActions = false)
        {
            var actionNames = GetMenuActions(role, removePendingActions).Select(a => GetActionEmoji(a) + " " + a.ToFriendlyString());
            return ChoiceFactory.ToChoices(actionNames.ToList());
        }

        public static IList<BotAction> GetPendingActions()
        {
            return new List<BotAction> 
            {
                BotAction.Broadcast,
                BotAction.Supplementary
            };
        }
    }
}