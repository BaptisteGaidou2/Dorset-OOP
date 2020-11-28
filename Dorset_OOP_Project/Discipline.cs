using System;
using System.Collections.Generic;
using System.Text;

namespace Dorset_OOP_Project
{
    public class Discipline
    {
        public string DisciplineName { get; set; }
        public int DisciplineID { get; set; }

        public Discipline(string disciplineName)
        {
            DisciplineName = disciplineName;
        }
  
        public string PublicInformation()
        {
            return $"name : {DisciplineName} | ID : {DisciplineID}";
        }
        
    }
}
