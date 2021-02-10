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
                    actions.Add(BotAction.Exercise);
                    actions.Add(BotAction.Exam);
                    actions.Add(BotAction.Schedule);
                    goto default;

                case Role.SchoolOwner:
                case Role.SchoolAdmin:
                case Role.Secretary:
                case Role.Teacher:
                    actions.Add(BotAction.Exercise);
                    actions.Add(BotAction.Exam);
                    actions.Add(BotAction.Schedule);
                    goto default;

                case Role.SuperAdmin:
                case Role.SuperTester:
                case Role.SchoolTester:
                    actions.Add(BotAction.Exercise);
                    actions.Add(BotAction.Exam);
                    actions.Add(BotAction.Schedule);
                    goto default;

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
                BotAction.Exercise  => "📚",
                BotAction.Exam      => "📝",
                BotAction.Schedule  => "📅",
                BotAction.Access    => "🗝",
                BotAction.Help      => "💪",
                BotAction.Feedback  => "👍",
                _                   => string.Empty,
            };
        }

        public static IList<Choice> GetActionChoices(Role role)
        {
            var actionNames = GetActionsForRole(role).Select(a => GetActionEmoji(a) + " " + a.ToFriendlyString());
            return ChoiceFactory.ToChoices(actionNames.ToList());
        }
    }
}