﻿using Phoenix.DataHandle.Main;

namespace Phoenix.Bot.Utilities.State.Options.Actions
{
    public class ActionOptions : UserOptions
    {
        public int? AffiliatedUserId { get; set; }
        public int? CourseId { get; set; }
        public int? LectureId { get; set; }

        public ActionOptions(int userId, Role userRole)
            : base(userId, userRole) { }

        public ActionOptions(UserOptions userOptions)
            : this(userOptions.UserId, userOptions.UserRole) { }
    }
}