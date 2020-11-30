using System;
namespace Dorset_OOP_Project
{
    public class Attendance
    {
        public Classroom AbsentClass { get; set; }
        public TimeSlot AbsentTimeSlot { get; set; }
        public bool Equal(Attendance attendanceCompare)
        {
            bool equal = false;
            if (AbsentClass == attendanceCompare.AbsentClass)
            {
                if (AbsentTimeSlot.Teacher != null && attendanceCompare.AbsentTimeSlot.Teacher != null)
                {
                    if (AbsentTimeSlot.Teacher == attendanceCompare.AbsentTimeSlot.Teacher)
                    {
                        if(AbsentTimeSlot.Week== attendanceCompare.AbsentTimeSlot.Week)
                        {
                            if(AbsentTimeSlot.Day == attendanceCompare.AbsentTimeSlot.Day)
                            {
                                if(AbsentTimeSlot.StartingTime == attendanceCompare.AbsentTimeSlot.StartingTime)
                                {
                                    equal = true;
                                }
                            }
                        }
                    }
                }
            }
            return equal;
        }
        public Attendance()
        {

        }
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
