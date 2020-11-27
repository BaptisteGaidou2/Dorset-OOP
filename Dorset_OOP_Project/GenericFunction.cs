using System;
using System.Collections.Generic;
using System.Text;

namespace Dorset_OOP_Project
{
    public static class GenericFunction
    {
        public static string AttendanceListInformation(List<Attendance> list)
        {
            string information = "";
            if (list != null && list.Count != 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    information += $"\n[index : {i}] {list[i].Information()}";
                }
            }
            else
            {
                information += "There is no attendance ";
            }
            return information;
        }
        public static int ChoosingAttendanceNoteList(List<Attendance> list)
        {
            int index = -1;
            if (list != null && list.Count == 0)
            {
                bool stayInTheFunction = true;
                while (stayInTheFunction)
                {
                    int methodChoiceAnswer = EnterValue.AskingNumber("Enter what you want to do\n1 : Choose the attendance of the note you want to select\n2 : Go to the previous menu", 1, 2);
                    switch (methodChoiceAnswer)
                    {
                        case 1:
                            Console.WriteLine(AttendanceListInformation(list));
                            Console.WriteLine("Enter the index of the attendance you want to select");
                            try
                            {
                                index = Convert.ToInt32(Console.ReadLine());
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("The input was not an integer");
                            }
                            if (index < 0 || index >= list.Count)
                            {
                                Console.WriteLine("There isn't this index");
                                index = -1;
                            }
                            else
                            {
                                stayInTheFunction = false;
                            }
                            break;
                        case 2:
                            stayInTheFunction = false;
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("There is no notes");
            }
            return index;
        }
        public static string NoteListInformation(List<Note> list)
        {
            string information = "";
            if (list != null && list.Count != 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    information += $"\n[index : {i}] {list[i].Information()}";
                }
            }
            else
            {
                information += "There is no notes ";
            }
            return information;
        }
        public static int ChoosingIndexNoteList(List<Note> list)
        {
            int index = -1;
            if (list != null && list.Count == 0)
            {
                bool stayInTheFunction = true;
                while (stayInTheFunction)
                {
                    int methodChoiceAnswer = EnterValue.AskingNumber("Enter what you want to do\n1 : Choose the index of the note you want to select\n2 : Go to the previous menu", 1, 2);
                    switch (methodChoiceAnswer)
                    {
                        case 1:
                            Console.WriteLine(NoteListInformation(list));
                            Console.WriteLine("Enter the index of the note you want to select");
                            try
                            {
                                index = Convert.ToInt32(Console.ReadLine());
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("The input was not an integer");
                            }
                            if (index < 0 || index >= list.Count)
                            {
                                Console.WriteLine("There isn't this index");
                                index = -1;
                            }
                            else
                            {
                                stayInTheFunction = false;
                            }
                            break;
                        case 2:
                            stayInTheFunction = false;
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("There is no notes");
            }
            return index;
        }
        public static  string ExamListInformation(List<Exam> list)
        {
            string information = "";
            if (list != null && list.Count != 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    information += $"\n[index : {i}] {list[i].Information()}";
                }
            }
            else
            {
                information += "There is no exams ";
            }
            return information;
        }
        public static int ChoosingIndexExamList(List<Exam> list)
        {
            int index = -1;
            if (list != null && list.Count == 0)
            {
                bool stayInTheFunction = true;
                while (stayInTheFunction)
                {
                    int methodChoiceAnswer = EnterValue.AskingNumber("Enter what you want to do\n1 : Choose the index of exam you want to select\n2 : Go to the previous menu", 1, 2);
                    switch (methodChoiceAnswer)
                    {
                        case 1:
                            Console.WriteLine(ExamListInformation(list));
                            Console.WriteLine("Enter the index of the exam you want to select");
                            try
                            {
                                index = Convert.ToInt32(Console.ReadLine());
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("The input was not an integer");
                            }
                            if (index < 0 || index >= list.Count)
                            {
                                Console.WriteLine("There isn't this index");
                                index = -1;
                            }
                            else
                            {
                                stayInTheFunction = false;
                            }
                            break;
                        case 2:
                            stayInTheFunction = false;
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("There is no exams");
            }
            return index;
        }

        public static string AddSpace(string message,int length)
        {
            while (message.Length < length)
            {
                message += " ";
            }
            return message;
        }
        public static string FromIndexToDay(int index)
        {
            string day = "";
            switch (index)
            {
                case 1:
                    day = "MONDAY";
                    break;
                case 2:
                    day = "TUESDAY";
                    break;
                case 3:
                    day = "WEDNESDAY";
                    break;
                case 4:
                    day = "THURSDAY";
                    break;
                case 5:
                    day = "FRIDAY";
                    break;
                case 6:
                    day = "SATURDAY";
                    break;
            }
            return day;
        }
        public static string TimesSlotsInformation(List<TimeSlot> list)
        {
            string information = "";
            if (list != null && list.Count != 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    information += $"\n[index : {i}] {list[i].Information()}";
                }
            }
            else
            {
                information += "There is no time slots";
            }
            return information;
        }
        public static int ChoosingIndexTimeSlotList(List<TimeSlot> list)
        {
            int index = -1;
            if (list != null && list.Count == 0)
            {
                bool stayInTheFunction = true;
                while (stayInTheFunction)
                {
                    int methodChoiceAnswer = EnterValue.AskingNumber("Enter what you want to do\n1 : Choose the index of the time slot you want to select\n2 : Go to the previous menu", 1, 2);
                    switch (methodChoiceAnswer)
                    {
                        case 1:
                            Console.WriteLine(TimesSlotsInformation(list));
                            Console.WriteLine("Enter the index of the time slot you want to select");
                            try
                            {
                                index = Convert.ToInt32(Console.ReadLine());
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("The input was not an integer");
                            }
                            if (index < 0 || index >= list.Count)
                            {
                                Console.WriteLine("There isn't this index");
                                index = -1;
                            }
                            else
                            {
                                stayInTheFunction = false;
                            }
                            break;
                        case 2:
                            stayInTheFunction = false;
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("There is no time slot");
            }
            return index;
        }
        
        //Choosing a ID from a list
        #region
        public static int ChoosingAUserID(List<User> list)
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
                        if (ContainUserID(userIDAnswer, list))
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
                        Console.WriteLine(UsersPublicInformation(list));
                        Console.WriteLine("Enter the UserID of the user you want to choose");
                        int userIDChoosen = Convert.ToInt32(Console.ReadLine());
                        if (ContainUserID(userIDChoosen, list))
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
        public static int ChoosingStudentID(List<User> list)
        {

            int iDchoosen = -1;
            if (list != null && list.Count == 0)
            { 
                bool stayInTheFunction = true;
                while (stayInTheFunction)
                {
                    int methodChoiceAnswer = EnterValue.AskingNumber("Enter what you want to do\n1 : Choose by enter a user ID of a student\n2 : Choose a userID and the student information\n3 : Go to the previous menu", 1, 3);
                    switch (methodChoiceAnswer)
                    {
                        case 1:
                            Console.WriteLine("Enter the userID");
                            int userIDAnswer = Convert.ToInt32(Console.ReadLine());
                            if (ContainUserID(userIDAnswer, list))
                            {
                                if (list[IndexUserID(userIDAnswer, list)] is Student)
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
                            Console.WriteLine(StudentsInformation(list));
                            Console.WriteLine("Enter the UserID of the student you want to choose");
                            int userIDChoosen = Convert.ToInt32(Console.ReadLine());
                            if (ContainUserID(userIDChoosen, list))
                            {
                                if (list[IndexUserID(userIDChoosen, list)] is Student)
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
            }
            else
            {
                Console.WriteLine("There is no user");
            }
            return iDchoosen;
        }
        public static int ChoosingStudentID_FromListStudent(List<Student> list)
        {
            int iDchoosen = -1;
            if (list != null && list.Count == 0)
            {
                bool stayInTheFunction = true;
                while (stayInTheFunction)
                {
                    int methodChoiceAnswer = EnterValue.AskingNumber("Enter what you want to do\n1 : Choose by enter a user ID of a student\n2 : Choose a userID and the student information\n3 : Go to the previous menu", 1, 3);
                    switch (methodChoiceAnswer)
                    {
                        case 1:
                            Console.WriteLine("Enter the userID");
                            int userIDAnswer = -1;
                            try
                            {
                                userIDAnswer = Convert.ToInt32(Console.ReadLine());
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("The input was not an integer");
                            }
                            if (ContainUserID_FromStudentList(userIDAnswer, list))
                            {
                                if (list[IndexUserID_StudentList(userIDAnswer, list)] is Student)
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
                            Console.WriteLine(StudentsInformation_FromAStudentList(list));
                            Console.WriteLine("Enter the UserID of the student you want to choose");
                            int userIDChoosen = Convert.ToInt32(Console.ReadLine());
                            if (ContainUserID_FromStudentList(userIDChoosen, list))
                            {
                                if (list[IndexUserID_StudentList(userIDChoosen, list)] is Student)
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
            }
            else
            {
                Console.WriteLine("There is no student");
            }
            return iDchoosen;
        }
        public static int ChoosingAAdministratorID(List<User> list)
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
                        if (ContainUserID(userIDAnswer, list))
                        {
                            if (list[IndexUserID(userIDAnswer, list)] is Administrator)
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
                        if (ContainUserID(userIDChoosen, list))
                        {
                            if (list[IndexUserID(userIDChoosen, list)] is Administrator)
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
        public static int ChoosingAFacultyID(List<User> list)
        {
            int iDchoosen = -1;
            if (list != null && list.Count == 0)
            {
                bool stayInTheFunction = true;
                while (stayInTheFunction)
                {
                    int methodChoiceAnswer = EnterValue.AskingNumber("Enter what you want to do\n1 : Choose by enter a user ID of a faculty\n2 : Choose a userID and the faculty information\n3 : Go to the previous menu", 1, 3);
                    switch (methodChoiceAnswer)
                    {
                        case 1:
                            Console.WriteLine("Enter the userID");
                            int userIDAnswer = Convert.ToInt32(Console.ReadLine());
                            if (ContainUserID(userIDAnswer, list))
                            {
                                if (list[IndexUserID(userIDAnswer, list)] is Faculty)
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
                            Console.WriteLine(FacultiesInformation(list));
                            Console.WriteLine("Enter the UserID of the faculty you want to choose");
                            int userIDChoosen = Convert.ToInt32(Console.ReadLine());
                            if (ContainUserID(userIDChoosen, list))
                            {
                                if (list[IndexUserID(userIDChoosen, list)] is Faculty)
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
            }
            else
            {
                Console.WriteLine("There is no user");
            }
            return iDchoosen;
        }
        public static int ChoosingAFacultyID_FromFacultyList(List<Faculty> list)
        {
            int iDchoosen = -1;
            if (list != null && list.Count == 0)
            {
                bool stayInTheFunction = true;
                while (stayInTheFunction)
                {
                    int methodChoiceAnswer = EnterValue.AskingNumber("Enter what you want to do\n1 : Choose by enter a user ID of a faculty\n2 : Choose a userID and the faculty information\n3 : Go to the previous menu", 1, 3);
                    switch (methodChoiceAnswer)
                    {
                        case 1:
                            Console.WriteLine("Enter the userID");
                            int userIDAnswer = Convert.ToInt32(Console.ReadLine());
                            if (ContainUserID_FromFacultyList(userIDAnswer, list))
                            {
                                if (list[IndexUserID_FacultyList(userIDAnswer, list)] is Faculty)
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
                            Console.WriteLine(FacultiesInformation_FromAFacultyList(list));
                            Console.WriteLine("Enter the UserID of the faculty you want to choose");
                            int userIDChoosen = Convert.ToInt32(Console.ReadLine());
                            if (ContainUserID_FromFacultyList(userIDChoosen, list))
                            {
                                if (list[IndexUserID_FacultyList(userIDChoosen, list)] is Faculty)
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

            }
            else
            {
                Console.WriteLine("There is no faculty");
            }
            return iDchoosen;
        }
        public static int ChoosingDisciplineID(List<Discipline> list)
        {
            int iDchoosen = -1;
            if (list != null && list.Count == 0)
            {
                bool stayInTheFunction = true;
                while (stayInTheFunction)
                {
                    int methodChoiceAnswer = EnterValue.AskingNumber("Enter what you want to do\n1 : Choose by enter a discipline ID\n2 : Choose a discipline ID and the see disciplines information\n3 : Go to the previous menu", 1, 3);
                    switch (methodChoiceAnswer)
                    {
                        case 1:
                            Console.WriteLine("Enter the disciplineID");
                            int disciplineIDanswer = Convert.ToInt32(Console.ReadLine());
                            if (ContainDisciplineID(disciplineIDanswer, list))
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
                            Console.WriteLine(DisciplinesInformation(list));
                            Console.WriteLine("Enter the disciplineID of the discipline you want to choose");
                            int disciplineIDChoosen = Convert.ToInt32(Console.ReadLine());
                            if (ContainDisciplineID(disciplineIDChoosen, list))
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
            }
            else
            {
                Console.WriteLine("There is no faculty");
            }
            return iDchoosen;
        }
        public static int ChoosingClassroomID(List<Classroom> list)
        {
            int iDchoosen = -1;
            if (list != null && list.Count == 0)
            {
                bool stayInTheFunction = true;
                while (stayInTheFunction)
                {
                    int methodChoiceAnswer = EnterValue.AskingNumber("Enter what you want to do\n1 : Choose by enter a classroom ID\n2 : Choose a classroom ID and the see disciplines information\n3 : Go to the previous menu", 1, 3);
                    switch (methodChoiceAnswer)
                    {
                        case 1:
                            Console.WriteLine("Enter the classroomID");
                            int classroomIDanswer = Convert.ToInt32(Console.ReadLine());
                            if (ContainClassroomID(classroomIDanswer, list))
                            {
                                iDchoosen = classroomIDanswer;
                                stayInTheFunction = false;
                            }
                            else
                            {
                                Console.WriteLine("There is not this classroom ID in the database");
                            }
                            break;
                        case 2:
                            Console.WriteLine("All classroom information :");
                            Console.WriteLine(ClassroomsEssentialInformation(list));
                            Console.WriteLine("Enter the classroomID of the classroom you want to choose");
                            int classroomIDChoosen = Convert.ToInt32(Console.ReadLine());
                            if (ContainClassroomID(classroomIDChoosen, list))
                                if (ContainClassroomID(classroomIDChoosen, list))
                                {
                                    iDchoosen = classroomIDChoosen;
                                    stayInTheFunction = false;
                                }
                                else
                                {
                                    Console.WriteLine("There is not this classroom ID in the database");
                                }
                            break;
                        case 3:
                            iDchoosen = -1;
                            stayInTheFunction = false;
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("There is no faculty");
            }
            return iDchoosen;
        }
        #endregion
        //Information methods
        #region
        public static string ClassroomsEssentialInformation(List<Classroom> clasrooms)
        {
            string information = "";
            if (clasrooms != null && clasrooms.Count != 0)
            {
                for (int index = 0; index < clasrooms.Count; index++)
                {
                    information += $"[{index}] {clasrooms[index].ClassroomEssentialInformation()}\n";
                }
            }
            else
            {
                information += "There is no classroom for this";
            }
            return information;
        }
        public static string DisciplinesInformation(List<Discipline> disciplinesList)
        {
            string information = "";
            if (disciplinesList != null && disciplinesList.Count != 0)
            {
                for (int index = 0; index < disciplinesList.Count; index++)
                {
                    information += $"[{index}] {disciplinesList[index].PublicInformation()}\n";
                }
            }
            else
            {
                information += "There is no discipline for this";
            }
            return information;
        }
        public static string AdministratorsInformation(List<User> list)
        {
            string information = "";
            int numberAdministrator = 0;
            if (list != null || list.Count != 0)
            {
                for (int index = 0; index < list.Count; index++)
                {
                    if (list[index] is Administrator)
                    {
                        information += $"[{numberAdministrator}] {list[index].PublicApplicationInformation()}\n";
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
        public static string FacultiesInformation(List<User> list)
        {
            string information = "";
            int numberFaculties = 0;
            if (list != null || list.Count != 0)
            {
                for (int index = 0; index < list.Count; index++)
                {
                    if (list[index] is Faculty)
                    {
                        information += $"[{numberFaculties}] {list[index].PublicApplicationInformation()}\n";
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
        public static string FacultiesInformation_FromAFacultyList(List<Faculty> list)
        {
            string information = "";
            int numberFaculties = 0;
            if (list != null || list.Count != 0)
            {
                for (int index = 0; index < list.Count; index++)
                {
                    if (list[index] is Faculty)
                    {
                        information += $"[{numberFaculties}] {list[index].PublicApplicationInformation()}\n";
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
        public static string StudentsInformation(List<User> list)
        {
            string information = "";
            int numberStudent = 0;
            if (list != null || list.Count != 0)
            {
                for (int index = 0; index < list.Count; index++)
                {
                    if (list[index] is Student)
                    {
                        information += $"[{numberStudent}] {list[index].PublicApplicationInformation()}\n";
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
        public static string StudentsInformation_FromAStudentList(List<Student> list)
        {
            string information = "";
            int numberStudent = 0;
            if (list != null || list.Count != 0)
            {
                for (int index = 0; index < list.Count; index++)
                {
                    if (list[index] is Student)
                    {
                        information += $"[{numberStudent}] {list[index].PublicApplicationInformation()}\n";
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
        public static string UsersPublicInformation(List<User> list)
        {
            string information = "";
            for (int index = 0; index < list.Count; index++)
            {
                information += $"{list[index].PublicApplicationInformation()}\n";
            }
            return information;
        }
        
        
        #endregion
        //Find the index with an ID
        #region
        public static int IndexClassroomID(int classroomID,List<Classroom> classrooms)
        {
            return classrooms.FindIndex(i => i.ClassRoomID == classroomID);
        }
        public static int IndexUserID(int userID,List<User> list)
        {
            return list.FindIndex(i => i.UserID == userID);
        }
        public static int IndexUserID_StudentList(int userID, List<Student> list)
        {
            return list.FindIndex(i => i.UserID == userID);
        }
        public static int IndexUserID_FacultyList(int userID, List<Faculty> list)
        {
            return list.FindIndex(i => i.UserID == userID);
        }
        public static int IndexDisciplineID(int disciplineID, List<Discipline> list)
        {
            return list.FindIndex(i => i.DisciplineID == disciplineID);
        }
        #endregion
        //Contain an ID
        #region
        public static bool ContainUserID(int userID,List<User> list)
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

        public static bool ContainUserID_FromStudentList(int userID, List<Student> list)
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
        public static bool ContainUserID_FromFacultyList(int userID, List<Faculty> list)
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

        public static bool ContainDisciplineID(int disciplineID,List<Discipline> list)
        {
            bool contain = false;
            int index = 0;
            while (list != null && index < list.Count && contain == false)
            {
                if (list[index].DisciplineID == disciplineID)
                {
                    contain = true;
                }
                index++;
            }
            return contain;
        }

        public static bool ContainClassroomID(int classroomID,List<Classroom> list)
        {
            bool contain = false;
            int index = 0;
            while (list != null && index < list.Count && contain == false)
            {
                if (list[index].ClassRoomID == classroomID)
                {
                    contain = true;
                }
                index++;
            }
            return contain;
        }

        #endregion
    }
}
