using Phoenix.DataHandle.Base.Entities;
using Phoenix.DataHandle.Main.Types;

namespace Phoenix.Bot.Utilities.State.Options.Actions
{
    public class BroadcastOptions : ActionOptions, IBroadcastBase
    {
        public string Message { get; set; } = null!;
        public DateTime ScheduledFor {get; set; }
        public Daypart Daypart { get; set; }
        public BroadcastAudience Audience { get; set; }
        public BroadcastVisibility Visibility { get; set; }
        public BroadcastStatus Status { get; set; }
        public DateTime? SentAt { get; set; }

        public BroadcastOptions()
            : base()
        {
        }

        public BroadcastOptions(ActionOptions actionOptions)
            : base(actionOptions)
        {
        }
    }
}
