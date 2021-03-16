using Phoenix.DataHandle.Main.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Phoenix.Bot.Utilities.Dialogs
{
    public static class PreparationComponentHelper
    {
        public static Dictionary<int, string> GetSelectables(IEnumerable<AspNetUsers> users)
        {
            return users.ToDictionary(u => u.Id, u => u.User.FirstName);
        }

        public static Dictionary<int, string> GetSelectables(IEnumerable<Course> courses, bool showByGroup = false)
        {
            if (showByGroup)
                return courses.ToDictionary(c => c.Id, c => c.Name + " - " + c.Group);
            
            return courses.ToDictionary(c => c.Id, c => c.NameWithSubcourse);
        }

        public static Dictionary<int, string> GetSelectables(IEnumerable<DateTime> dates, string dateFormat = "d/M")
        {
            if (dates == null)
                throw new ArgumentNullException(nameof(dates));

            int datesNum = dates.Count();
            var selectables = new Dictionary<int, string>(datesNum);
            
            for (int i = 0; i < datesNum; i++)
                selectables.Add(i, dates.ElementAt(i).ToString(dateFormat));

            return selectables;
        }

        public static Dictionary<int, string> GetSelectables(IEnumerable<Lecture> lectures)
        {
            return lectures.ToDictionary(l => l.Id, l => l.StartDateTime.ToString("t"));
        }
    }
}
