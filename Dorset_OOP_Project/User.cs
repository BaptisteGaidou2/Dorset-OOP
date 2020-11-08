using System;
using System.Collections.Generic;
using System.Text;

namespace Dorset_OOP_Project
{
    public abstract class User
    {
        private string lastName;
        private string firstName;
        private string email;
        private string password;
        private int userID;
        #region
        public string LastName
        {
            set
            {
                lastName = value;
            }
            get
            {
                return lastName;
            }
        }
        public string FirstName
        {
            set
            {
                firstName = value;
            }
            get
            {
                return firstName;
            }
        }
        public string Email
        {
            set
            {
                email = value;
            }
            get
            {
                return email;
            }
        }
        public string Password
        {
            set
            {
                password = value;
            }
            get
            {
                return password;
            }
        }
        public int UserID
        {
            set
            {
                userID = value;
            }
            get
            {
                return userID;
            }
        }
        #endregion
        public User(string lastName, string firstName)
        {
            this.lastName = lastName;
            this.firstName = firstName;
        }
        public User(string lastName, string firstName, string email, string password)
        {
            this.lastName = lastName;
            this.firstName = firstName;
            this.email = email;
            this.password = password;
        }
        public User(string lastName, string firstName, string email, string password, int userID)
        {
            this.lastName = lastName;
            this.firstName = firstName;
            this.email = email;
            this.password = password;
            this.userID = userID;
        }
        public bool ContainInAList(List<User> list)
        {
            bool contain = false;
            int index = 0;
            while (list != null && index < list.Count && contain == false)
            {
                if (list[index].UserID == userID)
                {
                    contain = true;
                }
                index++;
            }
            return contain;
        }
        public bool ContainInAStudentList(List<Student> list)
        {
            bool contain = false;
            int index = 0;
            while (list != null && index < list.Count && contain == false)
            {
                if (list[index].UserID == userID)
                {
                    contain = true;
                }
                index++;
            }
            return contain;
        }
        public bool ContainInAFacultyList(List<Faculty> list)
        {
            bool contain = false;
            int index = 0;
            while (list != null && index < list.Count && contain == false)
            {
                if (list[index].UserID == userID)
                {
                    contain = true;
                }
                index++;
            }
            return contain;
        }
        public bool Equals(User otherUser)
        {
            bool equal = false;
            if (userID == otherUser.UserID)
            {
                equal = true;
            }
            return equal;
        }
        public string PublicApplicationInformation()
        {
            return $"First Name : {firstName} | Last Name : {lastName} | ID : {userID}";
        }
        public string PersonalInformation()
        {
            return $"First Name : {firstName} | Last Name : {lastName} | ID : {userID} | e-mail : {email} | password : {password}";
        }

    }
}
