using Newtonsoft.Json;
using Phoenix.DataHandle.Main;
using System;
using System.Collections.Generic;
using System.Text;

namespace Phoenix.Bot.Utilities.State.Options.Actions
{
    public class AssignmentsOptions : ActionOptions
    {
        public bool Search { get; set; }

        public AssignmentsOptions(ActionOptions actionOptions)
            : this(actionOptions.GetUserOptions())
        {
            this.AffiliatedUserId = actionOptions.AffiliatedUserId;
            this.CourseId = actionOptions.CourseId;
            this.DateToPrepareFor = actionOptions.DateToPrepareFor;
            this.LectureId = actionOptions.LectureId;
        }
        
        [JsonConstructor]
        public AssignmentsOptions(int userId, Role userRole)
            : base(userId, userRole) { }

        public AssignmentsOptions(UserOptions userOptions)
            : this(userOptions.UserId, userOptions.UserRole) { }
    }
}
