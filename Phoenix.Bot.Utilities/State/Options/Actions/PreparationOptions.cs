using Newtonsoft.Json;
using Phoenix.Bot.Utilities.Actions;

namespace Phoenix.Bot.Utilities.State.Options.Actions
{
    public class PreparationOptions : ActionOptions
    {
        public BotActionPreparation[] GetPreparations() => (BotActionPreparation[])preparations.Clone();
        
        [JsonProperty]
        private readonly BotActionPreparation[] preparations;

        public int PreparationsIndex { get; private set; }
        public bool SelectTheClosestFutureDate { get; set; }

        public PreparationOptions(ActionOptions actionOptions)
            : this(actionOptions, new[] { BotActionPreparation.NoPreparation })
        {
        }

        public PreparationOptions(ActionOptions actionOptions, BotActionPreparation[] preparations)
            : base(actionOptions)
        {
            this.preparations = preparations;
            this.ResetPreparationsIndex();
        }

        // TODO: Check if the rest of the properties is loaded correctly
        [JsonConstructor]
        public PreparationOptions(BotActionPreparation[] preparations, int preparationsIndex)
        {
            this.preparations = preparations;
            this.PreparationsIndex = preparationsIndex;
        }

        public BotActionPreparation GetNextPreparation()
        {
            PreparationsIndex++;
            return GetCurrentPreparation();
        }

        public BotActionPreparation GetCurrentPreparation()
        {
            if (PreparationsIndex < preparations.Length)
                return preparations[Math.Max(0, PreparationsIndex)];

            return BotActionPreparation.NoPreparation;
        }

        public void ResetPreparationsIndex()
        {
            PreparationsIndex = -1;
        }

        public ActionOptions GetActionOptions()
        {
            return new ActionOptions(this)
            {
                AffiliatedUserId = this.AffiliatedUserId,
                CourseId = this.CourseId,
                DateToPrepareFor = this.DateToPrepareFor,
                LectureId = this.LectureId
            };
        }
    }
}
