using System;
using System.Collections.Generic;
using System.Text;

namespace Dorset_OOP_Project
{
    public class Discipline
    {
        private string disciplineName;
        private int disciplineID;
        private List<Student> studentEnrolled;
        private List<Faculty> facultyEnrolled;
        public Discipline(string disciplineName)
        {
            studentEnrolled = new List<Student>();
            facultyEnrolled = new List<Faculty>();
            this.disciplineName = disciplineName;

        }
        #region
        public string DisciplineName
        {
            set
            {
                disciplineName = value;
            }
            get
            {
                return disciplineName;
            }
        }
        public int DisciplineID
        {
            set
            {
                disciplineID = value;
            }
            get
            {
                return disciplineID;
            }
        }
        public List<Student> StudentEnrolled
        {
            set
            {
                studentEnrolled = value;
            }
            get
            {
                return studentEnrolled;
            }
        }
        public List<Faculty> FacultyEnrolled
        {
            set
            {
                facultyEnrolled = value;
            }
            get
            {
                return facultyEnrolled;
            }
        }
        #endregion
        public string PublicInformation()
        {
            return $"name : {disciplineName} | ID : {disciplineID}";
        }
        public bool EnrollAStudent(User student)
        {
            bool enrolled = false;
            if (student is Student)
            {
                Student castStudent = (Student)student;
                if (!castStudent.ContainInAStudentList(studentEnrolled))
                {
                    studentEnrolled.Add(castStudent);
                    Console.WriteLine($"The student {castStudent.UserID} has been enrolled");
                    enrolled = true;
                }
                else
                {
                    Console.WriteLine($"The student {castStudent.UserID} had already been enrolled");
                }
            }
            else
            {
                Console.WriteLine($"This user {student.UserID} isn't a student");
            }
            return enrolled;
        }
        public bool EnrollAFaculty(User faculty)
        {
            bool enrolled = false;
            if (faculty is Faculty)
            {
                Faculty castFaculty = (Faculty)faculty;
                if (!castFaculty.ContainInAFacultyList(facultyEnrolled))
                {
                    facultyEnrolled.Add(castFaculty);
                    Console.WriteLine($"The faculty has {castFaculty.UserID} been enrolled");
                    enrolled = true;
                }
                else
                {
                    Console.WriteLine($"The faculty {castFaculty.UserID} had already been enrolled");
                }
            }
            else
            {
                Console.WriteLine($"This user {faculty.UserID} isn't a faculty");
            }
            return enrolled;
        }
    }
}
