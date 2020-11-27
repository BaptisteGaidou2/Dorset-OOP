using System;
namespace Dorset_OOP_Project
{
    public class Attendance
    {
        public Classroom AbsentClass { get; set; }
        public TimeSlot AbsentTimetable { get; set; }

        public Attendance(Classroom absentClass, TimeSlot absentTimetable)
        {
            AbsentClass = absentClass;
            AbsentTimetable = absentTimetable;
        }
    }
}
