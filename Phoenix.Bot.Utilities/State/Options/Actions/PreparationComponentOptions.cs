using Newtonsoft.Json;
using Phoenix.DataHandle.Main;
using System;
using System.Collections.Generic;

namespace Phoenix.Bot.Utilities.State.Options.Actions
{
    public class PreparationComponentOptions : UserOptions
    {
        public int IdToPrepareFor { get; }
        public bool PrepareForUserOrCourse { get; }    // true for User, false for Course
        public DateTimeOffset? DateToPrepareFor { get; }

        public Dictionary<int, string> Selectables { get; set; }
        public bool IsPreparingForSomeoneElse { get => this.PrepareForUserOrCourse && this.IdToPrepareFor != this.UserId; }

        [JsonConstructor]
        private PreparationComponentOptions(int idToPrepareFor, DateTimeOffset? dateToPrepareFor, int userId, Role userRole)
            : base(userId, userRole)
        {
            this.IdToPrepareFor = idToPrepareFor;
            this.DateToPrepareFor = dateToPrepareFor;
        }

        public PreparationComponentOptions(int idToPrepareFor, bool prepareForUserOrCourse, UserOptions actualUserOptions)
            : base(actualUserOptions) 
        {
            this.IdToPrepareFor = idToPrepareFor;
            this.PrepareForUserOrCourse = prepareForUserOrCourse;
        }

        public PreparationComponentOptions(int idToPrepareFor, bool prepareForUserOrCourse, DateTimeOffset dateToPrepareFor, UserOptions actualUserOptions)
            : base(actualUserOptions) 
        {
            this.IdToPrepareFor = idToPrepareFor;
            this.PrepareForUserOrCourse = prepareForUserOrCourse;
            this.DateToPrepareFor = dateToPrepareFor;
        }
    }
}
