using Microsoft.Bot.Builder.Dialogs.Choices;
using Phoenix.DataHandle.Main.Types;
using System.Collections.Generic;
using System.Linq;

namespace Phoenix.Bot.Utilities.Actions
{
    public static class BotActionHelper
    {
        public static IList<BotAction> GetMenuActions(RoleRank roleRank,
            bool removePendingActions = false, bool removeAccessAction = false)
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
                    break;
            }


            actions.Add(BotAction.Help);
            actions.Add(BotAction.Feedback);

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
                BotAction.ScheduleWeek      => "📅",
                BotAction.ScheduleDay       => "📅",
                BotAction.SearchExercises   => "🔎",
                BotAction.SearchExams       => "🔎",
                BotAction.Grades            => "💯",

                BotAction.Access            => "🗝",

                BotAction.Exercises         => "📚",
                BotAction.Exams             => "📝",
                BotAction.Broadcast         => "📢",


                BotAction.Help              => "💪",
                BotAction.Feedback          => "👍",
                _                           => string.Empty
            };
        }

        public static IList<Choice> GetActionChoices(RoleRank roleRank,
            bool removePendingActions = false, bool removeAccessAction = false)
        {
            var actionNames = GetMenuActions(roleRank, removePendingActions, removeAccessAction)
                .Select(a => a.ToFriendlyString(addEmoji: true));
            return ChoiceFactory.ToChoices(actionNames.ToList());
        }

        public static IList<BotAction> GetPendingActions()
        {
            return new List<BotAction>
            {
                BotAction.Supplementary,
                BotAction.Grades
            };
        }

        public static IList<BotAction> GetNonMenuActions()
        {
            return new List<BotAction>
            {
                BotAction.SearchExams,
                BotAction.ScheduleDay
            };
        }
    }
}