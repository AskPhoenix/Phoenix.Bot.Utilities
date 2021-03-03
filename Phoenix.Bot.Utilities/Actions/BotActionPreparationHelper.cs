using Phoenix.DataHandle.Main;
using System.Collections.Generic;

namespace Phoenix.Bot.Utilities.Actions
{
    public static class BotActionPreparationHelper
    {
        public static IList<BotActionPreparation> GetPreparationForAction(BotAction action, Role role)
        {
            IList<BotActionPreparation> preparations = new List<BotActionPreparation>();

            switch (action)
            {
                case BotAction.Grades:
                case BotAction.Supplementary:
                case BotAction.Assignments:
                    switch (role)
                    {
                        case Role.Parent:
                            preparations.Add(BotActionPreparation.AffiliatedUserSelection);
                            goto case Role.Student;
                        case Role.Student:
                            preparations.Add(BotActionPreparation.CourseSelection);
                            break;

                        case Role.SchoolOwner:
                        case Role.SchoolAdmin:
                        case Role.Secretary:
                        case Role.Teacher:
                            preparations.Add(BotActionPreparation.LectureSelection);
                            preparations.Add(BotActionPreparation.GroupSelection);
                            break;
                        
                        case Role.SchoolTester:
                        case Role.SuperTester:
                        case Role.SuperAdmin:
                            goto case Role.Student;

                        case Role.Undefined:
                        case Role.None:
                        default:
                            preparations.Add(BotActionPreparation.NoPreparation);
                            break;
                    }
                    break;
                
                case BotAction.Search:
                    switch (role)
                    {
                        case Role.Parent:
                            preparations.Add(BotActionPreparation.AffiliatedUserSelection);
                            goto case Role.Student;
                        case Role.Student:
                            preparations.Add(BotActionPreparation.CourseSelection);
                            preparations.Add(BotActionPreparation.LectureSelection);
                            break;

                        case Role.SchoolTester:
                        case Role.SuperTester:
                        case Role.SuperAdmin:
                            goto case Role.Student;

                        case Role.SchoolOwner:
                        case Role.SchoolAdmin:
                        case Role.Secretary:
                        case Role.Teacher:
                        case Role.Undefined:
                        case Role.None:
                        default:
                            preparations.Add(BotActionPreparation.NoPreparation);
                            break;
                    }
                    break;
                
                case BotAction.Broadcast:
                    switch (role)
                    {
                        case Role.SchoolOwner:
                        case Role.SchoolAdmin:
                        case Role.Secretary:
                        case Role.Teacher:
                            preparations.Add(BotActionPreparation.GroupSelection);
                            break;

                        case Role.SchoolTester:
                        case Role.SuperTester:
                        case Role.SuperAdmin:
                            goto case Role.Teacher;

                        case Role.Parent:
                        case Role.Student:
                        case Role.Undefined:
                        case Role.None:
                        default:
                            preparations.Add(BotActionPreparation.NoPreparation);
                            break;
                    }
                    break;

                case BotAction.Exercises:
                case BotAction.Exams:
                case BotAction.Access:
                case BotAction.Schedule:
                case BotAction.Help:
                case BotAction.Feedback:
                case BotAction.NoAction:
                default:
                    preparations.Add(BotActionPreparation.NoPreparation);
                    break;
            }
            
            return preparations;
        }
    }
}
