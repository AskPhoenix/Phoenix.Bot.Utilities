namespace Phoenix.Bot.Utilities.Actions
{
    public enum BotActionPreparation
    {
        NoPreparation = 0,

        AffiliatedUserSelection,    // Select among Affiliated Users                        user                --> affiliated user
        CourseSelection,            // Select among Courses                                 user                --> course
        GroupSelection,             // Select among Groups (Teacher Courses)                user                --> course
        DateSelection,              // Select among Dates with Lectures of a Course(s)      user/course         --> date
        LectureSelection            // Select among Lectures                                user/course, date   --> lecture
    }
}
