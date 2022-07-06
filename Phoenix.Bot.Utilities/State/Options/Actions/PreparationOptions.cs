using Newtonsoft.Json;
using Phoenix.Bot.Utilities.Actions;
using Phoenix.DataHandle.Main.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Phoenix.Bot.Utilities.State.Options.Actions
{
    public class PreparationOptions : ActionOptions
    {
        public BotActionPreparation[] GetPreparations() => (BotActionPreparation[])preparations?.Clone();
        [JsonProperty]
        private readonly BotActionPreparation[] preparations;

        public int PreparationsIndex { get; private set; }

        public bool SelectTheClosestFutureDate { get; set; } = false;

        [JsonConstructor]
        private PreparationOptions(int userId, RoleRank userRole, int preparationsIndex, BotActionPreparation[] preparations)
            : this(userId, userRole)
        {
            this.PreparationsIndex = preparationsIndex;
            this.preparations = preparations;
        }

        public PreparationOptions(IList<BotActionPreparation> preparations, int userId, RoleRank userRole)
            : base(userId, userRole)
        {
            this.preparations = preparations?.ToArray() ?? new BotActionPreparation[1] { BotActionPreparation.NoPreparation };
            this.ResetPreparationsIndex();
        }

        public PreparationOptions(IList<BotActionPreparation> preparations, UserOptions userOptions)
            : this(preparations, userOptions.UserId, userOptions.UserRole) { }

        public PreparationOptions(int userId, RoleRank userRole)
            : base(userId, userRole) { }

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
