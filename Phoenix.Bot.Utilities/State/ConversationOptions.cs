namespace Phoenix.Bot.Utilities.State
{
    public struct ConversationsOptions
    {
        public bool NeedsWelcoming { get; set; }
        public int Page { get; set; }
        public string Locale { get; set; }

        public AuthenticationOptions Authentication { get; set; }
        public CourseOptions Course { get; set; }
    }

    public class AuthenticationOptions
    {
        public string PhoneNumber { get; set; }
        public string OneTimeCode { get; set; }
    }

    public class CourseOptions
    {
        public int[] SelectedCourseIds { get; set; }
        public int EnrolledCoursesCount { get; set; }
    }
}
