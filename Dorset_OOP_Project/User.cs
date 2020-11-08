using System;
using System.Collections.Generic;
using System.Text;

namespace Dorset_OOP_Project
{
    public abstract class User
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int UserID { get; set; }


        public User(string lastName, string firstName)
        {
            LastName = lastName;
            FirstName = firstName;
        }
        public User(string lastName, string firstName, string email, string password)
        {
            LastName = lastName;
            FirstName = firstName;
            Email = email;
            Password = password;
        }
        public User(string lastName, string firstName, string email, string password, int userID)
        {
            LastName = lastName;
            FirstName = firstName;
            Email = email;
            Password = password;
            UserID = userID;
        }

        public bool Equals(User otherUser)
        {
            return UserID == otherUser.UserID;
        }

        public string PublicApplicationInformation()
        {
            return $"First Name : {FirstName} | Last Name : {LastName} | ID : {UserID}";
        }

        public string PersonalInformation()
        {
            return $"First Name : {FirstName} | Last Name : {LastName} | ID : {UserID} | e-mail : {Email} | password : {Password}";
        }
    }
}
