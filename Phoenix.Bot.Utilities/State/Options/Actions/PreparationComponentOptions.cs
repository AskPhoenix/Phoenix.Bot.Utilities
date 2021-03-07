using Phoenix.DataHandle.Main.Models;
using System.Collections.Generic;

namespace Phoenix.Bot.Utilities.State.Options.Actions
{
    public class PreparationComponentOptions : UserOptions
    {
        public AspNetUsers UserToPrepareFor { get; }
        public Dictionary<int, string> Selectables { get; set; }
        public bool IsPreparingForSomeoneElse { get => (UserToPrepareFor?.Id ?? 0) != this.UserId; }

        public PreparationComponentOptions(AspNetUsers userToPrepareFor, UserOptions actualUserOptions)
            : base(actualUserOptions.UserId, actualUserOptions.UserRole) 
        {
            this.UserToPrepareFor = userToPrepareFor;
        }
    }
}
