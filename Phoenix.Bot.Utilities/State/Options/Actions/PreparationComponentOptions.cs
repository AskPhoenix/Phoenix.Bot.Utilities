﻿using Phoenix.DataHandle.Main.Models;
using System;
using System.Collections.Generic;

namespace Phoenix.Bot.Utilities.State.Options.Actions
{
    public class PreparationComponentOptions : UserOptions
    {
        public AspNetUsers UserToPrepareFor { get; }
        public Course CourseToPrepareFor { get; }
        public DateTimeOffset DateToPrepareFor { get; }

        public Dictionary<int, string> Selectables { get; set; }
        public bool IsPreparingForSomeoneElse { get => (UserToPrepareFor?.Id ?? 0) != this.UserId; }

        public PreparationComponentOptions(AspNetUsers userToPrepareFor, UserOptions actualUserOptions)
            : base(actualUserOptions) 
        {
            this.UserToPrepareFor = userToPrepareFor;
        }

        public PreparationComponentOptions(Course courseToPrepareFor, UserOptions actualUserOptions)
            : base(actualUserOptions)
        {
            this.CourseToPrepareFor = courseToPrepareFor;
        }

        public PreparationComponentOptions(DateTimeOffset dateToPrepareFor, UserOptions actualUserOptions)
            : base(actualUserOptions) 
        {
            this.DateToPrepareFor = dateToPrepareFor;
        }
    }
}
