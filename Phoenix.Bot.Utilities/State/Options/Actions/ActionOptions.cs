namespace Phoenix.Bot.Utilities.State.Options.Actions
{
    public class ActionOptions
    {
        public int? AffiliatedUserId { get; set; }
        public int? CourseId { get; set; }
        public DateTimeOffset? DateToPrepareFor { get; set; }
        public int? LectureId { get; set; }

        public ActionOptions()
        {
        }

        internal ActionOptions(ActionOptions other)
        {
            this.AffiliatedUserId = other.AffiliatedUserId;
            this.CourseId = other.CourseId;
            this.DateToPrepareFor = other.DateToPrepareFor;
            this.LectureId = other.LectureId;
        }
    }
}
