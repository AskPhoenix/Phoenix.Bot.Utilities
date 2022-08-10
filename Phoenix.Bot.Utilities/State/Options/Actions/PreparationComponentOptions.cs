using Newtonsoft.Json;

namespace Phoenix.Bot.Utilities.State.Options.Actions
{
    public class PreparationComponentOptions
    {
        public int IdToPrepareFor { get; }
        public bool PrepareForUserOrCourse { get; }    // true for User, false for Course
        public DateTimeOffset? DateToPrepareFor { get; }
        public bool ExamsOnly { get; set; } = false;
        public Dictionary<int, string>? Selectables { get; set; }
        //public bool IsPreparingForSomeoneElse
        //{
        //    get => this.PrepareForUserOrCourse && this.IdToPrepareFor != this.UserId;
        //}

        [JsonConstructor]
        private PreparationComponentOptions(int idToPrepareFor, DateTimeOffset? dateToPrepareFor)
        {
            this.IdToPrepareFor = idToPrepareFor;
            this.DateToPrepareFor = dateToPrepareFor;
        }

        public PreparationComponentOptions(int idToPrepareFor, bool prepareForUserOrCourse)
        {
            this.IdToPrepareFor = idToPrepareFor;
            this.PrepareForUserOrCourse = prepareForUserOrCourse;
        }

        public PreparationComponentOptions(int idToPrepareFor, bool prepareForUserOrCourse, DateTimeOffset dateToPrepareFor)
        {
            this.IdToPrepareFor = idToPrepareFor;
            this.PrepareForUserOrCourse = prepareForUserOrCourse;
            this.DateToPrepareFor = dateToPrepareFor;
        }
    }
}
