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
        public bool SelectTheClosestFutureDate { get; set; } = false;

        public PreparationOptions()
            : this(Array.Empty<BotActionPreparation>())
        {
        }

        [JsonConstructor]
        private PreparationOptions(int preparationsIndex, BotActionPreparation[] preparations)
        {
            this.PreparationsIndex = preparationsIndex;
            this.preparations = preparations;
        }

        public PreparationOptions(IList<BotActionPreparation> preparations)
        {
            this.preparations = preparations?.ToArray() ?? new BotActionPreparation[1] { BotActionPreparation.NoPreparation };
            this.ResetPreparationsIndex();
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

        public ActionOptions ToActionOptions()
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
