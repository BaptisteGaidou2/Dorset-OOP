using System;
using System.Collections.Generic;
using System.Text;

namespace Dorset_OOP_Project
{
    public class Classroom
    {
        public int ClassRoomID { get; set; }
        public string ClassroomName{ get; set; }
        public Faculty ClassRoomFaculty { get; set; }
        public List<Student> ClassRoomStudents { get; set; }
        public List<Discipline> ClassRoomDisciplines { get; set; }
        public Classroom(string _classRoomName)
        {
            ClassroomName = _classRoomName;
            ClassRoomStudents = new List<Student>();
            ClassRoomDisciplines = new List<Discipline>();
        }
        public bool UpdateClassRoomEnrolment()
        {
            bool possible = false;
            if (ClassRoomFaculty != null && ClassRoomStudents != null && ClassRoomStudents.Count != 0 && ClassRoomDisciplines != null && ClassRoomDisciplines.Count != 0)
            {
                possible = true;
                for (int indexDiscipline = 0; indexDiscipline < ClassRoomDisciplines.Count; indexDiscipline++)
                {
                    ClassRoomDisciplines[indexDiscipline].EnrollAFaculty(ClassRoomFaculty);
                    for(int indexStudent = 0; indexStudent < ClassRoomStudents.Count; indexStudent++)
                    {
                        ClassRoomDisciplines[indexDiscipline].EnrollAStudent(ClassRoomStudents[indexStudent]);
                    }
                }
            }
            return possible;
        }
        public string ClassRoomInformation()
        {
            string information = "";
            information += $"Classroom ID : {ClassRoomID}\nClassroom name : {ClassroomName}\nFaculty teaching {ClassRoomFaculty.PublicApplicationInformation()}";
            for (int indexStudent = 0; indexStudent < ClassRoomStudents.Count; indexStudent++)
            {
                information += $"\n{ClassRoomStudents[indexStudent].PublicApplicationInformation()}";
            }
            return information;
        }
    }
}
