using Newtonsoft.Json;
using Phoenix.DataHandle.Main;

namespace Phoenix.Bot.Utilities.State.Options.Actions
{
    public class AssignmentsOptions : ActionOptions
    {
        public bool Search { get; set; }

        public AssignmentsOptions(ActionOptions actionOptions, bool search)
            : base(actionOptions.GetUserOptions(), actionOptions)
        {
            this.Search = search;
        }

        [JsonConstructor]
        public AssignmentsOptions(int userId, Role userRole)
            : base(userId, userRole) { }

        public AssignmentsOptions(UserOptions userOptions)
            : this(userOptions.UserId, userOptions.UserRole) { }
    }
}
