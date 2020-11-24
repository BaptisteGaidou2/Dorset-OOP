using System;
using System.Collections.Generic;
using System.Text;

namespace Dorset_OOP_Project
{
    public class Student : User
    {
        public List<Classroom> ClassroomStudying { get; set; }
        public List<Attendance> Attendances { get; set; }

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
