using System;
using System.Collections.Generic;
using System.Text;

namespace Dorset_OOP_Project
{
    public class Student : User
    {
        private List<Discipline> disciplineStudying;
        public Student(string lastName, string firstName) : base(lastName, firstName)
        {
            disciplineStudying = new List<Discipline>();
        }
        public Student(string lastName, string firstName, string email, string password) : base(lastName, firstName, email, password)
        {
            disciplineStudying = new List<Discipline>();
        }

        public Student(string lastName, string firstName, string email, string password, int userID) : base(lastName, firstName, email, password, userID)
        {
            disciplineStudying = new List<Discipline>();
        }
        public List<Discipline> DisciplineStudying
        {
            get
            {
                return disciplineStudying;
            }
            set
            {
                disciplineStudying = value;
            }
        }
        public bool ContainDiscipline(Discipline discipline)
        {
            bool contain = false;
            int index = 0;
            while (disciplineStudying != null && index < disciplineStudying.Count)
            {
                if (disciplineStudying[index].DisciplineID == discipline.DisciplineID)
                {
                    contain = true;
                }
            }
            return contain;
        }
    }
}
