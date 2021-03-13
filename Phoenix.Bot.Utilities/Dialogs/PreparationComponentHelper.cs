using Phoenix.Bot.Utilities.State.Options.Actions;
using Phoenix.DataHandle.Main;
using Phoenix.DataHandle.Main.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Phoenix.Bot.Utilities.Dialogs
{
    public static class PreparationComponentHelper
    {
        public enum LectureTimeline
        {
            Anytime,
            Past,
            Future
        }

        public static Dictionary<int, string> FindClosestLectureDates(Course course, LectureTimeline timeline, int daysNum = 5, string dateFormat = "d/M")
        {
            IEnumerable<Lecture> lectures = timeline switch
            {
                LectureTimeline.Past    => course.Lecture?.Where(l => l.StartDateTime.ToUniversalTime() < DateTimeOffset.UtcNow && l.Status == LectureStatus.Scheduled),
                LectureTimeline.Future  => course.Lecture?.Where(l => l.StartDateTime.ToUniversalTime() >= DateTimeOffset.UtcNow && l.Status == LectureStatus.Scheduled),
                _                       => course.Lecture?.Where(l => l.Status == LectureStatus.Scheduled)
            };

            return lectures?.
                GroupBy(l => l.StartDateTime.Date).
                Select(g => g.First()).
                OrderByDescending(l => (l.StartDateTime.ToUniversalTime() - DateTimeOffset.UtcNow).Duration()).
                Take(daysNum).
                OrderBy(l => l.StartDateTime).
                ToDictionary(l => l.Id, l => l.StartDateTime.ToString(dateFormat));
        }

        public static Dictionary<int, string> FindLectureTimes(Course course, DateTimeOffset date)
        {
            return course.Lecture?.
                    Where(l => l.StartDateTime.Date == date.Date && l.Status == LectureStatus.Scheduled).
                    ToDictionary(l => l.Id, l => l.StartDateTime.ToString("t"));
        }
    }
}
