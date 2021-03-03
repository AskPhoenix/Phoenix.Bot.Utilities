using Phoenix.Bot.Utilities.Actions;
using System.Collections.Generic;
using System.Linq;

namespace Phoenix.Bot.Utilities.State.Options
{
    public class PreparationOptions : ActionOptions
    {
        public BotActionPreparation[] GetPreparations() => (BotActionPreparation[])preparations?.Clone();
        private readonly BotActionPreparation[] preparations;

        public int AffiliatedUserIdSelected { get; set; }
        public int CourseIdSelected { get; set; }
        public int LectureIdSelected { get; set; }

        public PreparationOptions(IList<int> courseIds, IList<int> affiliatedUserIds, IList<BotActionPreparation> preparations)
            : base(courseIds, affiliatedUserIds)
        {
            this.preparations = preparations?.ToArray();
        }

        public PreparationOptions(ActionOptions actionOptions, IList<BotActionPreparation> preparations)
            : this(actionOptions.GetCourseIds(), actionOptions.GetAffiliatedUserIds(), preparations) { }

        public PreparationOptions(IList<BotActionPreparation> preparations)
            : this(null, null, preparations) { }
    }
}
