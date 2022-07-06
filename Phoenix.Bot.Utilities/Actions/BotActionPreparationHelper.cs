using Phoenix.DataHandle.Main.Types;
using System.Collections.Generic;

namespace Phoenix.Bot.Utilities.Actions
{
    public static class BotActionPreparationHelper
    {
        public static IList<BotActionPreparation> GetPreparations(BotAction action, RoleRank roleRank)
        {
            var preparations = new List<BotActionPreparation>();

            switch (roleRank)
            {
                case RoleRank.Parent:
                    switch (action)
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
                    switch (action)
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
                    switch (action)
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

            return preparations;
        }
    }
}
