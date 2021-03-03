using System.Collections.Generic;
using System.Linq;

namespace Phoenix.Bot.Utilities.State.Options
{
    public class ActionOptions
    {
        public int[] GetAffiliatedUserIds() => (int[])affiliatedUserIds?.Clone();
        protected readonly int[] affiliatedUserIds;

        public int[] GetCourseIds() => (int[])courseIds?.Clone();
        private readonly int[] courseIds;

        public int UserId { get; set; }

        public ActionOptions(IList<int> courseIds, IList<int> affiliatedUserIds)
        {
            this.courseIds = courseIds?.ToArray();
            this.affiliatedUserIds = affiliatedUserIds?.ToArray();
        }

        public ActionOptions(int[] courseIds)
            : this(courseIds, null) { }

        public ActionOptions()
            : this(null, null) { }

        public int[] GetAllUsersIds()
        {
            List<int> allUsers = new List<int>(affiliatedUserIds?.Length ?? 0 + 1) { this.UserId };

            if (affiliatedUserIds != null)
                allUsers.AddRange(affiliatedUserIds);

            return allUsers.ToArray();
        }
    }
}
