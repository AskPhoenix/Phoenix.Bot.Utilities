using Microsoft.Bot.Builder.Dialogs.Choices;
using Phoenix.DataHandle.Main;
using System.Collections.Generic;
using System.Linq;

namespace Phoenix.Bot.Utilities.Actions
{
    public static class BotActionsHelper
    {
        public static IList<BotAction> GetActionsForRole(Role role)
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
                    actions.Add(BotAction.Search);
                    goto default;

                case Role.SchoolOwner:
                case Role.SchoolAdmin:
                case Role.Secretary:
                case Role.Teacher:
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

            return actions;
        }

        public static string GetActionEmoji(BotAction action)
        {
            return action switch
            {
                BotAction.Assignments   => "📋",
                BotAction.Supplementary => "➕",
                BotAction.Schedule      => "📅",
                BotAction.Search        => "🔎",
                BotAction.Grades        => "💯",

                BotAction.Access        => "🗝",

                BotAction.Exercises     => "📚",
                BotAction.Exams         => "📝",
                BotAction.Broadcast     => "🔔",


                BotAction.Help          => "💪",
                BotAction.Feedback      => "👍",
                _                       => string.Empty
            };
        }

        public static IList<Choice> GetActionChoices(Role role)
        {
            var actionNames = GetActionsForRole(role).Select(a => GetActionEmoji(a) + " " + a.ToFriendlyString());
            return ChoiceFactory.ToChoices(actionNames.ToList());
        }
    }
}