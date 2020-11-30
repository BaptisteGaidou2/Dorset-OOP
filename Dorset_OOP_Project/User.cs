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

        public User()
        {

        }
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

        public virtual string PublicApplicationInformation()
        {
            return $"First Name : {FirstName} | Last Name : {LastName} | ID : {UserID}";
        }
        public virtual string PersonalInformation()
        {
            return $"First Name : {FirstName} | Last Name : {LastName} | ID : {UserID} | e-mail : {Email} | password : {Password}";
        }
        public virtual string GeneralInformation()
        {
            return PublicApplicationInformation();
        }
        public void ChangeInformation()
        {
            int switchAttribute = EnterValue.AskingNumber("enter the information you want to change\n1 : email\n2 : password\n3 : last name\n4 : first name\n5 : nothing", 1, 5);
            switch (switchAttribute)
            {
                case 1:
                    Console.WriteLine("Enter the new email addres");
                    Email = Console.ReadLine();
                    break;
                case 2:
                    Console.WriteLine("Enter the new password");
                    Password = Console.ReadLine();
                    break;
                case 3:
                    Console.WriteLine("Enter your last name");
                    Email = Console.ReadLine();
                    break;
                case 4:
                    Console.WriteLine("Enter your first name");
                    Password = Console.ReadLine();
                    break;
            }
        }
    }
}
