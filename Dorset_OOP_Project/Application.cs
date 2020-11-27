using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dorset_OOP_Project
{
    public class Application
    {
        public List<Exam> Exams { get; set; }
        public List<Discipline> DisciplineList { get; set; }
        public List<User> UserList { get; set; }
        public List<Classroom> Classrooms { get; set; }
        public int LastUserID { get; set; }
        public int LastDisciplineID { get; set; }
        public int LastClassroomID { get; set; }
        public int CurrentIndexUser { get; set; }

        public Application()
        {
            UserList = new List<User>();
            DisciplineList = new List<Discipline>();
            Classrooms = new List<Classroom>();
            Administrator firstAdmin = new Administrator("Admin", "First", "fa@app.com", "0", 0);
            UserList.Add(firstAdmin);
            LastUserID = 0;
            LastDisciplineID = -1;
            LastClassroomID = -1;

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
                        Console.WriteLine(GenericFunction.UsersPublicInformation(UserList));
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

                if (GenericFunction.ContainUserID(userIDAnswer,UserList))
                {
                    bool tryingTypePassword = true;
                    while (tryingTypePassword)
                    {
                        int wishAnswer = EnterValue.AskingNumber("\nEnter what you want to do\n1 : Enter Password\n2 : Change User ID\n3 : Go back to the first menu", 1, 3);
                        if (wishAnswer == 1)
                        {
                            Console.WriteLine("Enter your password");
                            string answerPassword = Console.ReadLine();
                            if (answerPassword == UserList[GenericFunction.IndexUserID(userIDAnswer,UserList)].Password)
                            {
                                Console.WriteLine("Sucessfully logging");
                                tryingTypePassword = false;
                                endingLoginFuction = true;
                                succesfullLogin = true;
                                CurrentIndexUser = GenericFunction.IndexUserID(userIDAnswer,UserList);
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
            }
        }
        public void HomePage_Student()
        {
            bool logout = false;
            while (!logout)
            {
                Student currentStudent = (Student)UserList[CurrentIndexUser];
                int answer = EnterValue.AskingNumber("Enter what you want to do\n1 : See personal information\n2 : Change personal Information\n3 : See timetable\n4 : See Notes\n5 : See date Exam\n6 : See discipline studying\n7 : Log out", 1, 7);
                switch (answer)
                {
                    case 1:
                        Console.WriteLine(currentStudent.PersonalInformation());
                        break;
                    case 2:
                        currentStudent.ChangeInformation();
                        break;
                    case 3:
                        currentStudent.TimeTableMenu();
                            break;
                    case 4:
                        currentStudent.SeeAllNotes();
                        break;
                    case 5:
                        if (Exams != null && Exams.Count != 0)
                        {
                            foreach (Exam exam in Exams)
                            {
                                if (currentStudent.DisciplinesStudying()!=null && exam.ExamDiscipline != null)
                                {
                                    if (currentStudent.DisciplinesStudying().Contains(exam.ExamDiscipline))
                                    {
                                        Console.WriteLine(exam.Information());
                                    }
                                }
                            }
                        }
                        
                        break;
                    case 6:
                        Console.WriteLine(GenericFunction.DisciplinesInformation(currentStudent.DisciplinesStudying()));
                        break;
                    case 7:
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
                int answer = EnterValue.AskingNumber("Enter what you want to do\n1 : See personal information\n2 : Change personal Information\n3 : Go to the discipline menu\n4 : Add a new user\n5 : Go to the Classroom Menu\n6 : Log out", 1, 6);
                switch (answer)
                {
                    case 1:
                        #region
                        Console.WriteLine(UserList[CurrentIndexUser].PersonalInformation());
                        break;
                    #endregion
                    case 2:
                        #region
                        UserList[CurrentIndexUser].ChangeInformation();
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
                        logout = ClassRoomMenu_Discipline();
                        #endregion
                        break;
                    case 6:
                        #region
                        logout = true;
                        break;
                        #endregion
                }
            }
        }
        public bool ClassRoomMenu_Discipline()
        {
            bool logout = false;
            bool stayInTheClassRoomMenu = true;
            while (stayInTheClassRoomMenu)
            {
                int classroomAnswer = EnterValue.AskingNumber("Enter what you want to do\n1 : Create a new classroom\n2 : Edit a classroom\n3 : See all classrooms information\n4 : Go back to the previous menu\n5 : Log out", 1, 5);
                switch (classroomAnswer)
                {
                    case 1:
                        #region
                        Console.WriteLine("Enter the classroom name");
                        string classroomNameAnswer = Console.ReadLine();
                        List<Faculty> facultiesAnswer = new List<Faculty>();
                        bool finishAddFaculties = false;
                        while (!finishAddFaculties)
                        {
                            int addOrLeaveAnswer = EnterValue.AskingNumber("Enter do you want to do\n1 : Add a faculty\n2 : Stop adding faculties", 1, 2);
                            switch (addOrLeaveAnswer)
                            {
                                case 1:
                                    int facultyIDAnswer = GenericFunction.ChoosingAFacultyID(UserList);
                                    if (facultyIDAnswer != -1)
                                    {
                                        if (!facultiesAnswer.Contains(UserList[GenericFunction.IndexUserID(facultyIDAnswer,UserList)]))
                                        {
                                            facultiesAnswer.Add((Faculty)UserList[GenericFunction.IndexUserID(facultyIDAnswer,UserList)]);
                                            Console.WriteLine($"{facultiesAnswer[facultiesAnswer.Count - 1].PublicApplicationInformation()} has been added");
                                        }
                                        else
                                        {
                                            Console.WriteLine($"This faculty can't  be added : {facultiesAnswer[facultiesAnswer.Count - 1].PublicApplicationInformation()}\nBecause he had allready been added");
                                        }
                                    }
                                    break;
                                case 2:
                                    finishAddFaculties = true;
                                    break;
                            }
                        }
                        List<Student> studentsAnswer = new List<Student>();
                        bool finishAddStudents = false;
                        while (!finishAddStudents)
                        {
                            int addOrLeaveAnswer = EnterValue.AskingNumber("Enter do you want to do\n1 : Add a student\n2 : Stop adding students", 1, 2);
                            switch (addOrLeaveAnswer)
                            {
                                case 1:
                                    int studentIDAnswer = GenericFunction.ChoosingStudentID(UserList);
                                    if (studentIDAnswer != -1)
                                    {
                                        if (!studentsAnswer.Contains(UserList[GenericFunction.IndexUserID(studentIDAnswer,UserList)]))
                                        {
                                            studentsAnswer.Add((Student)UserList[GenericFunction.IndexUserID(studentIDAnswer,UserList)]);
                                            Console.WriteLine($"{studentsAnswer[studentsAnswer.Count - 1].PublicApplicationInformation()} has been added");
                                        }
                                        else
                                        {
                                            Console.WriteLine($"This student can't  be added : {studentsAnswer[studentsAnswer.Count - 1].PublicApplicationInformation()} \nBecause he had allready been added");
                                        }
                                    }
                                    break;
                                case 2:
                                    finishAddStudents = true;
                                    break;
                            }
                        }
                        bool addADiscipline = false;
                        if (DisciplineList != null && DisciplineList.Count != 0)
                        {
                            int addOrLeaveAnswer = EnterValue.AskingNumber("Enter do you want to do\n1 : Add a discipline\n2 : don't add a discipline", 1, 2);
                            switch (addOrLeaveAnswer)
                            {
                                case 1:
                                    int disciplineIDAnswer = GenericFunction.ChoosingDisciplineID(DisciplineList);
                                    if (disciplineIDAnswer != -1)
                                    {
                                        Discipline disciplineAnswer = DisciplineList[GenericFunction.IndexDisciplineID(disciplineIDAnswer,DisciplineList)];
                                        Classrooms.Add(new Classroom(classroomNameAnswer, facultiesAnswer, studentsAnswer, disciplineAnswer));
                                        Classrooms[Classrooms.Count - 1].ClassRoomID = PutANewClassroomID();
                                        Console.WriteLine($"The classroom has been succesfully created\n{Classrooms[Classrooms.Count - 1].ClassRoomInformation()}");
                                        addADiscipline = true;
                                    }
                                    break;
                            }
                            if (!addADiscipline)
                            {
                                Classrooms.Add(new Classroom(classroomNameAnswer, facultiesAnswer, studentsAnswer));
                                Classrooms[Classrooms.Count - 1].ClassRoomID = PutANewClassroomID();
                                Console.WriteLine($"The classroom has been succesfully created\n{Classrooms[Classrooms.Count - 1].ClassRoomInformation()}");
                            }
                            foreach (Student student in Classrooms[Classrooms.Count - 1].ClassRoomStudents)
                            {
                                student.AddClassroom(Classrooms[Classrooms.Count - 1]);
                            }
                            foreach (Faculty faculty in Classrooms[Classrooms.Count - 1].ClassRoomFaculties)
                            {
                                faculty.AddClassroom(Classrooms[Classrooms.Count - 1]);
                            }
                            break;
                        }
                        break;
                    #endregion
                    case 2:
                        #region
                        int classroomIDanswer = GenericFunction.ChoosingClassroomID(Classrooms);
                        if (classroomIDanswer != -1)
                        {
                            Classroom choosenClassroom = Classrooms[GenericFunction.IndexClassroomID(classroomIDanswer,Classrooms)];
                            bool stayInTheEditClassroom = true;
                            while (stayInTheEditClassroom)
                            {
                                int editClassroomAnswer = EnterValue.AskingNumber("Enter what you want to do\n1 : Add a student\n2 : Add a faculty\n3 : Switch the discipline\n4 : Switch the classroom name\n5 : Edit time slots of the classroom\n6 : See the classroom information\n7 : Go back to the previous menu\n8 : Log out", 1, 8);
                                switch (editClassroomAnswer)
                                {
                                    case 1:
                                        int studentIDAnswer = GenericFunction.ChoosingStudentID(UserList);
                                        if (studentIDAnswer != -1)
                                        {
                                            Student choosenStudent = (Student)UserList[GenericFunction.IndexUserID(studentIDAnswer,UserList)];
                                            bool added = choosenClassroom.AddStudent(choosenStudent);
                                            if (added)
                                            {
                                                choosenStudent.AddClassroom(choosenClassroom);
                                                Console.WriteLine($"{choosenStudent.PublicApplicationInformation()} has been added");
                                            }
                                            else
                                            {
                                                Console.WriteLine($"This student can't  be added : {choosenStudent.PublicApplicationInformation()}\nBecause he had allready been added");

                                            }
                                        }
                                        break;
                                    case 2:
                                        int facultyIDAnswer = GenericFunction.ChoosingAFacultyID(UserList);
                                        if (facultyIDAnswer != -1)
                                        {
                                            Faculty choosenFaculty = (Faculty)UserList[GenericFunction.IndexUserID(facultyIDAnswer,UserList)];
                                            bool added = choosenClassroom.AddFaculty(choosenFaculty);
                                            if (added)
                                            {
                                                choosenFaculty.AddClassroom(choosenClassroom);
                                                Console.WriteLine($"{choosenFaculty.PublicApplicationInformation()} has been added");
                                            }
                                            else
                                            {
                                                Console.WriteLine($"This faculty can't  be added : {choosenFaculty.PublicApplicationInformation()}\nBecause he had allready been added");

                                            }
                                        }
                                        break;
                                    case 3:
                                        int disciplineIDAnswer = GenericFunction.ChoosingDisciplineID(DisciplineList);
                                        if (disciplineIDAnswer != -1)
                                        {
                                            choosenClassroom.ClassRoomDiscipline = DisciplineList[GenericFunction.IndexDisciplineID(disciplineIDAnswer,DisciplineList)];
                                        }
                                        break;
                                    case 4:
                                        Console.WriteLine("Enter the name you want");
                                        choosenClassroom.ClassroomName = Console.ReadLine();
                                        break;
                                    case 5:
                                        choosenClassroom.EditTimeTable();
                                        break;
                                    case 6:
                                        Console.WriteLine(choosenClassroom.ClassRoomInformation());
                                        break;
                                    case 7:
                                        stayInTheEditClassroom = false;
                                        break;
                                    case 8:
                                        stayInTheEditClassroom = false;
                                        stayInTheClassRoomMenu = false;
                                        logout = true;
                                        break;

                                }
                            }
                        }
                        break;
                    #endregion
                    case 3:
                        #region
                        foreach (Classroom classroom in Classrooms)
                        {
                            Console.WriteLine(classroom.ClassRoomInformation());
                        }
                        break;
                    #endregion
                    case 4:
                        #region
                        stayInTheClassRoomMenu = false;
                        break;
                    #endregion
                    case 5:
                        #region
                        stayInTheClassRoomMenu = false;
                        logout = true;
                        break;
                        #endregion
                }
            }
            return logout;
        }
        public bool DisciplineMenu_Administrator()
        {
            bool logout = false;
            bool stayInTheDisciplineMenu = true;
            while (stayInTheDisciplineMenu)
            {
                int disciplineAnswer = EnterValue.AskingNumber("Enter what you want to do\n1 : Create a new discipline\n2 : Edit a discipline\n3 : See all disciplines information\n4 : Go back to the previous menu\n5 : Log out", 1, 5);
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
                        int disciplineIDAnswer = GenericFunction.ChoosingDisciplineID(DisciplineList);
                        if (disciplineIDAnswer != -1)
                        {
                            Discipline choosenDiscipline = DisciplineList[GenericFunction.IndexDisciplineID(disciplineIDAnswer,DisciplineList)];
                            bool stayInChooseFunction = true;
                            while (stayInChooseFunction)
                            {
                                int enrollAnswer = EnterValue.AskingNumber("Enter what you want to do\n1 : Enroll student\n2 : See all students information\n3 : Enroll a faculty\n4 : See all faculty information\n5 : Go back to the previous menu\n6 : Log out", 1, 6);
                                switch (enrollAnswer)
                                {
                                    case 1:
                                        #region
                                        Console.WriteLine("Enter the ID of the student you want to add");
                                        int userIDAnswer = GenericFunction.ChoosingStudentID(UserList);
                                        if (userIDAnswer != -1)
                                        {
                                            if (choosenDiscipline.EnrollAStudent(UserList[GenericFunction.IndexUserID(userIDAnswer,UserList)]))
                                            {
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
                                        Console.WriteLine(GenericFunction.StudentsInformation(UserList));
                                        break;
                                    #endregion
                                    case 3:
                                        #region
                                        Console.WriteLine("Enter the ID of the faculty you want to add");
                                        int facultyIDAnswer = GenericFunction.ChoosingAFacultyID(UserList);
                                        if (facultyIDAnswer != -1)
                                        {
                                            if (choosenDiscipline.EnrollAFaculty(UserList[GenericFunction.IndexUserID(facultyIDAnswer,UserList)]))
                                            {
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
                                        Console.WriteLine(GenericFunction.FacultiesInformation(UserList));
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
                        Console.WriteLine(GenericFunction.DisciplinesInformation(DisciplineList));
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
            return logout;
        }
        public void HomePage_Faculty()
        {
            bool logout = false;
            while (!logout)
            {
                int answer = EnterValue.AskingNumber("Enter what you want to do\n1 : See personal information\n2 : Change personal Information\n3 : See information about one of your student\n4 : Put a mark\n5 : Log out", 1, 5);
                Faculty facultyCurrentUser = (Faculty)UserList[CurrentIndexUser];
                switch (answer)
                {
                    case 1:
                        facultyCurrentUser.PersonalInformation();
                        break;
                    case 2:
                        facultyCurrentUser.ChangeInformation();
                        break;
                    case 3:
                        facultyCurrentUser.MenuSeeStudentInformation();
                        break;
                    case 4://need to start
                        bool addingNotes = true;
                        while (addingNotes)
                        {
                            int answerClassroom = EnterValue.AskingNumber("Enter what you want to do\n1 : Choose a classroom\n2 : Leave this menu", 1, 2);
                            switch (answerClassroom)
                            {
                                case 1:
                                    int classroomID = GenericFunction.ChoosingClassroomID(facultyCurrentUser.ClassroomsTeaching);
                                    if (classroomID != -1)
                                    {
                                        Classroom choosenClassroom = facultyCurrentUser.ClassroomsTeaching[GenericFunction.IndexClassroomID(classroomID, facultyCurrentUser.ClassroomsTeaching)];
                                        bool stayStudent = true;
                                        while (stayStudent)
                                        {
                                            int answerStudent = EnterValue.AskingNumber("Enter what you want to do\n1 : Choose a student\n2 : Choose an other classroom\n3 : Leave this menu", 1, 3);
                                            switch (answerStudent)
                                            {
                                                case 1:
                                                    int studentID = GenericFunction.ChoosingStudentID_FromListStudent(choosenClassroom.ClassRoomStudents);
                                                    if (studentID != -1)
                                                    {
                                                        Student choosenStudent = choosenClassroom.ClassRoomStudents[GenericFunction.IndexUserID_StudentList(studentID, choosenClassroom.ClassRoomStudents)];
                                                        List<Exam> examPossible = new List<Exam>();
                                                        foreach (Exam exam in Exams)
                                                        {
                                                            if (exam.ExamDiscipline == choosenClassroom.ClassRoomDiscipline)
                                                            {
                                                                examPossible.Add(exam);
                                                            }
                                                        }
                                                        bool stayInThisExam = true;
                                                        while (stayInThisExam)
                                                        {
                                                            int answerExam = EnterValue.AskingNumber("Enter what you want to do\n1 : Choose an exam\n2 : Choose an other student\n3 : Choose an other classroom\n4 : Leave this menu", 1, 4);
                                                            switch (answerExam)
                                                            {
                                                                case 1:
                                                                    int indexExam = GenericFunction.ChoosingIndexExamList(examPossible);
                                                                    if (indexExam != -1)
                                                                    {
                                                                        Exam choosenExam = examPossible[indexExam];
                                                                        Console.WriteLine("Enter the note value between 0 and 20");
                                                                        double noteValue = -1;
                                                                        try
                                                                        {
                                                                            noteValue = Convert.ToDouble(Console.ReadLine());
                                                                        }
                                                                        catch (FormatException)
                                                                        {
                                                                            Console.WriteLine("The input was not a double");
                                                                        }
                                                                        if (noteValue >= 0 && noteValue <= 20)
                                                                        {
                                                                            Note newNote = new Note(choosenExam, noteValue);
                                                                            choosenStudent.NotesReceive.Add(newNote);
                                                                            Console.WriteLine("The note has been added");
                                                                        }
                                                                        else
                                                                        {
                                                                            Console.WriteLine("the entered value ins't between 0 and 20");
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        stayInThisExam = false;
                                                                    }
                                                                    break;
                                                                case 2:
                                                                    stayInThisExam = false;
                                                                    break;
                                                                case 3:
                                                                    stayInThisExam = false;
                                                                    stayStudent = false;
                                                                    break;
                                                                case 4:
                                                                    stayInThisExam = false;
                                                                    stayStudent = false;
                                                                    addingNotes = false;
                                                                    break;

                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        stayStudent = false;
                                                    }
                                                    break;
                                                case 2:
                                                    stayStudent = false;
                                                    break;
                                                case 3:
                                                    stayStudent = false;
                                                    addingNotes = false;
                                                    break;

                                            }
                                            
                                        }
                                    }
                                    else
                                    {
                                        addingNotes = false;
                                    }
                                    break;
                                case 2:
                                    addingNotes = false;
                                    break;
                            }
                        }
                        break;
                    case 5:
                        logout = true;
                        break;
                }
            }
        }
        
        //public int ChoosingAUserID()
        //{
        //    int iDchoosen = -1;
        //    bool stayInTheFunction = true;
        //    while (stayInTheFunction)
        //    {
        //        int methodChoiceAnswer = EnterValue.AskingNumber("Enter what you want to do\n1 : Choose by enter a user ID\n2 : Choose a userID and the user information\n3 : Go to the previous menu", 1, 3);
        //        switch (methodChoiceAnswer)
        //        {
        //            case 1:
        //                Console.WriteLine("Enter the userID");
        //                int userIDAnswer = Convert.ToInt32(Console.ReadLine());
        //                if (ContainUserID(userIDAnswer))
        //                {
        //                    iDchoosen = userIDAnswer;
        //                    stayInTheFunction = false;
        //                }
        //                else
        //                {
        //                    Console.WriteLine("There is not this user ID in the database");
        //                }
        //                break;
        //            case 2:
        //                Console.WriteLine("All user information :");
        //                Console.WriteLine(UsersPublicInformation());
        //                Console.WriteLine("Enter the UserID of the user you want to choose");
        //                int userIDChoosen = Convert.ToInt32(Console.ReadLine());
        //                if (ContainUserID(userIDChoosen))
        //                {
        //                    iDchoosen = userIDChoosen;
        //                    stayInTheFunction = false;
        //                }
        //                else
        //                {
        //                    Console.WriteLine("There is not this user ID in the database");
        //                }
        //                break;
        //            case 3:
        //                iDchoosen = -1;
        //                stayInTheFunction = false;
        //                break;
        //        }
        //    }
        //    return iDchoosen;
        //}
        //public int ChoosingStudentID()
        //{
        //    int iDchoosen = -1;
        //    bool stayInTheFunction = true;
        //    while (stayInTheFunction)
        //    {
        //        int methodChoiceAnswer = EnterValue.AskingNumber("Enter what you want to do\n1 : Choose by enter a user ID of a student\n2 : Choose a userID and the student information\n3 : Go to the previous menu", 1, 3);
        //        switch (methodChoiceAnswer)
        //        {
        //            case 1:
        //                Console.WriteLine("Enter the userID");
        //                int userIDAnswer = Convert.ToInt32(Console.ReadLine());
        //                if (ContainUserID(userIDAnswer))
        //                {
        //                    if (UserList[IndexUserID(userIDAnswer)] is Student)
        //                    {
        //                        iDchoosen = userIDAnswer;
        //                        stayInTheFunction = false;
        //                    }
        //                    else
        //                    {
        //                        Console.WriteLine("The userID is not corresponding to a student");
        //                    }
        //                }
        //                else
        //                {
        //                    Console.WriteLine("There is not this user ID in the database");
        //                }
        //                break;
        //            case 2:
        //                Console.WriteLine("All student information :");
        //                Console.WriteLine(StudentsInformation());
        //                Console.WriteLine("Enter the UserID of the student you want to choose");
        //                int userIDChoosen = Convert.ToInt32(Console.ReadLine());
        //                if (ContainUserID(userIDChoosen))
        //                {
        //                    if (UserList[IndexUserID(userIDChoosen)] is Student)
        //                    {
        //                        iDchoosen = userIDChoosen;
        //                        stayInTheFunction = false;
        //                    }
        //                    else
        //                    {
        //                        Console.WriteLine("The userID is not corresponding to a Student");
        //                    }
        //                }
        //                else
        //                {
        //                    Console.WriteLine("There is not this user ID in the database");
        //                }
        //                break;
        //            case 3:
        //                iDchoosen = -1;
        //                stayInTheFunction = false;
        //                break;
        //        }
        //    }
        //    return iDchoosen;
        //}
        //public int ChoosingAAdministratorID()
        //{
        //    int iDchoosen = -1;
        //    bool stayInTheFunction = true;
        //    while (stayInTheFunction)
        //    {
        //        int methodChoiceAnswer = EnterValue.AskingNumber("Enter what you want to do\n1 : Choose by enter a user ID of an administrator\n2 : Choose a userID and the administrator information\n3 : Go to the previous menu", 1, 3);
        //        switch (methodChoiceAnswer)
        //        {
        //            case 1:
        //                Console.WriteLine("Enter the userID");
        //                int userIDAnswer = Convert.ToInt32(Console.ReadLine());
        //                if (ContainUserID(userIDAnswer))
        //                {
        //                    if (UserList[IndexUserID(userIDAnswer)] is Administrator)
        //                    {
        //                        iDchoosen = userIDAnswer;
        //                        stayInTheFunction = false;
        //                    }
        //                    else
        //                    {
        //                        Console.WriteLine("The userID is not corresponding to an aministrator");
        //                    }
        //                }
        //                else
        //                {
        //                    Console.WriteLine("There is not this user ID in the database");
        //                }
        //                break;
        //            case 2:
        //                Console.WriteLine("All administrator information :");
        //                Console.WriteLine();
        //                Console.WriteLine("Enter the UserID of the administrator you want to choose");
        //                int userIDChoosen = Convert.ToInt32(Console.ReadLine());
        //                if (ContainUserID(userIDChoosen))
        //                {
        //                    if (UserList[IndexUserID(userIDChoosen)] is Administrator)
        //                    {
        //                        iDchoosen = userIDChoosen;
        //                        stayInTheFunction = false;
        //                    }
        //                    else
        //                    {
        //                        Console.WriteLine("The userID is not corresponding to an administrator");
        //                    }
        //                }
        //                else
        //                {
        //                    Console.WriteLine("There is not this user ID in the database");
        //                }
        //                break;
        //            case 3:
        //                iDchoosen = -1;
        //                stayInTheFunction = false;
        //                break;
        //        }
        //    }
        //    return iDchoosen;
        //}
        //public int ChoosingAFacultyID()
        //{
        //    int iDchoosen = -1;
        //    bool stayInTheFunction = true;
        //    while (stayInTheFunction)
        //    {
        //        int methodChoiceAnswer = EnterValue.AskingNumber("Enter what you want to do\n1 : Choose by enter a user ID of a faculty\n2 : Choose a userID and the faculty information\n3 : Go to the previous menu", 1, 3);
        //        switch (methodChoiceAnswer)
        //        {
        //            case 1:
        //                Console.WriteLine("Enter the userID");
        //                int userIDAnswer = Convert.ToInt32(Console.ReadLine());
        //                if (ContainUserID(userIDAnswer))
        //                {
        //                    if (UserList[IndexUserID(userIDAnswer)] is Faculty)
        //                    {
        //                        iDchoosen = userIDAnswer;

        //                        stayInTheFunction = false;
        //                    }
        //                    else
        //                    {
        //                        Console.WriteLine("The userID is not corresponding to a faculty");
        //                    }
        //                }
        //                else
        //                {
        //                    Console.WriteLine("There is not this user ID in the database");
        //                }
        //                break;
        //            case 2:
        //                Console.WriteLine("All faculty information :");
        //                Console.WriteLine(FacultiesInformation());
        //                Console.WriteLine("Enter the UserID of the faculty you want to choose");
        //                int userIDChoosen = Convert.ToInt32(Console.ReadLine());
        //                if (ContainUserID(userIDChoosen))
        //                {
        //                    if (UserList[IndexUserID(userIDChoosen)] is Faculty)
        //                    {
        //                        iDchoosen = userIDChoosen;
        //                        stayInTheFunction = false;
        //                    }
        //                    else
        //                    {
        //                        Console.WriteLine("The userID is not corresponding to an faculty");
        //                    }
        //                }
        //                else
        //                {
        //                    Console.WriteLine("There is not this user ID in the database");
        //                }
        //                break;
        //            case 3:
        //                iDchoosen = -1;
        //                stayInTheFunction = false;
        //                break;
        //        }
        //    }
        //    return iDchoosen;
        //}
        //public int ChoosingDisciplineID()
        //{
        //    int iDchoosen = -1;
        //    bool stayInTheFunction = true;
        //    while (stayInTheFunction)
        //    {
        //        int methodChoiceAnswer = EnterValue.AskingNumber("Enter what you want to do\n1 : Choose by enter a discipline ID\n2 : Choose a discipline ID and the see disciplines information\n3 : Go to the previous menu", 1, 3);
        //        switch (methodChoiceAnswer)
        //        {
        //            case 1:
        //                Console.WriteLine("Enter the disciplineID");
        //                int disciplineIDanswer = Convert.ToInt32(Console.ReadLine());
        //                if (ContainDisciplineID(disciplineIDanswer))
        //                {
        //                    iDchoosen = disciplineIDanswer;
        //                    stayInTheFunction = false;
        //                }
        //                else
        //                {
        //                    Console.WriteLine("There is not this discipline ID in the database");
        //                }
        //                break;
        //            case 2:
        //                Console.WriteLine("All discipline information :");
        //                Console.WriteLine(DisciplinesInformation());
        //                Console.WriteLine("Enter the disciplineID of the discipline you want to choose");
        //                int disciplineIDChoosen = Convert.ToInt32(Console.ReadLine());
        //                if (ContainDisciplineID(disciplineIDChoosen))
        //                {
        //                    iDchoosen = disciplineIDChoosen;
        //                    stayInTheFunction = false;
        //                }
        //                else
        //                {
        //                    Console.WriteLine("There is not this discipline ID in the database");
        //                }
        //                break;
        //            case 3:
        //                iDchoosen = -1;
        //                stayInTheFunction = false;
        //                break;
        //        }
        //    }
        //    return iDchoosen;
        //}

        //public int ChoosingClassroomID()
        //{
        //    int iDchoosen = -1;
        //    bool stayInTheFunction = true;
        //    while (stayInTheFunction)
        //    {
        //        int methodChoiceAnswer = EnterValue.AskingNumber("Enter what you want to do\n1 : Choose by enter a classroom ID\n2 : Choose a classroom ID and the see disciplines information\n3 : Go to the previous menu", 1, 3);
        //        switch (methodChoiceAnswer)
        //        {
        //            case 1:
        //                Console.WriteLine("Enter the classroomID");
        //                int classroomIDanswer = Convert.ToInt32(Console.ReadLine());
        //                if (ContainClassroomID(classroomIDanswer))
        //                {
        //                    iDchoosen = classroomIDanswer;
        //                    stayInTheFunction = false;
        //                }
        //                else
        //                {
        //                    Console.WriteLine("There is not this classroom ID in the database");
        //                }
        //                break;
        //            case 2:
        //                Console.WriteLine("All classroom information :");
        //                Console.WriteLine(ClassroomsEssentialInformation());
        //                Console.WriteLine("Enter the classroomID of the classroom you want to choose");
        //                int classroomIDChoosen = Convert.ToInt32(Console.ReadLine());
        //                if (ContainClassroomID(classroomIDChoosen))
        //                    if (ContainClassroomID(classroomIDChoosen))
        //                    {
        //                        iDchoosen = classroomIDChoosen;
        //                        stayInTheFunction = false;
        //                    }
        //                    else
        //                    {
        //                        Console.WriteLine("There is not this classroom ID in the database");
        //                    }
        //                break;
        //            case 3:
        //                iDchoosen = -1;
        //                stayInTheFunction = false;
        //                break;
        //        }
        //    }
        //    return iDchoosen;
        //}

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
        public int PutANewClassroomID()
        {
            LastClassroomID++;
            return LastClassroomID;
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

        public void AddClassroom(string classroomName, List<Faculty> facultiesTeaching, List<Student> studentsStudying, Discipline discipline)
        {
            Classrooms.Add(new Classroom(classroomName, facultiesTeaching, studentsStudying, discipline));
            Classrooms[Classrooms.Count - 1].ClassRoomID = PutANewClassroomID();
        }
        public void AddClassroom(string classroomName, Discipline discipline)
        {
            Classrooms.Add(new Classroom(classroomName, discipline));
            Classrooms[Classrooms.Count - 1].ClassRoomID = PutANewClassroomID();
        }


        public void AddDiscipline(Discipline newDiscipline)
        {
            newDiscipline.DisciplineID = PutANewDisciplineID();
            DisciplineList.Add(newDiscipline);
        }


        //public bool ContainUserID(int userID)
        //{
        //    return UserList.Any(i => i.UserID == userID);
        //}

        //public int IndexUserID(int userID)
        //{
        //    return UserList.FindIndex(i => i.UserID == userID);
        //}

        //public bool ContainDisciplineID(int disciplineID)
        //{
        //    return DisciplineList.Any(i => i.DisciplineID == disciplineID);
        //}

        //public int IndexDisciplineID(int disciplineID)
        //{
        //    return DisciplineList.FindIndex(i => i.DisciplineID == disciplineID);
        //}

        //public bool ContainClassroomID(int classroomID)
        //{
        //    return Classrooms.Any(i => i.ClassRoomID == classroomID);
        //}

        //public int IndexClassroomID(int classroomID)
        //{
        //    return Classrooms.FindIndex(i => i.ClassRoomID == classroomID);
        //}

        //public string UsersPublicInformation()
        //{
        //    string information = "";
        //    for (int index = 0; index < UserList.Count; index++)
        //    {
        //        information += $"{UserList[index].PublicApplicationInformation()}\n";
        //    }
        //    return information;
        //}

        //public string StudentsInformation()
        //{
        //    string information = "";
        //    int numberStudent = 0;
        //    if (UserList != null || UserList.Count != 0)
        //    {
        //        for (int index = 0; index < UserList.Count; index++)
        //        {
        //            if (UserList[index] is Student)
        //            {
        //                information += $"[{numberStudent}] {UserList[index].PublicApplicationInformation()}\n";
        //                numberStudent++;
        //            }
        //        }
        //    }
        //    if (numberStudent == 0)
        //    {
        //        information += "There is no student user";
        //    }
        //    return information;
        //}

        //public string FacultiesInformation()
        //{
        //    string information = "";
        //    int numberFaculties = 0;
        //    if (UserList != null || UserList.Count != 0)
        //    {
        //        for (int index = 0; index < UserList.Count; index++)
        //        {
        //            if (UserList[index] is Faculty)
        //            {
        //                information += $"[{numberFaculties}] {UserList[index].PublicApplicationInformation()}\n";
        //                numberFaculties++;
        //            }
        //        }
        //    }
        //    if (numberFaculties == 0)
        //    {
        //        information += "There is no faculty user";
        //    }
        //    return information;
        //}

        //public string AdministratorsInformation()
        //{
        //    string information = "";
        //    int numberAdministrator = 0;
        //    if (UserList != null || UserList.Count != 0)
        //    {
        //        for (int index = 0; index < UserList.Count; index++)
        //        {
        //            if (UserList[index] is Administrator)
        //            {
        //                information += $"[{numberAdministrator}] {UserList[index].PublicApplicationInformation()}\n";
        //                numberAdministrator++;
        //            }
        //        }
        //    }
        //    if (numberAdministrator == 0)
        //    {
        //        information += "There is no administrator user";
        //    }
        //    return information;
        //}

        //public string DisciplinesInformation()
        //{
        //    string information = "";
        //    if (DisciplineList != null && DisciplineList.Count != 0)
        //    {
        //        for (int index = 0; index < DisciplineList.Count; index++)
        //        {
        //            information += $"[{index}] {DisciplineList[index].PublicInformation()}\n";
        //        }
        //    }
        //    else
        //    {
        //        information += "There is no discipline created";
        //    }
        //    return information;
        //}
        //public string ClassroomsEssentialInformation()
        //{
        //    string information = "";
        //    if (Classrooms != null && Classrooms.Count != 0)
        //    {
        //        for (int index = 0; index < Classrooms.Count; index++)
        //        {
        //            information += $"[{index}] {Classrooms[index].ClassroomEssentialInformation()}\n";
        //        }
        //    }
        //    else
        //    {
        //        information += "There is no classroom created";
        //    }
        //    return information;
        //}

    }
}