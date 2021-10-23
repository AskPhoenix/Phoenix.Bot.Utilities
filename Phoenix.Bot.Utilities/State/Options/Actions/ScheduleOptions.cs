using Newtonsoft.Json;
using Phoenix.Bot.Utilities.Actions;
using Phoenix.DataHandle.Main;

namespace Phoenix.Bot.Utilities.State.Options.Actions
{
    public class ScheduleOptions : ActionOptions
    {
        public bool Daily { get; set; } = false;

        public ScheduleOptions(ActionOptions actionOptions, bool daily)
            : base(actionOptions)
        {
            this.Daily = daily;
        }

        public ScheduleOptions(ActionOptions actionOptions, BotAction botAction)
            : this(actionOptions, botAction == BotAction.ScheduleDaily) { }

        [JsonConstructor]
        public ScheduleOptions(int userId, Role userRole)
            : base(userId, userRole) { }

        public ScheduleOptions(UserOptions userOptions)
            : base(userOptions) { }
    }
}
