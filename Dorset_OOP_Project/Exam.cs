using System;
using System.Collections.Generic;
using System.Text;

namespace Dorset_OOP_Project
{
    public class Exam
    {
        private Discipline ExamDiscipline { get; set; } 
        private string ExamName { get; set; }
        private DateTime StartTime { get; set; }
        private DateTime EndTime { get; set; }
        public Exam(Discipline _examDiscipline,string _examName,DateTime _startTime, DateTime _endTime)
        {
            ExamDiscipline = _examDiscipline;
            ExamName = _examName;
            StartTime = _startTime;
            EndTime = _endTime;
        }
    }
}
