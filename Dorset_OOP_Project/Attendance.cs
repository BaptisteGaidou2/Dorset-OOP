using System;
namespace Dorset_OOP_Project
{
    public class Attendance
    {
        public Classroom AbsentClass { get; set; }
        public Timetable AbsentTimetable { get; set; }

        public Attendance(Classroom absentClass, Timetable absentTimetable)
        {
            AbsentClass = absentClass;
            AbsentTimetable = absentTimetable;
        }
    }
}
