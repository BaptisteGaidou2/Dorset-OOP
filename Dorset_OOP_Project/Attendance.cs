using System;
namespace Dorset_OOP_Project
{
    public class Attendance
    {
        public Classroom AbsentClass { get; set; }
        public TimeSlot AbsentTimeSlot { get; set; }

        public Attendance(Classroom absentClass, TimeSlot absentTimeSlot)
        {
            AbsentClass = absentClass;
            AbsentTimeSlot = absentTimeSlot;
        }
        public string Information()
        {
            string information= $"{AbsentClass.Name_ID()}\n{AbsentTimeSlot.Information()}";
            return information;
        }
    }
}
