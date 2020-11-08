using System;
using System.Collections.Generic;
using System.Text;

namespace Dorset_OOP_Project
{
    public class Faculty : User
    {
        public List<Discipline> DisciplineTeaching { get; set; }

        public Faculty(string lastName, string firstName) : base(lastName, firstName)
        {
            DisciplineTeaching = new List<Discipline>();
        }
        public bool ContainDiscipline(Discipline discipline)
        {
            int index = 0;
            while (DisciplineTeaching != null && index < DisciplineTeaching.Count)
            {
                if (DisciplineTeaching[index].DisciplineID == discipline.DisciplineID)
                {
                    return true;
                }
            }
            return false;
        }

        public void AddDiscipline(Discipline discipline)
        {
            DisciplineTeaching.Add(discipline);
        }

        public void RemoveDiscipline(Discipline discipline)
        {
            DisciplineTeaching.Remove(discipline);
        }

        public Faculty(string lastName, string firstName, string email, string password) : base(lastName, firstName, email, password)
        {

            DisciplineTeaching = new List<Discipline>();
        }

        public Faculty(string lastName, string firstName, string email, string password, int userID) : base(lastName, firstName, email, password, userID)
        {
            DisciplineTeaching = new List<Discipline>();
        }
    }
}
