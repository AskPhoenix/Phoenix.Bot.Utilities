using System.Linq;

namespace Phoenix.Bot.Utilities.State.Options
{
    public class ActionOptions
    {
        private readonly int[] affiliatedUserIds;
        private readonly int[] courseIds;

        public int UserId { get; set; }

        public ActionOptions() 
            : this(null, null) { }
        
        public ActionOptions(int[] courseIds)
            : this(courseIds, null) { }

        public ActionOptions(int[] courseIds, int[] affiliatedUserIds)
        {
            this.courseIds = courseIds;
            this.affiliatedUserIds = affiliatedUserIds;
        }

        public int[] GetAffiliatedUserIds() => (int[])affiliatedUserIds.Clone();
        public int[] GetCourseIds()         => (int[])courseIds.Clone();
        public int[] GetAllUsersIds()       => this.GetAffiliatedUserIds().Prepend(this.UserId).ToArray();
    }
}
