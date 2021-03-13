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

        public static Dictionary<int, string> GetDateSelectables(Course course, LectureTimeline? timeline = null, int daysNum = 5, string dateFormat = "d/M")
        {
            return FindClosestLectureDates(course, timeline ?? LectureTimeline.Past, daysNum, dateFormat);
        }

        public static Dictionary<int, string> GetDateSelectables(AspNetUsers user, LectureTimeline? timeline = null, int daysNum = 5, string dateFormat = "d/M")
        {
            var courses = user.TeacherCourse.Select(tc => tc.Course);
            var tore = new Dictionary<int, string>(5 * courses.Count());

            foreach (var course in courses)
            {
                var tempDict = FindClosestLectureDates(course, timeline ?? LectureTimeline.Anytime, daysNum, dateFormat);
                if (tempDict != null)
                    foreach (var lectureDatePair in tempDict)
                        tore.Add(lectureDatePair.Key, lectureDatePair.Value);
            }

            return tore;
        }

        public static Dictionary<int, string> FindLectureTimes(Course course, DateTimeOffset date)
        {
            return course.Lecture?.
                    Where(l => l.StartDateTime.Date == date.Date && l.Status == LectureStatus.Scheduled).
                    ToDictionary(l => l.Id, l => l.StartDateTime.ToString("t"));
        }

        public static Dictionary<int, string> GetLectureSelectables(Course course, DateTimeOffset dateToPrepareFor)
        {
            return PreparationComponentHelper.FindLectureTimes(course, dateToPrepareFor);
        }

        public static Dictionary<int, string> GetLectureSelectables(AspNetUsers user, DateTimeOffset dateToPrepareFor)
        {
            var courses = user.TeacherCourse.Select(tc => tc.Course);
            var tore = new Dictionary<int, string>();

            foreach (var course in courses)
            {
                var tempDict = PreparationComponentHelper.FindLectureTimes(course, dateToPrepareFor);
                if (tempDict != null)
                    foreach (var lectureTimePair in tempDict)
                        tore.Add(lectureTimePair.Key, lectureTimePair.Value);
            }

            return tore;
        }
    }
}
