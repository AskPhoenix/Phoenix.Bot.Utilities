namespace Phoenix.Bot.Utilities.State.Options.Actions
{
    public class ScheduleOptions : ActionOptions
    {
        public bool Daily { get; set; } = false;

        public ScheduleOptions()
            : base()
        {
        }

        public ScheduleOptions(ActionOptions actionOptions)
            : base(actionOptions)
        {
        }
    }
}
