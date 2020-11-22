using System;
namespace Dorset_OOP_Project
{
    public class Timetable
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Faculty Teacher { get; set; }

        public Timetable(DateTime startTime, DateTime endTime, Faculty teacher)
        {
            StartTime = startTime;
            EndTime = endTime;
            Teacher = teacher;
        }
    }
}
