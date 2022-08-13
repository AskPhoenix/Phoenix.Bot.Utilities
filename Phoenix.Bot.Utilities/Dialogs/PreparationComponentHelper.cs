using Phoenix.DataHandle.Main.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Phoenix.Bot.Utilities.Dialogs
{
    public static class PreparationComponentHelper
    {
        public static Dictionary<int, string> GetSelectables(IEnumerable<User> users)
        {
            return users.ToDictionary(u => u.AspNetUserId, u => u.FirstName);
        }

        public static Dictionary<int, string> GetSelectables(IEnumerable<Course> courses, bool showByGroup = false)
        {
            if (showByGroup)
            {
                return courses.ToDictionary(c => c.Id, 
                    c => c.Name + (c.SubCourse != null ? $" - " + c.SubCourse : "") + " ~ " + c.Group);
            }
            
            return courses.ToDictionary(c => c.Id, c => c.Name + (c.SubCourse != null ? $" - " + c.SubCourse : ""));
        }

        public static Dictionary<int, string> GetSelectables(IEnumerable<DateTimeOffset> dates, string dateFormat = "d/M")
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
