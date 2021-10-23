using Newtonsoft.Json;
using Phoenix.DataHandle.Main;
using System;

namespace Phoenix.Bot.Utilities.State.Options.Actions
{
    public class ActionOptions : UserOptions
    {
        public int? AffiliatedUserId { get; set; }
        public int? CourseId { get; set; }
        public DateTimeOffset? DateToPrepareFor { get; set; }
        public int? LectureId { get; set; }

        public int ActiveUserId { get => this.AffiliatedUserId ?? this.UserId; }

        protected ActionOptions(ActionOptions other)
            : base(other)
        {
            this.AffiliatedUserId = other.AffiliatedUserId;
            this.CourseId = other.CourseId;
            this.DateToPrepareFor = other.DateToPrepareFor;
            this.LectureId = other.LectureId;
        }

        [JsonConstructor]
        public ActionOptions(int userId, Role userRole)
            : base(userId, userRole) { }

        public ActionOptions(UserOptions userOptions)
            : base(userOptions) { }
    }
}
