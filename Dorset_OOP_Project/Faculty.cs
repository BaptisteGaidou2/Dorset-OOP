using System;
using System.Collections.Generic;
using System.Text;

namespace Dorset_OOP_Project
{
    public class Faculty : User
    {
        public List<Classroom> ClassroomsTeaching { get; set; }

        public Faculty(string lastName, string firstName) : base(lastName, firstName)
        {
            ClassroomsTeaching = new List<Classroom>();
        }
        public List<Discipline> DisciplinesTeaching()
        {
            List<Discipline> discplinesTeaching = new List<Discipline>();
            foreach (Classroom classroom in ClassroomsTeaching)
            {
                if (!discplinesTeaching.Contains(classroom.ClassRoomDiscipline))
                {
                    discplinesTeaching.Add(classroom.ClassRoomDiscipline);
                }
            }
            return discplinesTeaching;
        }
        public bool AddClassroom(Classroom classroom)
        {
            bool added = false;
            if (ClassroomsTeaching==null||ClassroomsTeaching.Count==0||!ClassroomsTeaching.Contains(classroom))
            {
                ClassroomsTeaching.Add(classroom);
                added = true;
            }
            return added;
        }

        public Faculty(string lastName, string firstName, string email, string password) : base(lastName, firstName, email, password)
        {

            ClassroomsTeaching = new List<Classroom>();
        }

        public Faculty(string lastName, string firstName, string email, string password, int userID) : base(lastName, firstName, email, password, userID)
        {
            ClassroomsTeaching = new List<Classroom>();
        }
    }
}
