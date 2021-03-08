namespace Phoenix.Bot.Utilities.Actions
{
    public enum BotActionPreparation
    {
        NoPreparation = 0,

        AffiliatedUserSelection,    // Select among Affiliated Users
        CourseSelection,            // Select among Courses
        LectureSelection,           // Select among Lectures

        DateSelectionByCourse,      // Select a Date with Teacher Course(s)
        LectureSelectionByDate,     // Select a Lecture on the given Date
        CourseSelectionByGroup      // Select among Courses (depending on the Group)
    }
}
