using Phoenix.Bot.Utilities.Actions;

namespace Phoenix.Bot.Utilities.State.Options.Actions
{
    public class AssignmentsOptions : ActionOptions
    {
        public bool Search { get; set; }

        public AssignmentsOptions(ActionOptions actionOptions, bool search)
            : base(actionOptions)
        {
            this.Search = search;
        }

        public AssignmentsOptions(ActionOptions actionOptions, BotAction botAction)
            : this(actionOptions, botAction == BotAction.SearchExercises)
        {
        }
    }
}
