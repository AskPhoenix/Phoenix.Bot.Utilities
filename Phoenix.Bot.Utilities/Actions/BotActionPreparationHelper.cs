using Phoenix.DataHandle.Main;
using System.Collections.Generic;

namespace Phoenix.Bot.Utilities.Actions
{
    public static class BotActionPreparationHelper
    {
        public static IList<BotActionPreparation> GetPreparations(BotAction action, IList<Role> roles)
        {
            IList<BotActionPreparation> preparations = new List<BotActionPreparation>();

            foreach (var role in roles)
            {
                switch (role)
                {
                    case Role.Parent:
                        switch (action)
                        {
                            case BotAction.Assignments:
                            case BotAction.Grades:
                            case BotAction.Supplementary:
                            case BotAction.SearchExercises:
                            case BotAction.SearchExams:
                            case BotAction.ScheduleWeekly:
                                preparations.Add(BotActionPreparation.AffiliatedUserSelection);
                                break;
                            default:
                                break;
                        }
                        goto case Role.Student;

                    case Role.Student:
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
                            case BotAction.ScheduleDaily:
                                preparations.Add(BotActionPreparation.DateSelection);
                                break;
                            default:
                                preparations.Add(BotActionPreparation.NoPreparation);
                                break;
                        }
                        break;

                    case Role.SchoolOwner:
                    case Role.SchoolAdmin:
                    case Role.Secretary:
                        goto default;

                    case Role.Teacher:
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
                            case BotAction.ScheduleDaily:
                                preparations.Add(BotActionPreparation.DateSelection);
                                break;
                            default:
                                preparations.Add(BotActionPreparation.NoPreparation);
                                break;
                        }
                        break;

                    case Role.SchoolTester:
                    case Role.SuperTester:
                    case Role.SuperAdmin:
                        goto default;

                    case Role.Undefined:
                    case Role.None:
                    default:
                        preparations.Add(BotActionPreparation.NoPreparation);
                        break;
                }
            }

            if (preparations.Count > 1 && preparations.Contains(BotActionPreparation.NoPreparation))
                preparations.Remove(BotActionPreparation.NoPreparation);
            
            return preparations;
        }
    }
}
