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
        public Classroom(string _classRoomName, List<Faculty> _classRoomFaculties, Discipline _classRoomDiscipline)
        {
            ClassroomName = _classRoomName;
            ClassRoomFaculties = _classRoomFaculties;
            ClassRoomDiscipline = _classRoomDiscipline;
            ClassRoomStudents = new List<Student>();
        }
        public bool AddStudent(Student newStudent)
        {
            bool possible = false;
            if (!ClassRoomStudents.Contains(newStudent))
            {
                ClassRoomStudents.Add(newStudent);
                UpdateClassRoomEnrolment();
                possible = true;
            }
            return possible;
        } 
        public bool UpdateClassRoomEnrolment()
        {
            bool possible = false;
            if (ClassRoomFaculties != null && ClassRoomStudents != null && ClassRoomStudents.Count != 0)
            {
                possible = true;
                for (int indexStudent = 0; indexStudent < ClassRoomStudents.Count; indexStudent++)
                {
                    ClassRoomDiscipline.EnrollAStudent(ClassRoomStudents[indexStudent]);
                }
                for (int indexFaculty = 0; indexFaculty < ClassRoomStudents.Count; indexFaculty++)
                {
                    ClassRoomDiscipline.EnrollAFaculty(ClassRoomStudents[indexFaculty]);
                }
            }
            return possible;
        }
        public string ClassRoomInformation()
        {
            string information = "";
            information += $"Classroom ID : {ClassRoomID}\nClassroom name : {ClassroomName}\nDiscipline teaching {ClassRoomDiscipline.PublicInformation()}\nFaculties Teaching";
            for (int indexFaculty = 0; indexFaculty < ClassRoomStudents.Count; indexFaculty++)
            {
                information += $"{ClassRoomFaculties[indexFaculty].PublicApplicationInformation()}";
            }
            information += "\nStudents";
            for (int indexStudent = 0; indexStudent < ClassRoomStudents.Count; indexStudent++)
            {
                information += $"\n{ClassRoomStudents[indexStudent].PublicApplicationInformation()}";
            }
            return information;
        }
    }
}
