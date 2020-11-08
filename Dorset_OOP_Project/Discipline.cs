using System;
using System.Collections.Generic;
using System.Text;

namespace Dorset_OOP_Project
{
    public class Discipline
    {
        public string DisciplineName { get; set; }
        public int DisciplineID { get; set; }
        public List<Student> StudentEnrolled { get; set; }
        public List<Faculty> FacultyEnrolled { get; set; }

        public Discipline(string disciplineName)
        {
            StudentEnrolled = new List<Student>();
            FacultyEnrolled = new List<Faculty>();
            DisciplineName = disciplineName;
        }
  
        public string PublicInformation()
        {
            return $"name : {DisciplineName} | ID : {DisciplineID}";
        }

        public bool EnrollAStudent(User student)
        {
            if (student is Student)
            {
                Student castStudent = (Student)student;
                if(StudentEnrolled.Contains(castStudent))
                {
                    Console.WriteLine($"The student {castStudent.UserID} had already been enrolled");
                    return false;
                }
                else
                {
                    StudentEnrolled.Add(castStudent);
                    Console.WriteLine($"The student {castStudent.UserID} has been enrolled");
                    return true;
                }
            }
            else
            {
                Console.WriteLine($"This user {student.UserID} isn't a student");
                return false;
            }
        }

        public bool EnrollAFaculty(User faculty)
        {
            if (faculty is Faculty)
            {
                Faculty castFaculty = (Faculty)faculty;
                if(FacultyEnrolled.Contains(castFaculty))
                {
                    Console.WriteLine($"The faculty {castFaculty.UserID} had already been enrolled");
                    return false;
                }
                else
                {
                    FacultyEnrolled.Add(castFaculty);
                    Console.WriteLine($"The faculty {castFaculty.UserID} has been enrolled");
                    return true;
                }
            }
            else
            {
                Console.WriteLine($"This user {faculty.UserID} isn't a faculty");
                return false;
            }
        }
    }
}
