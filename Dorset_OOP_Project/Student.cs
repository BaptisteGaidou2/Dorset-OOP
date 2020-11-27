using System;
using System.Collections.Generic;
using System.Text;

namespace Dorset_OOP_Project
{
    public class Student : User
    {
        public List<Classroom> ClassroomStudying { get; set; }
        public List<Attendance> Attendances { get; set; }
        public void RemoveClassroom_FromAnID(int classroomID)
        {
            if (GenericFunction.ContainClassroomID(classroomID, ClassroomStudying))
            {
                ClassroomStudying.RemoveAt(GenericFunction.IndexClassroomID(classroomID,ClassroomStudying));
            }
        }
        public Student(string lastName, string firstName) : base(lastName, firstName)
        {
            Attendances = new List<Attendance>();
            ClassroomStudying = new List<Classroom>();
        }
        public Student(string lastName, string firstName, string email, string password) : base(lastName, firstName, email, password)
        {
            Attendances = new List<Attendance>();
            ClassroomStudying = new List<Classroom>();
        }

        public Student(string lastName, string firstName, string email, string password, int userID) : base(lastName, firstName, email, password, userID)
        {
            Attendances = new List<Attendance>();
            ClassroomStudying = new List<Classroom>();
        }
        public bool AddClassroom(Classroom classroom)
        {
            bool added = false;
            if (ClassroomStudying==null||ClassroomStudying.Count==0||!ClassroomStudying.Contains(classroom))
            {
                ClassroomStudying.Add(classroom);
                added = true;
            }
            return added;
        }
        public List<Discipline> DisciplinesStudying()
        {
            List<Discipline> discplinesStudying = new List<Discipline>();
            foreach(Classroom classroom in ClassroomStudying)
            {
                if(!discplinesStudying.Contains(classroom.ClassRoomDiscipline))
                {
                    discplinesStudying.Add(classroom.ClassRoomDiscipline);
                }
            }
            return discplinesStudying;
        }
        public List<List<List<string>>> TimeTableList()
        {
            List<List<List<string>>> timetable = new List<List<List<string>>>();
            for (int weekIndex = 0; weekIndex <= 9; weekIndex++)
            {
                List<List<string>> initialiseWeek_index = new List<List<string>>();
                for (int indexDay = 0; indexDay < 7; indexDay++)
                {
                    List<string> initialiseDay_index = new List<string>();
                    for (int indexHours = 0; indexHours <= 12; indexHours++)//hours 8 ->index = 0 hours 20 ->index =12
                    {
                        initialiseDay_index.Add("");
                    }
                    initialiseWeek_index.Add(initialiseDay_index);
                }
                timetable.Add(initialiseWeek_index);
            }
            foreach (Classroom classroom in ClassroomStudying)
            {
                string disciplineName = classroom.ClassRoomDiscipline.DisciplineName;
                foreach(TimeSlot timeslot in classroom.Timetables)
                {
                    timetable[timeslot.Week][timeslot.Day-1][timeslot.StartingTime-8] += $"{disciplineName}\n{timeslot.InformationForTimetable()}";
                }
            }
            return timetable;
        }
        public string TimeTableToString(int week)
        {
            string affichage = "";
            List<List<List<string>>> timetable = TimeTableList();
            for(int indexDay = 0; indexDay < 6; indexDay++)
            {
                if (indexDay == 0)
                {
                    affichage += $"      {GenericFunction.FromIndexToDay(indexDay + 1)}";
                }
                for (int indexHours = 0; indexHours <= 12; indexHours++)//hours 8 ->index = 0 hours 20 ->index =12
                {
                    affichage+=$"{indexHours+8}     ";
                    if (timetable[week][indexDay][indexHours] != "")
                    {
                        affichage+=timetable[week][indexDay][indexHours];
                    }
                    else
                    {
                        affichage += "\n\n\n";
                    }
                }
            }
           

            return affichage;
        }
        
        public void TimeTableMenu()
        {
            bool stay = true;
            while (stay)
            {
                int askingValue = EnterValue.AskingNumber("Enter what you want to do\n1 : see timetable for specific week\n2 : go to the previous menu", 1, 2);
                    switch (askingValue)
                    {
                        case 1:
                            int week = EnterValue.AskingNumber("enter the week you want to see", 1, 10);

                                
                           
                            break;
                        case 2:
                            stay = false;
                            break;
                    }
                }
            }
           
        
        public override string PublicApplicationInformation()
        {
            return $"{base.PublicApplicationInformation()} | type : student";
        }

        public override string PersonalInformation()
        {
            return $"{base.PersonalInformation()} | type : student ";
        }
    }
}
