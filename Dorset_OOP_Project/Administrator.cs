using System;
using System.Collections.Generic;
using System.Text;

namespace Dorset_OOP_Project
{
    public class Administrator : User
    {
        public Administrator(string lastName, string firstName) : base(lastName, firstName)
        {
        }

        public Administrator(string lastName, string firstName, string email, string password) : base(lastName, firstName, email, password)
        {
        }

        public Administrator(string lastName, string firstName, string email, string password, int userID) : base(lastName, firstName, email, password, userID)
        {
        }
        public override string PublicApplicationInformation()
        {
            return $"{base.PublicApplicationInformation()} | type : administrator ";
        }

        public override string PersonalInformation()
        {
            return $"{base.PersonalInformation()} | type : administrator ";
        }


    }
}
