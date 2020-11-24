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
        public List<Timetable> Timetables { get; set; }

        

        public Classroom(string classRoomName, List<Faculty> classRoomFaculties,List<Student> classRoomStudents,Discipline classRoomDiscipline, List<Timetable> timetables)
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
        }
        public Classroom(string classRoomName, List<Faculty> classRoomFaculties, List<Student> classRoomStudents)
        {
            ClassroomName = classRoomName;
            ClassRoomFaculties = classRoomFaculties;
            ClassRoomStudents = classRoomStudents;
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
