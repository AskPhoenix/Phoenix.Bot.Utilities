namespace Phoenix.Bot.Utilities.State
{
    public struct ConversationsOptions
    {
        public bool NeedsWelcoming { get; set; }
        public int Page { get; set; }
        public string Locale { get; set; }

        public AuthenticationOtions Authentication { get; set; }
        public CourseOptions Course { get; set; }

        public struct AuthenticationOtions
        {
            public string PhoneNumber { get; set; }
            public string OneTimeCode { get; set; }
        }

        public struct CourseOptions
        {
            public int[] SelectedCourseIds { get; set; }
            public int EnrolledCoursesCount { get; set; }
        }
    }
}
