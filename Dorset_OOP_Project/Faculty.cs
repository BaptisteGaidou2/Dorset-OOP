using System;
using System.Collections.Generic;
using System.Text;

namespace Dorset_OOP_Project
{
    public class Faculty : User
    {
        private List<Discipline> disciplineTeaching;
        public Faculty(string lastName, string firstName) : base(lastName, firstName)
        {
            disciplineTeaching = new List<Discipline>();
        }
        public bool ContainDiscipline(Discipline discipline)
        {
            bool contain = false;
            int index = 0;
            while (disciplineTeaching != null && index < disciplineTeaching.Count && contain == true)
            {
                if (disciplineTeaching[index].DisciplineID == discipline.DisciplineID)
                {
                    contain = true;
                }
            }
            return contain;
        }
        public Faculty(string lastName, string firstName, string email, string password) : base(lastName, firstName, email, password)
        {

            disciplineTeaching = new List<Discipline>();
        }

        public Faculty(string lastName, string firstName, string email, string password, int userID) : base(lastName, firstName, email, password, userID)
        {
            disciplineTeaching = new List<Discipline>();
        }
        public List<Discipline> DisciplineTeaching
        {
            get
            {
                return disciplineTeaching;
            }
            set
            {
                disciplineTeaching = value;
            }
        }
    }
}
