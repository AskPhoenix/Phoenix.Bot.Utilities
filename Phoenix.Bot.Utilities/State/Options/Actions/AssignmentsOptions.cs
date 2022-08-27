namespace Phoenix.Bot.Utilities.State.Options.Actions
{
    public class AssignmentsOptions : ActionOptions
    {
        public bool Search { get; set; }

        public AssignmentsOptions()
            : base()
        {
        }

        public AssignmentsOptions(ActionOptions actionOptions)
            : base(actionOptions)
        {
        }
    }
}
