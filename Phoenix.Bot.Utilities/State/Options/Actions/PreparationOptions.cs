using Phoenix.Bot.Utilities.Actions;
using Phoenix.DataHandle.Main;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Phoenix.Bot.Utilities.State.Options.Actions
{
    public class PreparationOptions : ActionOptions
    {
        public BotActionPreparation[] GetPreparations() => (BotActionPreparation[])preparations?.Clone();
        private readonly BotActionPreparation[] preparations;

        public int PreparationsIndex { get; private set; }

        public PreparationOptions(IList<BotActionPreparation> preparations, int userId, Role userRole)
            : base(userId, userRole)
        {
            this.preparations = preparations?.ToArray() ?? new BotActionPreparation[1] { BotActionPreparation.NoPreparation };
            this.ResetPreparationsIndex();
        }

        public PreparationOptions(IList<BotActionPreparation> preparations, UserOptions userOptions)
            : this(preparations, userOptions.UserId, userOptions.UserRole) { }

        public PreparationOptions(int userId, Role userRole)
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
            return new ActionOptions(this.GetUserOptions())
            {
                AffiliatedUserId = this.AffiliatedUserId,
                CourseId = this.CourseId,
                DateToPrepareFor = this.DateToPrepareFor,
                LectureId = this.LectureId
            };
        }
    }
}
