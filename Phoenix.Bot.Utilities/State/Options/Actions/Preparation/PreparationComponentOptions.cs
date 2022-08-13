using Newtonsoft.Json;

namespace Phoenix.Bot.Utilities.State.Options.Actions.Preparation
{
    public class PreparationComponentOptions
    {
        public bool IsSelfPrepare { get; set; }
        public int? UserIdToPrepareFor { get; }
        public int? CourseIdToPrepareFor { get; }
        public DateTimeOffset? DateToPrepareFor { get; }
        public bool ExamsOnly { get; set; }
        public Dictionary<int, string>? Selectables { get; set; }

        [JsonConstructor]
        public PreparationComponentOptions(int? userIdToPrepareFor = null, int? courseIdToPrepareFor = null,
            DateTimeOffset? dateToPrepareFor = null)
        {
            UserIdToPrepareFor = userIdToPrepareFor;
            CourseIdToPrepareFor = courseIdToPrepareFor;
            DateToPrepareFor = dateToPrepareFor;
        }
    }
}
