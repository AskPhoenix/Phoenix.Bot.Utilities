using Newtonsoft.Json;

namespace Phoenix.Bot.Utilities.State.Options.Actions
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
            this.UserIdToPrepareFor = userIdToPrepareFor;
            this.CourseIdToPrepareFor = courseIdToPrepareFor;
            this.DateToPrepareFor = dateToPrepareFor;
        }
    }
}
