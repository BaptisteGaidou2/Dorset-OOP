using System;
using System.Collections.Generic;
using System.Text;

namespace Dorset_OOP_Project
{
    public class Student : User
    {
        public List<Discipline> DisciplineStudying { get; set; }

        public Student(string lastName, string firstName) : base(lastName, firstName)
        {
            DisciplineStudying = new List<Discipline>();
        }
        public Student(string lastName, string firstName, string email, string password) : base(lastName, firstName, email, password)
        {
            DisciplineStudying = new List<Discipline>();
        }

        public Student(string lastName, string firstName, string email, string password, int userID) : base(lastName, firstName, email, password, userID)
        {
            DisciplineStudying = new List<Discipline>();
        }

        public void AddDiscipline(Discipline discipline)
        {
            DisciplineStudying.Add(discipline);
        }

        public void RemoveDiscipline(Discipline discipline)
        {
            DisciplineStudying.Remove(discipline);
        }

        public bool ContainDiscipline(Discipline discipline)
        {
            return DisciplineStudying.Contains(discipline);
        }
    }
}
