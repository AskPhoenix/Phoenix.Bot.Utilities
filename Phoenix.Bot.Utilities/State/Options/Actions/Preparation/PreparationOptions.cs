using Phoenix.Bot.Utilities.Actions;

namespace Phoenix.Bot.Utilities.State.Options.Actions.Preparation
{
    public class PreparationOptions : ActionOptions
    {
        public Stack<BotActionPreparation> Preparations { get; } = new();

        public PreparationOptions()
            : base()
        {
        }

        public PreparationOptions(IEnumerable<BotActionPreparation> preparations)
            : this(new(), preparations)
        {
        }

        public PreparationOptions(ActionOptions actionOptions)
            : base(actionOptions)
        {
        }

        public PreparationOptions(ActionOptions actionOptions, IEnumerable<BotActionPreparation> preparations)
            : base(actionOptions)
        {
            foreach (var prep in preparations.Reverse())
                this.Preparations.Push(prep);
        }
    }
}
