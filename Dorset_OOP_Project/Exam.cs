using System;
using System.Collections.Generic;
using System.Text;

namespace Dorset_OOP_Project
{
    public class Exam
    {
        public int ExamID { get; set; }
        public Discipline ExamDiscipline { get; set; } 
        public string ExamName { get; set; }
        public int Week { get; set; }
        public int Day { get; set; }
        public int StartingHour { get; set; }
        public int EndingHour { get; set; }
        public string Information()
        {
            string information = $"Exam name : {ExamName} | Discipline : {ExamDiscipline.DisciplineName} | ID : {ExamDiscipline.DisciplineID}\nExam Date Week : {Week} Day : {GenericFunction.FromIndexToDay(Day)} StartingHour : {StartingHour}H  EndingHour {EndingHour}H";
            return information;
        }
        public Exam()
        {

        }
        public Exam(Discipline _examDiscipline, string _examName, int _week, int _day, int _startTime, int _endTime)
        {
            ExamDiscipline = _examDiscipline;
            ExamName = _examName;
            Week = _week;
            Day = _day;
            StartingHour = _startTime;
            EndingHour = _endTime;
        }
    }
}
