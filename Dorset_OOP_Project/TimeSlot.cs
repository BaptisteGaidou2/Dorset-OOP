using System;
namespace Dorset_OOP_Project
{
    public class TimeSlot
    {
        public int Week { get; set; }
        public int Day { get; set; }
        public int StartingTime { get; set; }
        public Faculty Teacher { get; set; }

        public TimeSlot()
        {

        }
        public TimeSlot(int week,int day, int startingTime, Faculty teacher)
        {
            Week = week;
            Day = day;
            StartingTime = startingTime;
            Teacher = teacher;
        }
        public TimeSlot(int week, int day, int startingTime)
        {
            Week = week;
            Day = day;
            StartingTime = startingTime;
        }
        public string InformationForTimetable()
        {
            string information = $"Start : {StartingTime}H";
            if (Teacher != null)
            {
                information += $"\n{Teacher.FirstName} {Teacher.LastName}";
            }
            return information;
        }
        public string Information ()
        {
            string information = $"Week : {Week} |Day : {GenericFunction.FromIndexToDay(Day)} | Start : {StartingTime}H";
            if (Teacher != null)
            {
                information += $"\nFaculty: { Teacher.PublicApplicationInformation()}";
            }
            return information;
        }
    }
}
