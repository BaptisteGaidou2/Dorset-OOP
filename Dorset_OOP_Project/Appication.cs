using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dorset_OOP_Project
{
    public class Application
    {
        public List<Discipline> DisciplineList { get; set; }
        public List<User> UserList { get; set; }
        public int LastUserID { get; set; }
        public int LastDisciplineID { get; set; }
        public int CurrentIndexUser { get; set; }
        public int CurrentIndexDiscipline { get; set; }
        
        public Application()
        {
            UserList = new List<User>();
            DisciplineList = new List<Discipline>();
            Administrator firstAdmin = new Administrator("Admin", "First", "fa@app.com", "0", 0);
            UserList.Add(firstAdmin);
            LastUserID = 0;
        }

        public void StartingMenu()
        {
            bool closeApp = false;
            while (!closeApp)
            {
                string message = "enter the number you want\n1 : Login\n2 : See All User Info\n3 : Save all to files and continue\n4 : Close and save all to files\n5 : Close and don't save to files";
                int answer = EnterValue.AskingNumber(message, 1, 5);
                switch (answer)
                {
                    case 1:
                        if (Login())
                        {
                            HomePage();
                        }
                        break;
                    case 2:
                        Console.WriteLine(UsersPublicInformation());
                        break;
                    case 3:
                        break;
                    case 4:
                        closeApp = true;
                        break;
                    case 5:
                        closeApp = true;
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
                int userIDAnswer = EnterValue.AskingNumber("Enter your userID", 0, UserList[UserList.Count - 1].UserID);

                if (ContainUserID(userIDAnswer))
                {
                    bool tryingTypePassword = true;
                    while (tryingTypePassword)
                    {
                        int wishAnswer = EnterValue.AskingNumber("\nEnter what you want to do\n1 : Enter Password\n2 : Change User ID\n3 : Go back to the first menu", 1, 3);
                        if (wishAnswer == 1)
                        {
                            Console.WriteLine("Enter your password");
                            string answerPassword = Console.ReadLine();
                            if (answerPassword == UserList[IndexUserID(userIDAnswer)].Password)
                            {
                                Console.WriteLine("Sucessfully logging");
                                tryingTypePassword = false;
                                endingLoginFuction = true;
                                succesfullLogin = true;
                                CurrentIndexUser = IndexUserID(userIDAnswer);
                            }
                            else
                            {
                                Console.WriteLine("The password entered isn't correct");
                            }
                        }
                        else if (wishAnswer == 2)
                        {
                            tryingTypePassword = false;
                        }
                        else if (wishAnswer == 3)
                        {
                            tryingTypePassword = false;
                            endingLoginFuction = true;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("This userID doesn't exist");
                    int answer = EnterValue.AskingNumber("Enter what you want to do\n1 : try again\n2 : go to the first menu", 1, 2);
                    if (answer == 2)
                    {
                        endingLoginFuction = true;
                    }
                }
            }
            return succesfullLogin;
        }

        public void HomePage()
        {
            if (UserList != null && CurrentIndexUser >= 0 && CurrentIndexUser < UserList.Count)
            {
                if (UserList[CurrentIndexUser] is Administrator)
                {
                    HomePage_Administrator();
                }
                else if (UserList[CurrentIndexUser] is Student)
                {
                    HomePage_Student();
                }
                else if (UserList[CurrentIndexUser] is Faculty)
                {
                    HomePage_Faculty();
                }
                CurrentIndexUser = -1;
                CurrentIndexDiscipline = -1;
            }
        }
        public void HomePage_Student()
        {
            bool logout = false;
            while (!logout)
            {
                int answer = EnterValue.AskingNumber("Enter what you want to do\n1 : See personal information\n2 : Change personal Information\n3 : Log out", 1, 3);
                switch (answer)
                {
                    case 1:
                        Console.WriteLine(UserList[CurrentIndexUser].PersonalInformation());
                        break;
                    case 2:
                        int switchAttribute = EnterValue.AskingNumber("enter the information you want to change\n1 : email\n2 : password\n3 : nothing", 1, 3);
                        switch (switchAttribute)
                        {
                            case 1:
                                Console.WriteLine("Enter the new email addres");
                                UserList[CurrentIndexUser].Email = Console.ReadLine();
                                break;
                            case 2:
                                Console.WriteLine("Enter the new password");
                                UserList[CurrentIndexUser].Password = Console.ReadLine();
                                break;
                        }
                        break;
                    case 3:
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
                int answer = EnterValue.AskingNumber("Enter what you want to do\n1 : See personal information\n2 : Change personal Information\n3 : Go to the discipline menu\n4 : Add a new user\n5 : Log out", 1, 5);
                switch (answer)
                {
                    case 1:
                        #region
                        Console.WriteLine(UserList[CurrentIndexUser].PersonalInformation());
                        break;
                    #endregion

                    case 2:
                        #region
                        int switchAttribute = EnterValue.AskingNumber("enter the information you want to change\n1 : email\n2 : password\n3 : nothing", 1, 3);
                        switch (switchAttribute)
                        {
                            case 1:
                                Console.WriteLine("Enter the new email addres");
                                UserList[CurrentIndexUser].Email = Console.ReadLine();
                                break;
                            case 2:
                                Console.WriteLine("Enter the new password");
                                UserList[CurrentIndexUser].Password = Console.ReadLine();
                                break;
                        }
                        break;
                    #endregion

                    case 3:
                        #region
                        logout = DisciplineMenu_Administrator();
                        break;
                    #endregion

                    case 4:
                        #region
                        int typeAnswer = EnterValue.AskingNumber("Enter what you want to do\n1 : Add a student\n2 : Add a faculty\n3 : Add an administrator\n4 : Go back to the previous menu", 1, 4);
                        if (typeAnswer != 4)
                        {
                            Console.WriteLine("Enter the first name");
                            string firstNameAnswer = Console.ReadLine();
                            Console.WriteLine("Enter the last name");
                            string lastNameAnswer = Console.ReadLine();
                            Console.WriteLine("Enter the email addres");
                            string emailAnswer = Console.ReadLine();
                            Console.WriteLine("Enter the password for the new user");
                            string passwordAnswer = Console.ReadLine();
                            AddNewUser(typeAnswer, firstNameAnswer, lastNameAnswer, emailAnswer, passwordAnswer); // typeAnswer is the type of user to create
                        }
                        break;
                    #endregion

                    case 5:
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
                int disciplineAnswer = EnterValue.AskingNumber("Enter what you want to do\n1 : Create a new discipline\n2 : Edit a discipline (you will need the ID of the discipline)\n3 : See discipline information\n4 : Go back to the previous menu\n5 : Log out", 1, 5);
                switch (disciplineAnswer)
                {
                    case 1:
                        #region
                        Console.WriteLine("Enter the name of the discipline you want to create");
                        string nameDiscipline = Console.ReadLine();
                        Discipline newDiscipline = new Discipline(nameDiscipline);
                        AddDiscipline(newDiscipline);
                        Console.WriteLine($"You add the discipline, the discipline ID is {DisciplineList[DisciplineList.Count - 1].DisciplineID}");
                        break;
                    #endregion
                    case 2:
                        #region
                        Console.WriteLine("Enter the ID of the discipline you want to edit");
                        int disciplineIDAnswer = ChoosingDisciplineID();
                        if (disciplineIDAnswer != -1)
                        {
                            bool stayInChooseFunction = true;
                            while (stayInChooseFunction)
                            {
                                CurrentIndexDiscipline = IndexDisciplineID(disciplineIDAnswer);
                                int enrollAnswer = EnterValue.AskingNumber("Enter what you want to do\n1 : Enroll student\n2 : See all student information\n3 : Enroll a faculty\n4 : See all faculty information\n5 : Go back to the previous menu\n6 : Log out", 1, 6);
                                switch (enrollAnswer)
                                {
                                    case 1:
                                        #region
                                        Console.WriteLine("Enter the ID of the student you want to add");
                                        int userIDAnswer = ChoosingStudentID();
                                        if (userIDAnswer != -1)
                                        {
                                            if (DisciplineList[CurrentIndexDiscipline].EnrollAStudent(UserList[IndexUserID(userIDAnswer)]))
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
                                    case 2:
                                        #region
                                        Console.WriteLine(StudentsInformation());
                                        break;
                                    #endregion
                                    case 3:
                                        #region
                                        Console.WriteLine("Enter the ID of the faculty you want to add");
                                        int facultyIDAnswer = ChoosingAFacultyID();
                                        if (facultyIDAnswer != -1)
                                        {
                                            if (DisciplineList[CurrentIndexDiscipline].EnrollAFaculty(UserList[IndexUserID(facultyIDAnswer)]))
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
                                    case 4:
                                        #region
                                        Console.WriteLine(FacultiesInformation());
                                        break;
                                    #endregion
                                    case 5:
                                        #region
                                        stayInChooseFunction = false;
                                        #endregion
                                        break;
                                    case 6:
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
                    case 3:
                        #region
                        Console.WriteLine(DisciplinesInformation());
                        break;
                    #endregion
                    case 4:
                        #region
                        stayInTheDisciplineMenu = false;
                        break;
                    #endregion
                    case 5:
                        #region
                        stayInTheDisciplineMenu = false;
                        logout = true;
                        break;
                        #endregion
                }
            }
            CurrentIndexDiscipline = -1;
            return logout;
        }
        public void HomePage_Faculty()
        {
            bool logout = false;
            while (!logout)
            {
                int answer = EnterValue.AskingNumber("Enter what you want to do\n1 : See personal information\n2 : Change personal Information\n3 : Log out", 1, 3);
                switch (answer)
                {
                    case 1:
                        Console.WriteLine(UserList[CurrentIndexUser].PersonalInformation());
                        break;
                    case 2:
                        int switchAttribute = EnterValue.AskingNumber("enter the information you want to change\n1 : email\n2 : password\n3 : nothing", 1, 3);
                        switch (switchAttribute)
                        {
                            case 1:
                                Console.WriteLine("Enter the new email addres");
                                UserList[CurrentIndexUser].Email = Console.ReadLine();
                                break;
                            case 2:
                                Console.WriteLine("Enter the new password");
                                UserList[CurrentIndexUser].Password = Console.ReadLine();
                                break;
                        }
                        break;
                    case 3:
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
                int methodChoiceAnswer = EnterValue.AskingNumber("Enter what you want to do\n1 : Choose by enter a user ID\n2 : Choose a userID and the user information\n3 : Go to the previous menu", 1, 3);
                switch (methodChoiceAnswer)
                {
                    case 1:
                        Console.WriteLine("Enter the userID");
                        int userIDAnswer = Convert.ToInt32(Console.ReadLine());
                        if (ContainUserID(userIDAnswer))
                        {
                            iDchoosen = userIDAnswer;
                            stayInTheFunction = false;
                        }
                        else
                        {
                            Console.WriteLine("There is not this user ID in the database");
                        }
                        break;
                    case 2:
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
                            Console.WriteLine("There is not this user ID in the database");
                        }
                        break;
                    case 3:
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
                int methodChoiceAnswer = EnterValue.AskingNumber("Enter what you want to do\n1 : Choose by enter a user ID of a student\n2 : Choose a userID and the student information\n3 : Go to the previous menu", 1, 3);
                switch (methodChoiceAnswer)
                {
                    case 1:
                        Console.WriteLine("Enter the userID");
                        int userIDAnswer = Convert.ToInt32(Console.ReadLine());
                        if (ContainUserID(userIDAnswer))
                        {
                            if (UserList[IndexUserID(userIDAnswer)] is Student)
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
                            Console.WriteLine("There is not this user ID in the database");
                        }
                        break;
                    case 2:
                        Console.WriteLine("All student information :");
                        Console.WriteLine(StudentsInformation());
                        Console.WriteLine("Enter the UserID of the student you want to choose");
                        int userIDChoosen = Convert.ToInt32(Console.ReadLine());
                        if (ContainUserID(userIDChoosen))
                        {
                            if (UserList[IndexUserID(userIDChoosen)] is Student)
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
                            Console.WriteLine("There is not this user ID in the database");
                        }
                        break;
                    case 3:
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
                int methodChoiceAnswer = EnterValue.AskingNumber("Enter what you want to do\n1 : Choose by enter a user ID of an administrator\n2 : Choose a userID and the administrator information\n3 : Go to the previous menu", 1, 3);
                switch (methodChoiceAnswer)
                {
                    case 1:
                        Console.WriteLine("Enter the userID");
                        int userIDAnswer = Convert.ToInt32(Console.ReadLine());
                        if (ContainUserID(userIDAnswer))
                        {
                            if (UserList[IndexUserID(userIDAnswer)] is Administrator)
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
                            Console.WriteLine("There is not this user ID in the database");
                        }
                        break;
                    case 2:
                        Console.WriteLine("All administrator information :");
                        Console.WriteLine();
                        Console.WriteLine("Enter the UserID of the administrator you want to choose");
                        int userIDChoosen = Convert.ToInt32(Console.ReadLine());
                        if (ContainUserID(userIDChoosen))
                        {
                            if (UserList[IndexUserID(userIDChoosen)] is Administrator)
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
                            Console.WriteLine("There is not this user ID in the database");
                        }
                        break;
                    case 3:
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
                int methodChoiceAnswer = EnterValue.AskingNumber("Enter what you want to do\n1 : Choose by enter a user ID of a faculty\n2 : Choose a userID and the faculty information\n3 : Go to the previous menu", 1, 3);
                switch (methodChoiceAnswer)
                {
                    case 1:
                        Console.WriteLine("Enter the userID");
                        int userIDAnswer = Convert.ToInt32(Console.ReadLine());
                        if (ContainUserID(userIDAnswer))
                        {
                            if (UserList[IndexUserID(userIDAnswer)] is Faculty)
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
                            Console.WriteLine("There is not this user ID in the database");
                        }
                        break;
                    case 2:
                        Console.WriteLine("All faculty information :");
                        Console.WriteLine(FacultiesInformation());
                        Console.WriteLine("Enter the UserID of the faculty you want to choose");
                        int userIDChoosen = Convert.ToInt32(Console.ReadLine());
                        if (ContainUserID(userIDChoosen))
                        {
                            if (UserList[IndexUserID(userIDChoosen)] is Faculty)
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
                            Console.WriteLine("There is not this user ID in the database");
                        }
                        break;
                    case 3:
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
                int methodChoiceAnswer = EnterValue.AskingNumber("Enter what you want to do\n1 : Choose by enter a discipline ID\n2 : Choose a discipline ID and the see disciplines information\n3 : Go to the previous menu", 1, 3);
                switch (methodChoiceAnswer)
                {
                    case 1:
                        Console.WriteLine("Enter the disciplineID");
                        int disciplineIDanswer = Convert.ToInt32(Console.ReadLine());
                        if (ContainDisciplineID(disciplineIDanswer))
                        {
                            iDchoosen = disciplineIDanswer;
                            stayInTheFunction = false;
                        }
                        else
                        {
                            Console.WriteLine("There is not this discipline ID in the database");
                        }
                        break;
                    case 2:
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
                            Console.WriteLine("There is not this discipline ID in the database");
                        }
                        break;
                    case 3:
                        iDchoosen = -1;
                        stayInTheFunction = false;
                        break;
                }
            }
            return iDchoosen;
        }

        public int PutANewDisciplineID()
        {
            LastDisciplineID++;
            return LastDisciplineID;
        }
        public int PutANewUserID()
        {
            LastUserID++;
            return LastUserID;
        }

        public bool AddNewUser(User newUser)
        {
            bool added = false;
            if (CurrentIndexUser != -1 && UserList[CurrentIndexUser] is Administrator)
            {
                UserList.Add(newUser);
                UserList[UserList.Count - 1].UserID = PutANewUserID();
                added = true;
            }
            return added;
        }
        public bool AddNewUser(int type, string firstName, string lastName, string email, string password)
        {
            if (CurrentIndexUser != -1 && UserList[CurrentIndexUser] is Administrator)
            {
                switch (type)
                {
                    case 1:
                        AddNewStudent(firstName, lastName, email, password);
                        return true;

                    case 2:
                        AddNewFaculty(firstName, lastName, email, password);
                        return true;

                    case 3:
                        AddNewAdministrator(firstName, lastName, email, password);
                        return true;
                }
            }
            return false;
        }

        public void AddNewStudent(string firstName, string lastName, string email, string password)
        {
            UserList.Add(new Student(firstName, lastName, email, password, PutANewUserID()));
        }

        public void AddNewFaculty(string firstName, string lastName, string email, string password)
        {
            UserList.Add(new Faculty(firstName, lastName, email, password, PutANewUserID()));
        }

        public void AddNewAdministrator(string firstName, string lastName, string email, string password)
        {
            UserList.Add(new Administrator(firstName, lastName, email, password, PutANewUserID()));
        }

        public void AddDiscipline(Discipline newDiscipline)
        {
            newDiscipline.DisciplineID = PutANewDisciplineID();
            DisciplineList.Add(newDiscipline);
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
                    if (!studentAddingDiscipline.ContainDiscipline(DisciplineList[indexdDisciplineList]))
                    {
                        studentAddingDiscipline.DisciplineStudying.Add(DisciplineList[indexdDisciplineList]);
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
                    if (!studentAddingDiscipline.ContainDiscipline(DisciplineList[indexdDisciplineList]))
                    {
                        studentAddingDiscipline.DisciplineTeaching.Add(DisciplineList[indexdDisciplineList]);
                        added = true;
                    }
                }
            }
            return added;
        }

        public bool ContainUserID(int userID)
        {
            return UserList.Any(i => i.UserID == userID);
        }

        public int IndexUserID(int userID)
        {
            return UserList.FindIndex(i => i.UserID == userID);
        }

        public bool ContainDisciplineID(int disciplineID)
        {
            return DisciplineList.Any(i => i.DisciplineID== disciplineID);
        }

        public int IndexDisciplineID(int disciplineID)
        {
            return DisciplineList.FindIndex(i => i.DisciplineID == disciplineID);
        }

        public string UsersPublicInformation()
        {
            string information = "";
            for (int index = 0; index < UserList.Count; index++)
            {
                information += $"{UserList[index].PublicApplicationInformation()}\n";
            }
            return information;
        }

        public string StudentsInformation()
        {
            string information = "";
            int numberStudent = 0;
            if (UserList != null || UserList.Count != 0)
            {
                for (int index = 0; index < UserList.Count; index++)
                {
                    if (UserList[index] is Student)
                    {
                        Student Studentinformation = (Student)UserList[index];
                        information += $"[{numberStudent}] {UserList[index].PublicApplicationInformation()}\n";
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
            if (UserList != null || UserList.Count != 0)
            {
                for (int index = 0; index < UserList.Count; index++)
                {
                    if (UserList[index] is Faculty)
                    {
                        Faculty Studentinformation = (Faculty)UserList[index];
                        information += $"[{numberFaculties}] {UserList[index].PublicApplicationInformation()}\n";
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
            if (UserList != null || UserList.Count != 0)
            {
                for (int index = 0; index < UserList.Count; index++)
                {
                    if (UserList[index] is Faculty)
                    {
                        Faculty Studentinformation = (Faculty)UserList[index];
                        information += $"[{numberAdministrator}] {UserList[index].PublicApplicationInformation()}\n";
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
            if (DisciplineList != null && DisciplineList.Count != 0)
            {
                for (int index = 0; index < DisciplineList.Count; index++)
                {
                    information += $"[{index}] {DisciplineList[index].PublicInformation()}\n";
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
