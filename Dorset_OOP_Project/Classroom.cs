using System;
using System.Collections.Generic;
using System.Text;

namespace Dorset_OOP_Project
{
    public class Classroom
    {
        public int ClassRoomID { get; set; }
        public string ClassroomName { get; set; }
        public List<Faculty>ClassRoomFaculties { get; set; }
        public List<Student> ClassRoomStudents { get; set; }
        public Discipline ClassRoomDiscipline { get; set; }
        public List<TimeSlot> Timetables { get; set; }
        public void EditTimeTable()
        {
            bool stayInTheEditingFunction = true;
            while (stayInTheEditingFunction)
            {
                int editChoice = EnterValue.AskingNumber("Enter what you want to do\n1 : Add a time slot\n2 : Remove a time slot\n3 : Add a faculty to a time slot\n4 : see all time slots\n5 : return to the previous menu", 1, 5);
                switch (editChoice)
                {
                    case 1:
                        int week = EnterValue.AskingNumber("Enter the number of the week between 1 and 10; or enter 0 for all the weeks", 0, 10);
                        List<int> weeks = new List<int>();
                        if (week == 0)
                        {
                            for (int i = 1; i <= 10; i++)
                            {
                                weeks.Add(i);
                            }
                        }
                        else
                        {
                            weeks.Add(week);
                        }
                        int day = EnterValue.AskingNumber("Enter the day you want \n1=Monday\n2=Tuesday\n3=Wednesday\n4=Thursday\n5=Friday\n6=Saturday", 1,6);
                        int startingTime = EnterValue.AskingNumber("Enter the starting time between  8 and 19", 8, 19);
                        //int endingTime = EnterValue.AskingNumber($"Enter the ending time between {startingTime+1} and 20", startingTime+1, 20);
                        int facultyID = -1;
                        if (ClassRoomFaculties != null && ClassRoomFaculties.Count != 0)
                        {
                            facultyID = GenericFunction.ChoosingAFacultyID_FromFacultyList(ClassRoomFaculties);
                        }
                        if (facultyID == -1)
                        {
                            Console.WriteLine("You can add a faculty later");
                            for (int i = 0; i < weeks.Count; i++)
                            {
                                Timetables.Add(new TimeSlot(weeks[i],day, startingTime));
                            }
                        }
                        else
                        {
                            for (int i = 0; i < weeks.Count; i++)
                            {
                                Timetables.Add(new TimeSlot(weeks[i], day,startingTime, ClassRoomFaculties[GenericFunction.IndexUserID_FacultyList(facultyID, ClassRoomFaculties)]));
                            }
                        }

                        break;
                    case 2:
                        int choosenIndex = GenericFunction.ChoosingIndexTimeSlotList(Timetables);
                        if (choosenIndex != -1)
                        {
                            Timetables.RemoveAt(choosenIndex);
                        }
                        break;
                    case 3:
                        int indexChoosen = GenericFunction.ChoosingIndexTimeSlotList(Timetables);
                        if (indexChoosen != -1)
                        {
                            int facultyIDAdding = GenericFunction.ChoosingAFacultyID_FromFacultyList(ClassRoomFaculties);
                            if (facultyIDAdding != -1)
                            {
                                Timetables[indexChoosen].Teacher = ClassRoomFaculties[GenericFunction.IndexUserID_FacultyList(facultyIDAdding, ClassRoomFaculties)];
                            }
                        }
                        break;
                    case 4:
                        Console.WriteLine(GenericFunction.TimesSlotsInformation(Timetables));
                        break;
                    case 5:
                        stayInTheEditingFunction = false;
                        break;

                }
            }
        }
       public void RemoveStudentORFaculty()
        {
            int remove = EnterValue.AskingNumber("\nEnter what you want to do\n1 : Remove a student\n2 : Remove a faculty\n3 : go to the previous menu", 1, 3);
            switch (remove)
            {
                case 1:
                    ChoosingRemoveStudent();
                    break;
                case 2:
                    ChoosinRemoveFaculty();
                    break;
            }
        }
        public void ChoosingRemoveStudent()
        {
            Console.WriteLine("Choose the ID of the student you want to remove");
            int id = GenericFunction.ChoosingStudentID_FromListStudent(ClassRoomStudents);
            if (id != -1)
            {
                RemoveStudent(id);
            }
        }
        public void RemoveStudent(int userID)
        {
            ClassRoomStudents[GenericFunction.IndexUserID_StudentList(userID, ClassRoomStudents)].RemoveClassroom_FromAnID(ClassRoomID);
            ClassRoomStudents.RemoveAt(GenericFunction.IndexUserID_StudentList(userID, ClassRoomStudents));
        }
        public void ChoosinRemoveFaculty()
        {
            Console.WriteLine("Choose the ID of the student you want to remove");
            int id = GenericFunction.ChoosingStudentID_FromListStudent(ClassRoomStudents);
            if (id != -1)
            {
                RemoveFaculty(id);
            }
        }
        public void RemoveFaculty(int userID)
        {
            ClassRoomStudents[GenericFunction.IndexUserID_StudentList(userID, ClassRoomStudents)].RemoveClassroom_FromAnID(ClassRoomID);
            ClassRoomStudents.RemoveAt(GenericFunction.IndexUserID_StudentList(userID, ClassRoomStudents));
        }
        public Classroom()
        {
            ClassroomName = classRoomName;
            ClassRoomFaculties = classRoomFaculties;
            ClassRoomStudents = classRoomStudents;
            ClassRoomDiscipline = classRoomDiscipline;
            Timetables = timetables;
        }
        public Classroom(string classRoomName, List<Faculty> classRoomFaculties,List<Student> classRoomStudents,Discipline classRoomDiscipline, List<TimeSlot> timetables)
        {
            ClassroomName = classRoomName;
            ClassRoomFaculties = classRoomFaculties;
            ClassRoomStudents = classRoomStudents;
            ClassRoomDiscipline = classRoomDiscipline;
            Timetables = timetables;
        }
        public Classroom(string classRoomName, List<Faculty> classRoomFaculties, List<Student> classRoomStudents, Discipline classRoomDiscipline)
        {
            ClassroomName = classRoomName;
            ClassRoomFaculties = classRoomFaculties;
            ClassRoomStudents = classRoomStudents;
            ClassRoomDiscipline = classRoomDiscipline;
            Timetables = new List<TimeSlot>();
        }
        public Classroom(string classRoomName, List<Faculty> classRoomFaculties, List<Student> classRoomStudents)
        {
            ClassroomName = classRoomName;
            ClassRoomFaculties = classRoomFaculties;
            ClassRoomStudents = classRoomStudents;
            Timetables = new List<TimeSlot>();
        }
        public Classroom(string classRoomName)
        {
            ClassroomName = classRoomName;
            ClassRoomFaculties = new List<Faculty>();
            ClassRoomStudents = new List<Student>();
            Timetables = new List<TimeSlot>();
        }
        public Classroom(string classRoomName,Discipline discipline)
        {
            ClassroomName = classRoomName;
            ClassRoomDiscipline = discipline;
            ClassRoomFaculties = new List<Faculty>();
            ClassRoomStudents = new List<Student>();
            Timetables = new List<TimeSlot>();
        }
        public bool AddStudent(Student newStudent)
        {
            bool possible = false;
            if (!ClassRoomStudents.Contains(newStudent))
            {
                ClassRoomStudents.Add(newStudent);
                possible = true;
            }
            return possible;
        } 
        public bool AddFaculty(Faculty newfaculty)
        {
            bool possible = false;
            if (!ClassRoomFaculties.Contains(newfaculty))
            {
                ClassRoomFaculties.Add(newfaculty);
                possible = true;
            }
            return possible;
        }
        public string ClassRoomInformation()
        {
            string information = "";
            information += $"Classroom ID : {ClassRoomID}\nClassroom name : {ClassroomName}\nDiscipline teaching :";
            if (ClassRoomDiscipline != null)
            {
                information += $"{ClassRoomDiscipline.PublicInformation()}";
            }
            else
            {
                information += " NaN";
            }
            information += "\nFaculties teaching :";
            if (ClassRoomFaculties != null&&ClassRoomFaculties.Count!=0)
            {
                for (int indexFaculty = 0; indexFaculty < ClassRoomFaculties.Count; indexFaculty++)
                {
                    information += $"\n{ClassRoomFaculties[indexFaculty].PublicApplicationInformation()}";
                }
            }
            else
            {
                information +=" NaN";
            }
            information += "\nStudents :";
            if (ClassRoomStudents != null && ClassRoomStudents.Count!=0)
            {
                for (int indexStudent = 0; indexStudent < ClassRoomStudents.Count; indexStudent++)
                {
                    information += $"\n{ClassRoomStudents[indexStudent].PublicApplicationInformation()}";
                }
            }
            else
            {
                information += " NaN";
            }
            return information;
        }
        public string Name_ID()
        {
            string information = "";
            information += $"Classroom ID : {ClassRoomID}\nClassroom name : {ClassroomName}\nDiscipline :";
            if (ClassRoomDiscipline != null)
            {
                information += $"{ClassRoomDiscipline.PublicInformation()}";
            }
            else
            {
                information += " NaN";
            }
            return information;
        }
    
        public string ClassroomEssentialInformation()
        {
            string information = "";
            information += $"Classroom ID : {ClassRoomID}\nClassroom name : {ClassroomName}\nDiscipline teaching :";
            if (ClassRoomDiscipline != null)
            {
                information += $"{ClassRoomDiscipline.PublicInformation()}";
            }
            else
            {
                information += " NaN";
            }
            information += "\nDiscipline teaching :";
            if (ClassRoomFaculties != null && ClassRoomFaculties.Count != 0)
            {
                for (int indexFaculty = 0; indexFaculty < ClassRoomFaculties.Count; indexFaculty++)
                {
                    information += $"\n{ClassRoomFaculties[indexFaculty].PublicApplicationInformation()}";
                }
            }
            else
            {
                information += " NaN";
            }
            information += "\nNumber of students :"; 
            if (ClassRoomStudents != null && ClassRoomStudents.Count != 0)
            {
                information += $"{ClassRoomStudents.Count}";
            }
            else
            {
                information += " 0";
            }
            return information;
        }
    }
}
