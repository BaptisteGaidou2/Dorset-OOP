using System;
using System.Collections.Generic;
using System.Text;

namespace Dorset_OOP_Project
{
    public class Application
    {
        private List<Discipline> disciplineList;
        private List<User> userList;
        private int lastUserID;
        private int lastDisciplineID;
        private int currentIndexUser;
        private int currentIndexDiscipline;
        #region
        public List<Discipline> DisciplineList
        {
            set
            {
                disciplineList = value;
            }
            get
            {
                return disciplineList;
            }
        }
        public List<User> UserList
        {
            set
            {
                userList = value;
            }
            get
            {
                return userList;
            }
        }
        public int LastUserID
        {
            set
            {
                lastUserID = value;
            }
            get
            {
                return lastUserID;
            }
        }
        public int LastDisciplineID
        {
            set
            {
                lastDisciplineID = value;
            }
            get
            {
                return lastDisciplineID;
            }
        }
        public int CurrentIndexUser
        {
            set
            {
                currentIndexUser = value;
            }
            get
            {
                return currentIndexUser;
            }
        }
        public int CurrentIndexDiscipline
        {
            set
            {
                currentIndexDiscipline = value;
            }
            get
            {
                return currentIndexDiscipline;
            }
        }
        #endregion
        public Application()
        {
            userList = new List<User>();
            disciplineList = new List<Discipline>();
            Administrator firstAdmin = new Administrator("Admin", "First", "fa@app.com", "0", 0);
            userList.Add(firstAdmin);
            lastUserID = 0;
        }
        public void StartingMenu()
        {
            bool clauseApp = false;
            while (!clauseApp)
            {
                Console.WriteLine("enter the number you want\n1 : Login\n2 : See All User Info\n3 : Save all to files and continue\n4 : Clause and save all to files\n5 : Clause and don't save to files");
                string answer = Console.ReadLine();
                switch (answer)
                {
                    case "1":
                        if (Login())
                        {
                            HomePage();
                        }
                        break;
                    case "2":
                        Console.WriteLine(UsersPublicInformation());
                        break;
                    case "3":
                        break;
                    case "4":
                        clauseApp = true;
                        break;
                    case "5":
                        clauseApp = true;
                        break;
                }
            }
        }
        public bool Login()
        {
            bool succesfullLogin = false;
            bool endingLoginFuction = false;
            while (!endingLoginFuction)
            {
                Console.WriteLine("Enter your userID");
                int userIDAnswer = Convert.ToInt32(Console.ReadLine());
                if (ContainUserID(userIDAnswer))
                {
                    bool tryingTypePassword = true;
                    while (tryingTypePassword)
                    {
                        string wishAnswer = EnterValue.AskingValue("\nEnter what you want to do\n1 : Enter Password\n2 : Change User ID\n3 : Go back to the first menu", 3);
                        if (wishAnswer == "1")
                        {
                            Console.WriteLine("Enter your password");
                            string answerPassword = Console.ReadLine();
                            if (answerPassword == userList[IndexUserID(userIDAnswer)].Password)
                            {
                                Console.WriteLine("Sucessfully logging");
                                tryingTypePassword = false;
                                endingLoginFuction = true;
                                succesfullLogin = true;
                                currentIndexUser = IndexUserID(userIDAnswer);
                            }
                            else
                            {
                                Console.WriteLine("The password entered isn't correct");
                            }
                        }
                        else if (wishAnswer == "2")
                        {
                            tryingTypePassword = false;
                        }
                        else if (wishAnswer == "3")
                        {
                            tryingTypePassword = false;
                            endingLoginFuction = true;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("This userID doesn't exist");
                    string answer = EnterValue.AskingValue("Enter what you want to do\n1 : try again\n2 : go to the first menu", 2);
                    if (answer == "2")
                    {
                        endingLoginFuction = true;
                    }
                }
            }
            return succesfullLogin;
        }
        public void HomePage()
        {
            if (userList != null && currentIndexUser >= 0 && currentIndexUser < userList.Count)
            {
                if (userList[currentIndexUser] is Administrator)
                {
                    HomePage_Administrator();
                }
                else if (userList[currentIndexUser] is Student)
                {
                    HomePage_Student();
                }
                else if (userList[currentIndexUser] is Faculty)
                {
                    HomePage_Faculty();
                }
                currentIndexUser = -1;
                currentIndexDiscipline = -1;
            }
        }
        public void HomePage_Student()
        {
            bool logout = false;
            while (!logout)
            {
                string answer = EnterValue.AskingValue("Enter what you want to do\n1 : See personal information\n2 : Change personal Information\n3 : Log out", 3);
                switch (answer)
                {
                    case "1":
                        Console.WriteLine(userList[currentIndexUser].PersonalInformation());
                        break;
                    case "2":
                        string switchAttribute = EnterValue.AskingValue("enter the information you want to change\n1 : email\n2 : password\n3 : nothing", 3);
                        switch (switchAttribute)
                        {
                            case "1":
                                Console.WriteLine("Enter the new email addres");
                                userList[currentIndexUser].Email = Console.ReadLine();
                                break;
                            case "2":
                                Console.WriteLine("Enter the new password");
                                userList[currentIndexUser].Password = Console.ReadLine();
                                break;
                        }
                        break;
                    case "3":
                        logout = true;
                        break;
                }
            }
        }
        public void HomePage_Administrator()
        {
            bool logout = false;
            while (!logout)
            {
                string answer = EnterValue.AskingValue("Enter what you want to do\n1 : See personal information\n2 : Change personal Information\n3 : Go to the discipline menu\n4 : Add a new user\n5 : Log out", 5);
                switch (answer)
                {
                    case "1":
                        #region
                        Console.WriteLine(userList[currentIndexUser].PersonalInformation());
                        break;
                    #endregion
                    case "2":
                        #region
                        string switchAttribute = EnterValue.AskingValue("enter the information you want to change\n1 : email\n2 : password\n3 : nothing", 3);
                        switch (switchAttribute)
                        {
                            case "1":
                                Console.WriteLine("Enter the new email addres");
                                userList[currentIndexUser].Email = Console.ReadLine();
                                break;
                            case "2":
                                Console.WriteLine("Enter the new password");
                                userList[currentIndexUser].Password = Console.ReadLine();
                                break;
                        }
                        break;
                    #endregion
                    case "3":
                        #region
                        logout = DisciplineMenu_Administrator();
                        break;
                    #endregion
                    case "4":
                        #region
                        bool continueAddAUSer = true;
                        string typeAnswer = EnterValue.AskingValue("Enter what you want to do\n1 : Add a student\n2 : Add a faculty\n3 : Add an administrator\n4 : Go back to the previous menu", 4);
                        {
                            if (typeAnswer == "4")
                            {
                                continueAddAUSer = false;
                            }
                            if (continueAddAUSer)
                            {
                                Console.WriteLine("Enter the first name");
                                string firstNameAnswer = Console.ReadLine();
                                Console.WriteLine("Enter the last name");
                                string lastNameAnswer = Console.ReadLine();
                                Console.WriteLine("Enter the email addres");
                                string emailAnswer = Console.ReadLine();
                                Console.WriteLine("Enter the password for the new user");
                                string passwordAnswer = Console.ReadLine();
                                bool added = AddNewUser(typeAnswer, firstNameAnswer, lastNameAnswer, emailAnswer, passwordAnswer);
                                if (added)
                                {
                                    Console.WriteLine("\nThe user has been added");
                                }
                                else
                                {
                                    Console.WriteLine("\nYou may not have the permission to add the user");
                                }
                            }
                        }
                        break;
                    #endregion
                    case "5":
                        #region
                        logout = true;
                        break;
                        #endregion
                }
            }
        }
        public bool DisciplineMenu_Administrator()
        {
            bool logout = false;
            bool stayInTheDisciplineMenu = true;
            while (stayInTheDisciplineMenu)
            {
                string disciplineAnswer = EnterValue.AskingValue("Enter what you want to do\n1 : Create a new discipline\n2 : Edit a discipline (you will need the ID of the discipline)\n3 : See discipline information\n4 : Go back to the previous menu\n5 : Log out", 5);
                switch (disciplineAnswer)
                {
                    case "1":
                        #region
                        Console.WriteLine("Enter the name of the discipline you want to create");
                        string nameDiscipline = Console.ReadLine();
                        Discipline newDiscipline = new Discipline(nameDiscipline);
                        AddDiscipline(newDiscipline);
                        Console.WriteLine($"You add the discipline, the discipline ID is {disciplineList[disciplineList.Count - 1].DisciplineID}");
                        break;
                    #endregion
                    case "2":
                        #region
                        Console.WriteLine("Enter the ID of the discipline you want to edit");
                        int disciplineIDAnswer = ChoosingDisciplineID();
                        if (disciplineIDAnswer != -1)
                        {
                            bool stayInChooseFunction = true;
                            while (stayInChooseFunction)
                            {
                                currentIndexDiscipline = IndexDisciplineID(disciplineIDAnswer);
                                string enrollAnswer = EnterValue.AskingValue("Enter what you want to do\n1 : Enroll student\n2 : See all student information\n3 : Enroll a faculty\n4 : See all faculty information\n5 : Go back to the previous menu\n6 : Log out", 6);
                                switch (enrollAnswer)
                                {
                                    case "1":
                                        #region
                                        Console.WriteLine("Enter the ID of the student you want to add");
                                        int userIDAnswer = ChoosingStudentID();
                                        if (userIDAnswer != -1)
                                        {
                                            if (disciplineList[currentIndexDiscipline].EnrollAStudent(userList[IndexUserID(userIDAnswer)]))
                                            {
                                                AddDiscplineAttribute_Student(userIDAnswer, disciplineIDAnswer);
                                                Console.WriteLine($"The student with ID {userIDAnswer} has been added");
                                            }
                                            else
                                            {
                                                Console.WriteLine($"The user with this ID {userIDAnswer} can't be added");
                                            }
                                        }
                                        break;
                                    #endregion
                                    case "2":
                                        #region
                                        Console.WriteLine(StudentsInformation());
                                        break;
                                    #endregion
                                    case "3":
                                        #region
                                        Console.WriteLine("Enter the ID of the faculty you want to add");
                                        int facultyIDAnswer = ChoosingAFacultyID();
                                        if (facultyIDAnswer != -1)
                                        {
                                            if (disciplineList[currentIndexDiscipline].EnrollAFaculty(userList[IndexUserID(facultyIDAnswer)]))
                                            {
                                                AddDiscplineAttribute_Faculty(facultyIDAnswer, disciplineIDAnswer);
                                                Console.WriteLine($"The faculty with ID {facultyIDAnswer} has been added");
                                            }
                                            else
                                            {
                                                Console.WriteLine($"The user with this ID {facultyIDAnswer} can't be added");
                                            }
                                        }
                                        break;
                                    #endregion
                                    case "4":
                                        #region
                                        Console.WriteLine(FacultiesInformation());
                                        break;
                                    #endregion
                                    case "5":
                                        #region
                                        stayInChooseFunction = false;
                                        #endregion
                                        break;
                                    case "6":
                                        #region
                                        stayInChooseFunction = false;
                                        stayInTheDisciplineMenu = false;
                                        logout = true;
                                        break;
                                        #endregion
                                }
                            }
                        }
                        break;
                    #endregion
                    case "3":
                        #region
                        Console.WriteLine(DisciplinesInformation());
                        break;
                    #endregion
                    case "4":
                        #region
                        stayInTheDisciplineMenu = false;
                        break;
                    #endregion
                    case "5":
                        #region
                        stayInTheDisciplineMenu = false;
                        logout = true;
                        break;
                        #endregion
                }
            }
            currentIndexDiscipline = -1;
            return logout;
        }
        public void HomePage_Faculty()
        {
            bool logout = false;
            while (!logout)
            {
                string answer = EnterValue.AskingValue("Enter what you want to do\n1 : See personal information\n2 : Change personal Information\n3 : Log out", 3);
                switch (answer)
                {
                    case "1":
                        Console.WriteLine(userList[currentIndexUser].PersonalInformation());
                        break;
                    case "2":
                        string switchAttribute = EnterValue.AskingValue("enter the information you want to change\n1 : email\n2 : password\n3 : nothing", 3);
                        switch (switchAttribute)
                        {
                            case "1":
                                Console.WriteLine("Enter the new email addres");
                                userList[currentIndexUser].Email = Console.ReadLine();
                                break;
                            case "2":
                                Console.WriteLine("Enter the new password");
                                userList[currentIndexUser].Password = Console.ReadLine();
                                break;
                        }
                        break;
                    case "3":
                        logout = true;
                        break;
                }
            }
        }

        public int ChoosingAUserID()
        {
            int iDchoosen = -1;
            bool stayInTheFunction = true;
            while (stayInTheFunction)
            {
                string methodChoiceAnswer = EnterValue.AskingValue("Enter what you want to do\n1 : Choose by enter a user ID\n2 : Choose a userID and the user information\n3 : Go to the previous menu", 3);
                switch (methodChoiceAnswer)
                {
                    case "1":
                        Console.WriteLine("Enter the userID");
                        int userIDAnswer = Convert.ToInt32(Console.ReadLine());
                        if (ContainUserID(userIDAnswer))
                        {
                            iDchoosen = userIDAnswer;
                            stayInTheFunction = false;
                        }
                        else
                        {
                            Console.WriteLine("There is not this user ID in the data base");
                        }
                        break;
                    case "2":
                        Console.WriteLine("All user information :");
                        Console.WriteLine(UsersPublicInformation());
                        Console.WriteLine("Enter the UserID of the user you want to choose");
                        int userIDChoosen = Convert.ToInt32(Console.ReadLine());
                        if (ContainUserID(userIDChoosen))
                        {
                            iDchoosen = userIDChoosen;
                            stayInTheFunction = false;
                        }
                        else
                        {
                            Console.WriteLine("There is not this user ID in the data base");
                        }
                        break;
                    case "3":
                        iDchoosen = -1;
                        stayInTheFunction = false;
                        break;
                }
            }
            return iDchoosen;
        }
        public int ChoosingStudentID()
        {
            int iDchoosen = -1;
            bool stayInTheFunction = true;
            while (stayInTheFunction)
            {
                string methodChoiceAnswer = EnterValue.AskingValue("Enter what you want to do\n1 : Choose by enter a user ID of a student\n2 : Choose a userID and the student information\n3 : Go to the previous menu", 3);
                switch (methodChoiceAnswer)
                {
                    case "1":
                        Console.WriteLine("Enter the userID");
                        int userIDAnswer = Convert.ToInt32(Console.ReadLine());
                        if (ContainUserID(userIDAnswer))
                        {
                            if (userList[IndexUserID(userIDAnswer)] is Student)
                            {
                                iDchoosen = userIDAnswer;
                                stayInTheFunction = false;
                            }
                            else
                            {
                                Console.WriteLine("The userID is not corresponding to a student");
                            }
                        }
                        else
                        {
                            Console.WriteLine("There is not this user ID in the data base");
                        }
                        break;
                    case "2":
                        Console.WriteLine("All student information :");
                        Console.WriteLine(StudentsInformation());
                        Console.WriteLine("Enter the UserID of the student you want to choose");
                        int userIDChoosen = Convert.ToInt32(Console.ReadLine());
                        if (ContainUserID(userIDChoosen))
                        {
                            if (userList[IndexUserID(userIDChoosen)] is Student)
                            {
                                iDchoosen = userIDChoosen;
                                stayInTheFunction = false;
                            }
                            else
                            {
                                Console.WriteLine("The userID is not corresponding to a Student");
                            }
                        }
                        else
                        {
                            Console.WriteLine("There is not this user ID in the data base");
                        }
                        break;
                    case "3":
                        iDchoosen = -1;
                        stayInTheFunction = false;
                        break;
                }
            }
            return iDchoosen;
        }
        public int ChoosingAAdministratorID()
        {
            int iDchoosen = -1;
            bool stayInTheFunction = true;
            while (stayInTheFunction)
            {
                string methodChoiceAnswer = EnterValue.AskingValue("Enter what you want to do\n1 : Choose by enter a user ID of an administrator\n2 : Choose a userID and the administrator information\n3 : Go to the previous menu", 3);
                switch (methodChoiceAnswer)
                {
                    case "1":
                        Console.WriteLine("Enter the userID");
                        int userIDAnswer = Convert.ToInt32(Console.ReadLine());
                        if (ContainUserID(userIDAnswer))
                        {
                            if (userList[IndexUserID(userIDAnswer)] is Administrator)
                            {
                                iDchoosen = userIDAnswer;
                                stayInTheFunction = false;
                            }
                            else
                            {
                                Console.WriteLine("The userID is not corresponding to an aministrator");
                            }
                        }
                        else
                        {
                            Console.WriteLine("There is not this user ID in the data base");
                        }
                        break;
                    case "2":
                        Console.WriteLine("All administrator information :");
                        Console.WriteLine();
                        Console.WriteLine("Enter the UserID of the administrator you want to choose");
                        int userIDChoosen = Convert.ToInt32(Console.ReadLine());
                        if (ContainUserID(userIDChoosen))
                        {
                            if (userList[IndexUserID(userIDChoosen)] is Administrator)
                            {
                                iDchoosen = userIDChoosen;
                                stayInTheFunction = false;
                            }
                            else
                            {
                                Console.WriteLine("The userID is not corresponding to an administrator");
                            }
                        }
                        else
                        {
                            Console.WriteLine("There is not this user ID in the data base");
                        }
                        break;
                    case "3":
                        iDchoosen = -1;
                        stayInTheFunction = false;
                        break;
                }
            }
            return iDchoosen;
        }
        public int ChoosingAFacultyID()
        {
            int iDchoosen = -1;
            bool stayInTheFunction = true;
            while (stayInTheFunction)
            {
                string methodChoiceAnswer = EnterValue.AskingValue("Enter what you want to do\n1 : Choose by enter a user ID of a faculty\n2 : Choose a userID and the faculty information\n3 : Go to the previous menu", 3);
                switch (methodChoiceAnswer)
                {
                    case "1":
                        Console.WriteLine("Enter the userID");
                        int userIDAnswer = Convert.ToInt32(Console.ReadLine());
                        if (ContainUserID(userIDAnswer))
                        {
                            if (userList[IndexUserID(userIDAnswer)] is Faculty)
                            {
                                iDchoosen = userIDAnswer;

                                stayInTheFunction = false;
                            }
                            else
                            {
                                Console.WriteLine("The userID is not corresponding to a faculty");
                            }
                        }
                        else
                        {
                            Console.WriteLine("There is not this user ID in the data base");
                        }
                        break;
                    case "2":
                        Console.WriteLine("All faculty information :");
                        Console.WriteLine(FacultiesInformation());
                        Console.WriteLine("Enter the UserID of the faculty you want to choose");
                        int userIDChoosen = Convert.ToInt32(Console.ReadLine());
                        if (ContainUserID(userIDChoosen))
                        {
                            if (userList[IndexUserID(userIDChoosen)] is Faculty)
                            {
                                iDchoosen = userIDChoosen;
                                stayInTheFunction = false;
                            }
                            else
                            {
                                Console.WriteLine("The userID is not corresponding to an faculty");
                            }
                        }
                        else
                        {
                            Console.WriteLine("There is not this user ID in the data base");
                        }
                        break;
                    case "3":
                        iDchoosen = -1;
                        stayInTheFunction = false;
                        break;
                }
            }
            return iDchoosen;
        }
        public int ChoosingDisciplineID()
        {
            int iDchoosen = -1;
            bool stayInTheFunction = true;
            while (stayInTheFunction)
            {
                string methodChoiceAnswer = EnterValue.AskingValue("Enter what you want to do\n1 : Choose by enter a discipline ID\n2 : Choose a discipline ID and the see disciplines information\n3 : Go to the previous menu", 3);
                switch (methodChoiceAnswer)
                {
                    case "1":
                        Console.WriteLine("Enter the disciplineID");
                        int disciplineIDanswer = Convert.ToInt32(Console.ReadLine());
                        if (ContainDisciplineID(disciplineIDanswer))
                        {
                            iDchoosen = disciplineIDanswer;
                            stayInTheFunction = false;
                        }
                        else
                        {
                            Console.WriteLine("There is not this discipline ID in the data base");
                        }
                        break;
                    case "2":
                        Console.WriteLine("All discipline information :");
                        Console.WriteLine(DisciplinesInformation());
                        Console.WriteLine("Enter the disciplineID of the discipline you want to choose");
                        int disciplineIDChoosen = Convert.ToInt32(Console.ReadLine());
                        if (ContainDisciplineID(disciplineIDChoosen))
                        {
                            iDchoosen = disciplineIDChoosen;
                            stayInTheFunction = false;
                        }
                        else
                        {
                            Console.WriteLine("There is not this discipline ID in the data base");
                        }
                        break;
                    case "3":
                        iDchoosen = -1;
                        stayInTheFunction = false;
                        break;
                }
            }
            return iDchoosen;
        }

        public int PutANewDisciplineID()
        {
            lastDisciplineID++;
            return lastDisciplineID;
        }
        public int PutANewUserID()
        {
            lastUserID++;
            return lastUserID;
        }

        public bool AddNewUser(User newUser)
        {
            bool added = false;
            if (currentIndexUser != -1 && userList[currentIndexUser] is Administrator)
            {
                userList.Add(newUser);
                userList[userList.Count - 1].UserID = PutANewUserID();
                added = true;
            }
            return added;
        }
        public bool AddNewUser(string type, string firstName, string lastName, string email, string password)
        {
            bool added = false;
            if (currentIndexUser != -1 && userList[currentIndexUser] is Administrator)
            {
                switch (type)
                {
                    case "1":
                        added = AddNewStudent(firstName, lastName, email, password);
                        break;
                    case "2":
                        added = AddNewFaculty(firstName, lastName, email, password);
                        break;
                    case "3":
                        added = AddNewAdministrator(firstName, lastName, email, password);
                        break;
                }
            }
            return added;
        }
        public bool AddNewStudent(string firstName, string lastName, string email, string password)
        {
            bool added = false;
            Student newStudent = new Student(firstName, lastName, email, password);
            userList.Add(newStudent);
            userList[userList.Count - 1].UserID = PutANewUserID();
            added = true;
            return added;

        }
        public bool AddNewFaculty(string firstName, string lastName, string email, string password)
        {
            bool added = false;
            Faculty newStudent = new Faculty(firstName, lastName, email, password);
            userList.Add(newStudent);
            userList[userList.Count - 1].UserID = PutANewUserID();
            added = true;
            return added;
        }
        public bool AddNewAdministrator(string firstName, string lastName, string email, string password)
        {
            bool added = false;
            Administrator newStudent = new Administrator(firstName, lastName, email, password);
            userList.Add(newStudent);
            userList[userList.Count - 1].UserID = PutANewUserID();
            added = true;
            return added;
        }
        public void AddDiscipline(Discipline newDiscipline)
        {
            disciplineList.Add(newDiscipline);
            disciplineList[disciplineList.Count - 1].DisciplineID = PutANewDisciplineID();
        }
        public bool AddDiscplineAttribute_Student(int userIDStudent, int disciplineID)
        {
            bool added = false;
            if (ContainUserID(userIDStudent) && ContainDisciplineID(disciplineID))
            {
                int indexUserList = IndexUserID(userIDStudent);
                int indexdDisciplineList = IndexDisciplineID(disciplineID);
                if (UserList[indexUserList] is Student)
                {
                    Student studentAddingDiscipline = (Student)UserList[indexUserList];
                    if (!studentAddingDiscipline.ContainDiscipline(disciplineList[indexdDisciplineList]))
                    {
                        studentAddingDiscipline.DisciplineStudying.Add(disciplineList[indexdDisciplineList]);
                        added = true;
                    }
                }
            }
            return added;
        }
        public bool AddDiscplineAttribute_Faculty(int userIDFaculty, int disciplineID)
        {
            bool added = false;
            if (ContainUserID(userIDFaculty) && ContainDisciplineID(disciplineID))
            {
                int indexList = IndexUserID(userIDFaculty);
                int indexdDisciplineList = IndexDisciplineID(disciplineID);
                if (UserList[indexList] is Faculty)
                {
                    Faculty studentAddingDiscipline = (Faculty)UserList[indexList];
                    if (!studentAddingDiscipline.ContainDiscipline(disciplineList[indexdDisciplineList]))
                    {
                        studentAddingDiscipline.DisciplineTeaching.Add(disciplineList[indexdDisciplineList]);
                        added = true;
                    }
                }
            }
            return added;
        }

        public bool ContainUserID(int userID)
        {
            bool contain = false;
            int index = 0;
            while (userList != null && index < userList.Count && contain == false)
            {
                if (userList[index].UserID == userID)
                {
                    contain = true;
                }
                index++;
            }
            return contain;
        }
        public int IndexUserID(int userID)
        {
            int indexUserID = -1;
            if (ContainUserID(userID))
            {
                int indexList = 0;
                while (userList != null && indexUserID == -1 && indexList < userList.Count)
                {
                    if (userList[indexList].UserID == userID)
                    {
                        indexUserID = indexList;
                    }
                    indexList++;
                }
            }
            return indexUserID;
        }
        public bool ContainDisciplineID(int disciplineID)
        {
            bool contain = false;
            int index = 0;
            while (disciplineList != null && index < disciplineList.Count && contain == false)
            {
                if (disciplineList[index].DisciplineID == disciplineID)
                {
                    contain = true;
                }
                index++;
            }
            return contain;
        }
        public int IndexDisciplineID(int disciplineID)
        {
            int indexDisciplineID = -1;
            if (ContainDisciplineID(disciplineID))
            {
                int indexList = 0;
                while (disciplineList != null && indexDisciplineID == -1 && indexList < disciplineList.Count)
                {
                    if (disciplineList[indexList].DisciplineID == disciplineID)
                    {
                        indexDisciplineID = indexList;
                    }
                    indexList++;
                }
            }
            return indexDisciplineID;
        }

        public string UsersPublicInformation()
        {
            string information = "";
            for (int index = 0; index < userList.Count; index++)
            {
                information += $"{userList[index].PublicApplicationInformation()}\n";
            }
            return information;
        }
        public string StudentsInformation()
        {
            string information = "";
            int numberStudent = 0;
            if (userList != null || userList.Count != 0)
            {
                for (int index = 0; index < userList.Count; index++)
                {
                    if (userList[index] is Student)
                    {
                        Student Studentinformation = (Student)userList[index];
                        information += $"[{numberStudent}] {userList[index].PublicApplicationInformation()}\n";
                        numberStudent++;
                    }
                }
            }
            if (numberStudent == 0)
            {
                information += "There is no student user";
            }
            return information;
        }
        public string FacultiesInformation()
        {
            string information = "";
            int numberFaculties = 0;
            if (userList != null || userList.Count != 0)
            {
                for (int index = 0; index < userList.Count; index++)
                {
                    if (userList[index] is Faculty)
                    {
                        Faculty Studentinformation = (Faculty)userList[index];
                        information += $"[{numberFaculties}] {userList[index].PublicApplicationInformation()}\n";
                        numberFaculties++;
                    }
                }
            }
            if (numberFaculties == 0)
            {
                information += "There is no faculty user";
            }
            return information;
        }
        public string AdministratorsInformation()
        {
            string information = "";
            int numberAdministrator = 0;
            if (userList != null || userList.Count != 0)
            {
                for (int index = 0; index < userList.Count; index++)
                {
                    if (userList[index] is Faculty)
                    {
                        Faculty Studentinformation = (Faculty)userList[index];
                        information += $"[{numberAdministrator}] {userList[index].PublicApplicationInformation()}\n";
                        numberAdministrator++;
                    }
                }
            }
            if (numberAdministrator == 0)
            {
                information += "There is no administrator user";
            }
            return information;
        }
        public string DisciplinesInformation()
        {
            string information = "";
            if (disciplineList != null && disciplineList.Count != 0)
            {
                for (int index = 0; index < disciplineList.Count; index++)
                {
                    information += $"[{index}] {disciplineList[index].PublicInformation()}\n";
                }
            }
            else
            {
                information += "There is no discipline created";
            }
            return information;
        }
    }
}
