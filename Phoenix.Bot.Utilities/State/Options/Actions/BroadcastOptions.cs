using Newtonsoft.Json;
using Phoenix.Bot.Utilities.Miscellaneous;
using Phoenix.DataHandle.Main;
using static Phoenix.Bot.Utilities.State.Options.Actions.BroadcastOptions;

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
            Students = 0,
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

    public static class BroadcastOptionsExtensions
    {
        public static string ToFriendlyString(this BroadcastAudience audience)
        {
            return audience switch
            {
                BroadcastAudience.Students => "Μαθητές",
                BroadcastAudience.Parents => "Γονείς",
                BroadcastAudience.StudentsParents => "Μαθητές & Γονείς",
                BroadcastAudience.Staff => "Προσωπικό φροντιστηρίου",
                BroadcastAudience.All => "Όλοι",
                _ => string.Empty
            };
        }

        public static string ToFriendlyString(this BroadcastVisibility visibility)
        {
            return visibility switch
            {
                BroadcastVisibility.Group => "Τμήμα",
                BroadcastVisibility.Global => "Σε όλο το σχολείο",
                _ => string.Empty
            };
        }
    }
}
