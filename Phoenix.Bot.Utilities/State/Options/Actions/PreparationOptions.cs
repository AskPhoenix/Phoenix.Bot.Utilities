using Phoenix.Bot.Utilities.Actions;
using Phoenix.DataHandle.Main;
using System.Collections.Generic;
using System.Linq;

namespace Phoenix.Bot.Utilities.State.Options.Actions
{
    public class PreparationOptions : ActionOptions
    {
        public BotActionPreparation[] GetPreparations() => (BotActionPreparation[])preparations?.Clone();
        private readonly BotActionPreparation[] preparations;

        public int PreparationsIndex { get; private set; } = 0;

        public PreparationOptions(IList<BotActionPreparation> preparations, int userId, Role userRole)
            : base(userId, userRole)
        {
            this.preparations = preparations?.ToArray() ?? new BotActionPreparation[1] { BotActionPreparation.NoPreparation };
        }

        public PreparationOptions(IList<BotActionPreparation> preparations, UserOptions userOptions)
            : this(preparations, userOptions.UserId, userOptions.UserRole) { }

        public PreparationOptions(int userId, Role userRole)
            : base(userId, userRole) { }

        public BotActionPreparation GetNextPreparation()
        {
            if (PreparationsIndex < preparations.Length)
                return preparations[PreparationsIndex++];

            return BotActionPreparation.NoPreparation;
        }

        public ActionOptions GetActionOptions()
        {
            return new ActionOptions(this.GetUserOptions())
            {
                AffiliatedUserId = this.AffiliatedUserId,
                CourseId = this.CourseId,
                LectureId = this.LectureId
            };
        }
    }
}
