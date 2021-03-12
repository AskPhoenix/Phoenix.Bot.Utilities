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
        public static Dictionary<int, string> FindClosestLectureDates(Course course, bool pastOnly, int daysNum = 5, string dateFormat = "d/M")
        {
            IEnumerable<Lecture> lectures = pastOnly
                ? course.Lecture?.Where(l => l.StartDateTime.ToUniversalTime() < DateTimeOffset.UtcNow && l.Status == LectureStatus.Scheduled)
                : course.Lecture?.Where(l => l.Status == LectureStatus.Scheduled);

            return lectures?.
                OrderByDescending(l => (l.StartDateTime.ToUniversalTime() - DateTimeOffset.UtcNow).Duration()).
                Take(daysNum).
                ToDictionary(l => l.Id, l => l.StartDateTime.ToString(dateFormat));
        }

        public static Dictionary<int, string> GetDateSelectables(PreparationComponentOptions options, int daysNum = 5, string dateFormat = "d/M")
        {
            bool singleCourse = options.CourseToPrepareFor != null;

            if (singleCourse)
                return FindClosestLectureDates(options.CourseToPrepareFor, pastOnly: true);
            else
            {
                var courses = options.UserToPrepareFor.TeacherCourse.Select(tc => tc.Course);
                var tore = new Dictionary<int, string>(5 * courses.Count());

                foreach (var course in courses)
                {
                    var tempDict = FindClosestLectureDates(course, pastOnly: false);
                    if (tempDict != null)
                        foreach (var lectureDatePair in tempDict)
                            tore.Add(lectureDatePair.Key, lectureDatePair.Value);
                }

                return tore;
            }
        }

        public static Dictionary<int, string> FindLectureTimes(Course course, DateTimeOffset date)
        {
            return course.Lecture?.
                    Where(l => l.StartDateTime.Date == date.Date && l.Status == LectureStatus.Scheduled).
                    ToDictionary(l => l.Id, l => l.StartDateTime.ToString("t"));
        }

        public static Dictionary<int, string> GetLectureSelectables(PreparationComponentOptions options, DateTimeOffset dateToPrepareFor)
        {
            bool singleCourse = options.CourseToPrepareFor != null;

            if (singleCourse)
                return FindLectureTimes(options.CourseToPrepareFor, dateToPrepareFor);
            else
            {
                var courses = options.UserToPrepareFor.TeacherCourse.Select(tc => tc.Course);
                var tore = new Dictionary<int, string>();

                foreach (var course in courses)
                {
                    var tempDict = FindLectureTimes(course, dateToPrepareFor);
                    if (tempDict != null)
                        foreach (var lectureTimePair in tempDict)
                            tore.Add(lectureTimePair.Key, lectureTimePair.Value);
                }

                return tore;
            }
        }
    }
}
