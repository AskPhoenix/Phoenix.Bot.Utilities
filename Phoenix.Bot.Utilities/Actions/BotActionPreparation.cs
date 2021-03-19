namespace Phoenix.Bot.Utilities.Actions
{
    public enum BotActionPreparation
    {
        NoPreparation = 0,

        AffiliatedUserSelection,    // Select among Affiliated Users                                user                --> affiliated user
        CourseSelection,            // Select among Courses                                         user                --> course
        GroupSelection,             // Select among Groups (Teacher Courses)                        user                --> course
        DateSelection,              // Select among Dates with Lectures of a Course(s)              user/course         --> date
        DateExamSelection,          // Select among Dates with Lectures of a Course(s) with Exam(s) user/course         --> date
        LectureSelection,           // Select among Lectures for a Date                             user/course, date   --> lecture
        LectureExamSelection        // Select among Lectures for a Date with Exam(s)                user/course, date   --> lecture
    }
}
