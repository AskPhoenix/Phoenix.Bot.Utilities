using Newtonsoft.Json;
using Phoenix.Bot.Utilities.Miscellaneous;
using Phoenix.DataHandle.Main;

namespace Phoenix.Bot.Utilities.State.Options.Actions
{
    public partial class BroadcastOptions : ActionOptions
    {
        public string Message { get; set; }
        public DayPart DayPart { get; set; }
        public BroadcastAudience Audience { get; set; }
        public BroadcastVisibility Visibility { get; set; }
        public int? GroupCourseId { get; set; }

        public enum BroadcastAudience
        {
            None = 0,
            Students,
            Parents,
            StudentsParents,
            Staff,
            All
        }

        public enum BroadcastVisibility
        {
            Group = 0,
            Global
        }

        public BroadcastOptions(ActionOptions actionOptions)
            : base(actionOptions) { }

        [JsonConstructor]
        public BroadcastOptions(int userId, Role userRole)
            : base(userId, userRole) { }

        public BroadcastOptions(UserOptions userOptions)
            : base(userOptions) { }
    }
}
