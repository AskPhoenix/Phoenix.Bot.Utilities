namespace Phoenix.Bot.Utilities.State
{
    public struct ConversationsOptions
    {
        public int Page { get; set; }
        public string Locale { get; set; }

        public CourseOptions Course { get; set; }
    }

    public static class ConversationOptionsDefaults
    {
        public const string PropertyName = "Options";
    }

    public class CourseOptions
    {
        public int[] SelectedCourseIds { get; set; }
        public int EnrolledCoursesCount { get; set; }
    }
}
