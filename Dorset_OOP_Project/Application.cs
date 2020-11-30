using System;
using System.Collections.Generic;
using System.IO;
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
        public int LastExamID { get; set; }
        public int CurrentIndexUser { get; set; }
        public Application(string path_UserDB, string path_DisciplineDB, string path_ExamDB, string path_ClassroomDB, string path_FacultyClassroom, string path_StudentClassroom, string path_StudentAttendences, string path_StudentNotes, string path_LastID)
        {
            UserList = new List<User>();
            DisciplineList = new List<Discipline>();
            Classrooms = new List<Classroom>();
            Exams = new List<Exam>();

            int indexAttribute = 1;
            string[] lines_UserDB = System.IO.File.ReadAllLines(path_UserDB);
            #region
            for (int indexLigne = 0; indexLigne < lines_UserDB.Length; indexLigne++)
            {

                string[] columns = lines_UserDB[indexLigne].Split(';');
                switch (indexAttribute)
                {
                    case 1:
                        switch (columns[1])
                        {
                            case "Administrator":
                                UserList.Add(new Administrator());
                                break;
                            case "Student":
                                UserList.Add(new Student());
                                break;
                            case "Faculty":
                                UserList.Add(new Faculty());
                                break;
                        }
                        break;
                    case 2:
                        UserList[UserList.Count - 1].UserID = Convert.ToInt32(columns[1]);
                        break;
                    case 3:
                        UserList[UserList.Count - 1].FirstName = columns[1];
                        break;
                    case 4:
                        UserList[UserList.Count - 1].LastName = columns[1];
                        break;
                    case 5:
                        UserList[UserList.Count - 1].Email = columns[1];
                        break;
                    case 6:
                        UserList[UserList.Count - 1].Password = columns[1];
                        break;
                }
                indexAttribute++;
                if (indexAttribute == 7)
                {
                    indexAttribute = 1;
                }
            }
            #endregion
            string[] lines_DisciplineDB = System.IO.File.ReadAllLines(path_DisciplineDB);
            #region
            indexAttribute = 1;
            for (int indexLigne = 0; indexLigne < lines_DisciplineDB.Length; indexLigne++)
            {
                string[] columns = lines_DisciplineDB[indexLigne].Split(';');
                switch (indexAttribute)
                {
                    case 1:
                        DisciplineList.Add(new Discipline());
                        DisciplineList[DisciplineList.Count - 1].DisciplineID = Convert.ToInt32(columns[1]);
                        break;
                    case 2:
                        DisciplineList[DisciplineList.Count - 1].DisciplineName = columns[1];
                        break;
                }
                indexAttribute++;
                if (indexAttribute == 3)
                {
                    indexAttribute = 1;
                }
            }
            #endregion
            string[] lines_ExamDB = System.IO.File.ReadAllLines(path_ExamDB);
            #region
            indexAttribute = 1;
            for (int indexLigne = 0; indexLigne < lines_ExamDB.Length; indexLigne++)
            {
                string[] columns = lines_ExamDB[indexLigne].Split(';');
                switch (indexAttribute)
                {
                    case 1:
                        Exams.Add(new Exam());
                        Exams[Exams.Count - 1].ExamID = Convert.ToInt32(columns[1]);
                        break;
                    case 2:
                        Exams[Exams.Count - 1].ExamName = columns[1];
                        break;
                    case 3:
                        Exams[Exams.Count - 1].Week = Convert.ToInt32(columns[1]);
                        break;
                    case 4:
                        Exams[Exams.Count - 1].Day = Convert.ToInt32(columns[1]);
                        break;
                    case 5:
                        Exams[Exams.Count - 1].StartingHour = Convert.ToInt32(columns[1]);
                        break;
                    case 6:
                        Exams[Exams.Count - 1].EndingHour = Convert.ToInt32(columns[1]);
                        break;
                }
                indexAttribute++;
                if (indexAttribute == 7)
                {
                    indexAttribute = 1;
                }
            }
            #endregion
            string[] lines_ClassroomDB = System.IO.File.ReadAllLines(path_ClassroomDB);
            #region
            indexAttribute = 1;
            for (int indexLigne = 0; indexLigne < lines_ClassroomDB.Length; indexLigne++)
            {
                string[] columns = lines_ClassroomDB[indexLigne].Split(';');
                switch (indexAttribute)
                {
                    case 1:
                        Classrooms.Add(new Classroom());
                        Classrooms[Classrooms.Count - 1].ClassRoomID = Convert.ToInt32(columns[1]);
                        break;
                    case 2:
                        Classrooms[Classrooms.Count - 1].ClassroomName = columns[1];
                        break;
                    case 3:
                        if (columns.Length > 1)
                        {      
                            Classrooms[Classrooms.Count - 1].ClassRoomDiscipline= DisciplineList[GenericFunction.IndexDisciplineID(Convert.ToInt32(columns[1]), DisciplineList)];
                        }
                        break;
                    case 4:
                        if (columns.Length > 1)
                        {
                            for (int indexColumn = 1; indexColumn < columns.Length; indexColumn++)
                            {
                                int ID = Convert.ToInt32(columns[indexColumn]);
                                int index = GenericFunction.IndexUserID(ID, UserList);
                                if (index != -1 && UserList[index] is Faculty)
                                {
                                    Faculty faculty = (Faculty)UserList[index];
                                    Classrooms[Classrooms.Count - 1].ClassRoomFaculties.Add(faculty);
                                    faculty.ClassroomsTeaching.Add(Classrooms[Classrooms.Count - 1]);
                                }
                            }
                        }
                        break;
                    case 5:
                        if (columns.Length > 1)
                        {
                            for(int indexColumn = 1; indexColumn < columns.Length; indexColumn++)
                            {
                                int ID = Convert.ToInt32(columns[indexColumn]);
                                int index = GenericFunction.IndexUserID(ID, UserList);
                                if (index != -1 &&UserList[index]is Student)
                                {
                                    Student student = (Student)UserList[index];
                                    Classrooms[Classrooms.Count - 1].ClassRoomStudents.Add(student);
                                    student.ClassroomStudying.Add(Classrooms[Classrooms.Count - 1]);
                                }
                            }
                        }
                        break;
                    case 6:
                        if (columns.Length > 1)
                        {
                            int indexTimeSlot = 1;
                            int indexLastTimeTable = 0;
                            int indexLastClassroom = 0;
                            for (int indexColumn = 1; indexColumn < columns.Length; indexColumn++)
                            {
                                switch (indexTimeSlot)
                                {
                                    case 1:
                                        Classrooms[Classrooms.Count - 1].Timetables.Add(new TimeSlot());
                                        indexLastClassroom = Classrooms.Count - 1;
                                        indexLastTimeTable = Classrooms[indexLastClassroom].Timetables.Count - 1;
                                        Classrooms[indexLastClassroom].Timetables[indexLastTimeTable].Week =Convert.ToInt32(columns[indexColumn]);
                                        break;
                                    case 2:
                                        Classrooms[indexLastClassroom].Timetables[indexLastTimeTable].Day = Convert.ToInt32(columns[indexColumn]); 
                                        break;
                                    case 3:
                                        Classrooms[indexLastClassroom].Timetables[indexLastTimeTable].StartingTime = Convert.ToInt32(columns[indexColumn]);
                                        break;
                                    case 4:
                                        if (Convert.ToInt32(columns[indexColumn]) != -1)
                                        {
                                            int ID = Convert.ToInt32(columns[indexColumn]);
                                            int index = GenericFunction.IndexUserID(ID, UserList);
                                            if (index != -1 && UserList[index] is Faculty)
                                            {
                                                Classrooms[indexLastClassroom].Timetables[indexLastTimeTable].Teacher = (Faculty) UserList[index];
                                            }
                                        }
                                        break;
                                }
                                indexTimeSlot++;
                                if (indexTimeSlot == 5)
                                {
                                    indexTimeSlot = 1;
                                }
                            }
                        }
                        break;
                }
                indexAttribute++;
                if (indexAttribute == 7)
                {
                    indexAttribute = 1;
                }
            }
            #endregion
            //string[] lines_FacultyClassroom = System.IO.File.ReadAllLines(path_FacultyClassroom);
            #region
            //indexAttribute = 1;
            //int facultyID = 0;
            //for (int indexLigne = 0; indexLigne < lines_FacultyClassroom.Length; indexLigne++)
            //{
            //    string[] columns = lines_FacultyClassroom[indexLigne].Split(';');
            //    switch (indexAttribute)
            //    {
            //        case 1:
            //            facultyID = Convert.ToInt32(columns[1]);
            //            break;
            //        case 2:
            //            int indexF = GenericFunction.IndexUserID(facultyID, UserList);
            //            if (indexF != -1)
            //            {
            //                if(UserList[indexF]is Faculty)
            //                {
            //                    int indexClassroom = GenericFunction.IndexClassroomID(Convert.ToInt32(columns[1]), Classrooms);
            //                    if (indexClassroom != -1)
            //                    {
            //                        Faculty faculty = (Faculty)UserList[indexF];
            //                        faculty.ClassroomsTeaching.Add(Classrooms[indexClassroom]);
            //                    }
            //                }
            //            }
            //            break;
            //    }
            //    indexAttribute++;
            //    if (indexAttribute == 3)
            //    {
            //        indexAttribute = 1;
            //    }
            //}
            #endregion
            //string[] lines_StudentClassroom = System.IO.File.ReadAllLines(path_StudentClassroom);
            #region
            //indexAttribute = 1;
            //int studentID = 0;
            //for (int indexLigne = 0; indexLigne < lines_StudentClassroom.Length; indexLigne++)
            //{
            //    string[] columns = lines_StudentClassroom[indexLigne].Split(';');
            //    switch (indexAttribute)
            //    {
            //        case 1:
            //            studentID = Convert.ToInt32(columns[1]);
            //            break;
            //        case 2:
            //            int indexS = GenericFunction.IndexUserID(studentID, UserList);
            //            if (indexS != -1)
            //            {
            //                if (UserList[indexS] is Student)
            //                {
            //                    int indexClassroom = GenericFunction.IndexClassroomID(Convert.ToInt32(columns[1]), Classrooms);
            //                    if (indexClassroom != -1)
            //                    {
            //                        Student student = (Student)UserList[indexS];
            //                        student.ClassroomStudying.Add(Classrooms[indexClassroom]);
            //                    }
            //                }
            //            }
            //            break;
            //    }
            //    indexAttribute++;
            //    if (indexAttribute == 3)
            //    {
            //        indexAttribute = 1;
            //    }
            //}
            #endregion
            //NEED TO MAKE THE FOLLOW
            string[] line_StudentAttendences = System.IO.File.ReadAllLines(path_StudentAttendences);
            #region
            indexAttribute = 1;
            //if (user is Student)
            //{
            //    Student student = (Student)user;
            //    if (student.Attendances != null && student.Attendances.Count != 0)
            //    {
            //        studentAttendencesDB.WriteLine($"ID;{student.UserID}");
            //        foreach (Attendance attendance in student.Attendances)
            //        {
            //            studentAttendencesDB.WriteLine($"Classroom;{attendance.AbsentClass.ClassRoomID}");
            //            studentAttendencesDB.WriteLine($"TimeSlot;{attendance.AbsentTimeSlot.Week};{attendance.AbsentTimeSlot.Day};{attendance.AbsentTimeSlot.StartingTime}");
            //            string information = "Faculty_ID";
            //            if (attendance.AbsentTimeSlot.Teacher != null)
            //            {
            //                information += $";{attendance.AbsentTimeSlot.Teacher.UserID}";
            //            }
            //            studentAttendencesDB.WriteLine(information);
            //        }
            //    }
            //}
            int indexStudent_Attendance = 0;
            int classroomIndex_Attendance = 0;
            List<int> timeslotValue = new List<int>();
            int indexFaculty_Attendance = -1;
            indexAttribute = 1;
            for (int indexLigne = 0; indexLigne < line_StudentAttendences.Length; indexLigne++)
            {
                string[] columns = line_StudentAttendences[indexLigne].Split(';');
                switch (indexAttribute)
                {
                    case 1:
                        int studentID = Convert.ToInt32(columns[1]);
                        indexStudent_Attendance = GenericFunction.IndexUserID(studentID, UserList);
                        break;
                    case 2:
                        int classroomID = Convert.ToInt32(columns[1]);
                        classroomIndex_Attendance = GenericFunction.IndexClassroomID(classroomID, Classrooms);
                        break;
                    case 3:
                        timeslotValue = new List<int>();
                        if (columns.Length == 4)
                        {
                            for (int indexColumn = 1; indexColumn < columns.Length; indexColumn++)
                            {
                                timeslotValue.Add(Convert.ToInt32(columns[indexColumn]));
                            }
                        }
                        break;
                    case 4:
                        if (columns.Length > 1)
                        {
                            int facultyID = Convert.ToInt32(columns[1]);
                            indexFaculty_Attendance = GenericFunction.IndexUserID(facultyID, UserList);
                        }
                        else
                        {
                            indexFaculty_Attendance = -1;
                        }
                        break;
                }
                indexAttribute++;
                if (indexAttribute == 5)
                {
                    if (indexStudent_Attendance != 1 && classroomIndex_Attendance != -1 && timeslotValue.Count == 3)
                    {
                        if(UserList[indexStudent_Attendance] is Student)
                        {
                            Student student = (Student)UserList[indexStudent_Attendance];
                            student.Attendances.Add(new Attendance());
                            int indexLastAttendance = student.Attendances.Count - 1;
                            student.Attendances[indexLastAttendance].AbsentClass = Classrooms[classroomIndex_Attendance];
                            student.Attendances[indexLastAttendance].AbsentTimeSlot = new TimeSlot(timeslotValue[0], timeslotValue[1], timeslotValue[2]);
                            if (indexFaculty_Attendance != -1&& UserList[indexFaculty_Attendance] is Faculty)
                            {
                                student.Attendances[indexLastAttendance].AbsentTimeSlot.Teacher = (Faculty)UserList[indexFaculty_Attendance];

                            }
                        }
                    }
                    indexAttribute = 1;
                }
            }
            #endregion
            string[] lines_StudentNotes = System.IO.File.ReadAllLines(path_StudentNotes);
            #region
            indexAttribute = 1;
            for (int indexLigne = 0; indexLigne < lines_StudentNotes.Length; indexLigne++)
            {
                string[] columns = lines_StudentNotes[indexLigne].Split(';');
                switch (indexAttribute)
                {
                    case 1:
                        break;
                    case 2:
                        break;
                }
                indexAttribute++;
                if (indexAttribute == 3)
                {
                    indexAttribute = 1;
                }
            }
            #endregion
            string[] lines_LastID = System.IO.File.ReadAllLines(path_LastID);
            #region
            indexAttribute = 1;
            for (int indexLigne = 0; indexLigne < lines_LastID.Length; indexLigne++)
            {
                string[] columns = lines_LastID[indexLigne].Split(';');
                switch (indexAttribute)
                {
                    case 1:
                        break;
                    case 2:
                        break;
                }
                indexAttribute++;
                if (indexAttribute == 3)
                {
                    indexAttribute = 1;
                }
            }
            #endregion

        }
        public void FromAppToCSV(string path_UserDB, string path_DisciplineDB, string path_ExamDB, string path_ClassroomDB, string path_FacultyClassroom, string path_StudentClassroom, string path_StudentAttendences, string path_StudentNotes,string path_LastID)
        {
            StreamWriter userDB = new StreamWriter(path_UserDB);
            #region
            foreach (User user in UserList)
            {
                if (user is Student)
                {
                    userDB.WriteLine($"Type;Student");
                }
                if (user is Administrator)
                {
                    userDB.WriteLine($"Type;Administrator");
                }
                if (user is Faculty)
                {
                    userDB.WriteLine($"Type;Faculty");
                }
                userDB.WriteLine($"ID;{user.UserID}");
                userDB.WriteLine($"FirstName;{user.FirstName}");
                userDB.WriteLine($"LastName;{user.LastName}");
                userDB.WriteLine($"Email;{user.Email}");
                userDB.WriteLine($"Password;{user.Password}");
            }
            userDB.Close();
            #endregion
            StreamWriter disciplineDB = new StreamWriter(path_DisciplineDB);
            #region
            foreach (Discipline discipline in DisciplineList)
            {
                disciplineDB.WriteLine($"ID;{discipline.DisciplineID}");
                disciplineDB.WriteLine($"Name;{discipline.DisciplineName}");
            }
            disciplineDB.Close();
            #endregion
            StreamWriter examDB = new StreamWriter(path_ExamDB);
            #region
            foreach (Exam exam in Exams)
            {
                examDB.WriteLine($"ID;{exam.ExamID}");
                examDB.WriteLine($"Name;{exam.ExamName}");
                examDB.WriteLine($"Discipline_ID;{exam.ExamDiscipline.DisciplineID}");
                examDB.WriteLine($"Week;{exam.Week}");
                examDB.WriteLine($"Day;{exam.Day}");
                examDB.WriteLine($"StartingHour;{exam.StartingHour}");
                examDB.WriteLine($"EndingHour;{exam.EndingHour}");
            }
            examDB.Close();
            #endregion
            StreamWriter classroomDB = new StreamWriter(path_ClassroomDB);
            #region
            foreach (Classroom classroom in Classrooms)
            {
                classroomDB.WriteLine($"ID;{classroom.ClassRoomID}");
                classroomDB.WriteLine($"Name;{classroom.ClassroomName}");
                if (classroom.ClassRoomDiscipline != null)
                {
                    classroomDB.WriteLine($"Discipline_ID;{classroom.ClassRoomDiscipline.DisciplineID}");
                }
                else
                {
                    classroomDB.WriteLine($"Discipline_ID");
                }
                string info = "Faculty_ID";
                if (classroom.ClassRoomFaculties != null && classroom.ClassRoomFaculties.Count != 0)
                {
                    foreach (Faculty faculty in classroom.ClassRoomFaculties)
                    {
                        info += $";{faculty.UserID}";
                    }
                }
                classroomDB.WriteLine(info);
                info = "Student_ID";
                if (classroom.ClassRoomStudents != null && classroom.ClassRoomStudents.Count != 0)
                {
                    foreach (Student student in classroom.ClassRoomStudents)
                    {
                        info += $";{student.UserID}";
                    }
                }
                classroomDB.WriteLine(info);
                info = "TimeSlot";
                if (classroom.Timetables != null && classroom.Timetables.Count != 0)
                {
                    foreach (TimeSlot timeSlot in classroom.Timetables)
                    {
                        info += $";{timeSlot.Week};{timeSlot.Day};{timeSlot.StartingTime}";
                        if (timeSlot.Teacher != null)
                        {
                            info += $";{timeSlot.Teacher.UserID}";
                        }
                        else
                        {
                            info += ";-1";
                        }
                    }
                }
                classroomDB.WriteLine(info);
            }
            classroomDB.Close();
            #endregion
            StreamWriter facultyClassroomDB = new StreamWriter(path_FacultyClassroom);
            #region
            foreach (User user in UserList)
            {
                if (user is Faculty)
                {
                    Faculty faculty = (Faculty)user;
                    if (faculty.ClassroomsTeaching != null && faculty.ClassroomsTeaching.Count != 0)
                    {
                        facultyClassroomDB.WriteLine($"ID;{faculty.UserID}");
                        string information = "Classroom_ID";
                        foreach (Classroom classroom in faculty.ClassroomsTeaching)
                        {
                            information += $";{classroom.ClassRoomID}";
                        }
                        facultyClassroomDB.WriteLine(information);
                    }
                }
            }
            facultyClassroomDB.Close();
            #endregion
            StreamWriter studentClassroomDB = new StreamWriter(path_StudentClassroom);
            #region
            foreach (User user in UserList)
            {
                if (user is Student)
                {
                    Student student = (Student)user;
                    if (student.ClassroomStudying != null && student.ClassroomStudying.Count != 0)
                    {
                        studentClassroomDB.WriteLine($"ID;{student.UserID}");
                        string information = "Classroom_ID";
                        foreach (Classroom classroom in student.ClassroomStudying)
                        {
                            information += $";{classroom.ClassRoomID}";
                        }
                        studentClassroomDB.WriteLine(information);
                    }
                }
            }
            studentClassroomDB.Close();
            #endregion
            StreamWriter studentAttendencesDB = new StreamWriter(path_StudentAttendences);
            #region
            foreach (User user in UserList)
            {
                if (user is Student)
                {
                    Student student = (Student)user;
                    if (student.Attendances != null && student.Attendances.Count != 0)
                    {
                        foreach (Attendance attendance in student.Attendances)
                        {
                            studentAttendencesDB.WriteLine($"ID;{student.UserID}"); 
                            studentAttendencesDB.WriteLine($"Classroom;{attendance.AbsentClass.ClassRoomID}");
                            studentAttendencesDB.WriteLine($"TimeSlot;{attendance.AbsentTimeSlot.Week};{attendance.AbsentTimeSlot.Day};{attendance.AbsentTimeSlot.StartingTime}");
                            string information = "Faculty_ID";
                            if (attendance.AbsentTimeSlot.Teacher != null)
                            {
                                information+=$";{attendance.AbsentTimeSlot.Teacher.UserID}";
                            }
                            studentAttendencesDB.WriteLine(information);
                        }
                    }
                }
            }
            studentAttendencesDB.Close();
            #endregion
            StreamWriter studentNotesDB = new StreamWriter(path_StudentNotes);
            #region
            foreach (User user in UserList)
            {
                if (user is Student)
                {
                    Student student = (Student)user;
                    if (student.NotesReceive != null && student.NotesReceive.Count != 0)
                    {
                        studentNotesDB.WriteLine($"ID;{student.UserID}");
                        foreach (Note note in student.NotesReceive)
                        {
                            studentNotesDB.WriteLine($"ExamID;{note.ExamNote.ExamID}");
                            studentNotesDB.WriteLine($"Notes;{note.NoteValue}");
                        }
                    }
                }
            }
            studentNotesDB.Close();
            #endregion
            StreamWriter lastID = new StreamWriter(path_LastID);
            #region
            lastID.WriteLine($"LastUserID;{LastUserID}");
            lastID.WriteLine($"LastDisciplineID;{LastDisciplineID}");
            lastID.WriteLine($"LastClassroomID;{LastClassroomID}");
            lastID.WriteLine($"LastExamID;{LastExamID}");
            lastID.Close();
            #endregion
        }
        public Application()
        {
            UserList = new List<User>();
            DisciplineList = new List<Discipline>();
            Classrooms = new List<Classroom>();
            Exams = new List<Exam>();
            Administrator firstAdmin = new Administrator("Admin", "First", "fa@app.com", "0", 0);
            UserList.Add(firstAdmin);
            LastUserID = 0;
            LastDisciplineID = -1;//because create a discipline by hand in program.cs ->> need to change after
            LastClassroomID = 0;
            LastExamID = -1;

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
                        FromAppToCSV("path_UserDB.csv", "path_DisciplineDB.csv", "path_ExamDB.csv", "path_ClassroomDB.csv", "path_FacultyClassroom.csv", "path_StudentClassroom.csv", "path_StudentAttendences.csv", "path_StudentNotes.csv", "path_LastID.csv");
                        break;
                    case 4:
                        FromAppToCSV("path_UserDB.csv", "path_DisciplineDB.csv", "path_ExamDB.csv", "path_ClassroomDB.csv", "path_FacultyClassroom.csv", "path_StudentClassroom.csv", "path_StudentAttendences.csv", "path_StudentNotes.csv", "path_LastID.csv");
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
                int answer = EnterValue.AskingNumber("Enter what you want to do\n1 : See personal information\n2 : Change personal Information\n3 : See timetable\n4 : See Notes\n5 : See date Exam\n6 : See discipline studying\n7 : See class missed\n8 : See classroom enrolled information\n9 : Log out", 1, 9);
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
                        Console.WriteLine(currentStudent.SeeAllNotes());
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
                        currentStudent.SeeAttenances();
                        break;
                    case 8:
                        Console.WriteLine(GenericFunction.ClassroomsEssentialInformation(currentStudent.ClassroomStudying));
                        break;
                    case 9:
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
                int answer = EnterValue.AskingNumber("Enter what you want to do\n1 : See personal information\n2 : Change personal Information\n3 : Go to the discipline menu\n4 : Go to the Classroom Menu\n5 : Go to the Exam menu\n6 : Go to the user menu\n7 : Log out", 1,7);
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
                        logout = ClassRoomMenu_Administrator();
                        break;
                    #endregion
                    case 5:
                        ExamMenu_Administrator();
                        break;
                    case 6:
                        #region
                        UserMenu_Administrator();
                        break;
                    #endregion
                    case 7:
                        #region
                        logout = true;
                        break;
                        #endregion
                }
            }
        }
        public void ExamMenu_Administrator()
        {
            bool stay = true;
            while (stay)
            {
                int answer = EnterValue.AskingNumber("Enter what you want to do\n1 : Add a new Exam\n2 : Edit an Exam\n3 : See all Exams information\n4 : Go back to the previous menu", 1, 4);
                switch (answer)
                {
                    case 1:
                        #region
                        if (DisciplineList != null || DisciplineList.Count == 0)
                        {
                            int week = EnterValue.AskingNumber("Enter the number of the week between 1 and 10", 1, 10);
                            int day = EnterValue.AskingNumber("Enter the day you want \n1=Monday\n2=Tuesday\n3=Wednesday\n4=Thursday\n5=Friday\n6=Saturday", 1, 6);
                            int startingTime = EnterValue.AskingNumber("Enter the starting time between 8 and 19", 8, 19);
                            int endingTime = EnterValue.AskingNumber($"Enter the ending time between {startingTime + 1} and 20", startingTime + 1, 20);
                            int disciplineID = -1;
                            while (disciplineID == -1)
                            {
                                Console.WriteLine("You have to choose Discipline(useless to choose go back to the previous menu)");
                                disciplineID = GenericFunction.ChoosingDisciplineID(DisciplineList);
                            }
                            Console.WriteLine("Enter the exam name");
                            string examName = Console.ReadLine();
                            Exams.Add(new Exam(DisciplineList[GenericFunction.IndexDisciplineID(disciplineID, DisciplineList)], examName, week, day, startingTime, endingTime));
                            Exams[Exams.Count - 1].ExamID=PutANewExamID();
                        }
                        else
                        {
                            Console.WriteLine("Create a discipline before");
                        }

                        break;
                    #endregion
                    case 2:
                        bool stayEditing = true;
                        while (stayEditing)
                        {
                            int choiceAnswer = EnterValue.AskingNumber("Enter what you want to do\n1 : Choose an Exam you want to edit\n2 : Go to the previous menu", 1, 2);
                            switch (choiceAnswer)
                            {
                                case 1:
                                    int indexExam = GenericFunction.ChoosingIndexExamList(Exams);
                                    if (indexExam != -1)
                                    {
                                        Exam choosenExam = Exams[indexExam];
                                        bool stayThisExam = true;
                                        while (stayThisExam)
                                        {
                                            int choosenFunction = EnterValue.AskingNumber("Enter what you want to do\n1 : See information\n2 : Switch date\n3 : Switch name\n4 : Switch Discipline\n5 : Remove the exam\n6 : Choose an other Exam\n7 : Go back ", 1, 7);
                                            switch (choosenFunction)
                                            {
                                                case 1:
                                                    Console.WriteLine(GenericFunction.ExamListInformation(Exams));
                                                    break;
                                                case 2:
                                                    choosenExam.Week = EnterValue.AskingNumber("Enter the number of the week between 1 and 10", 1, 10);
                                                    choosenExam.Day = EnterValue.AskingNumber("Enter the day you want \n1=Monday\n2=Tuesday\n3=Wednesday\n4=Thursday\n5=Friday\n6=Saturday", 1, 6);
                                                    choosenExam.StartingHour = EnterValue.AskingNumber("Enter the starting time between 8 and 19", 8, 19);
                                                    choosenExam.EndingHour = EnterValue.AskingNumber($"Enter the ending time between {choosenExam.StartingHour + 1} and 20", choosenExam.StartingHour + 1, 20);
                                                    break;
                                                case 3:
                                                    Console.WriteLine("Enter the new name");
                                                    choosenExam.ExamName = Console.ReadLine();
                                                    break;
                                                case 4:
                                                    int disciplineID = GenericFunction.ChoosingDisciplineID(DisciplineList);
                                                    if (disciplineID != -1)
                                                    {
                                                        choosenExam.ExamDiscipline = DisciplineList[GenericFunction.IndexDisciplineID(disciplineID, DisciplineList)];
                                                    }
                                                    break;
                                                case 5:
                                                    foreach (User user in UserList)
                                                    {
                                                        if (user is Student)
                                                        {
                                                            Student verificationStudent = (Student)user;
                                                            verificationStudent.RemoveNotesFromAnExam(choosenExam);
                                                            Exams.Remove(choosenExam);
                                                            stayThisExam = false;
                                                        }
                                                    }
                                                    break;
                                                case 6:
                                                    stayThisExam = false;
                                                    break;
                                                case 7:
                                                    stayThisExam = false;
                                                    stayEditing = false;
                                                    break;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        stayEditing = false;
                                    }
                                    break;
                                case 2:
                                    stayEditing = false;
                                    break;
                            }
                        }
                        break;
                    case 3:
                        Console.WriteLine(GenericFunction.ExamListInformation(Exams));
                        break;
                    case 4:
                        stay = false;
                        break;
                }
            }
        }
        public void UserMenu_Administrator()
        {
            bool stay = true;
            while (stay)
            {
                int answer = EnterValue.AskingNumber("Enter what you want to do\n1 : Add a new user\n2 : Edit a User\n3 : See all users information\n4 : Go back to the previous menu", 1, 4);
                switch (answer)
                {
                    case 1:
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
                    case 2:
                        int userID = GenericFunction.ChoosingAUserID(UserList);
                        if (userID != -1)
                        {
                            bool stayEdit = true;
                            while (stayEdit)
                            {
                            int editingChoice = EnterValue.AskingNumber("Enter what you want to do\n1 : Change personal Information\n2 : See user information\n3 : Remove user\n4 : Go back to the previous menu", 1, 4);
                            switch (editingChoice)
                            {
                                case 1:
                                    UserList[GenericFunction.IndexUserID(userID, UserList)].ChangeInformation();
                                    break;
                                case 2:
                                    Console.WriteLine(UserList[GenericFunction.IndexUserID(userID, UserList)].GeneralInformation());
                                    break;
                                case 3:
                                        if (userID == 0)
                                        {
                                            Console.WriteLine("This administrator can't be removed");
                                        }
                                        else
                                        {
                                            if (UserList[GenericFunction.IndexUserID(userID, UserList)] is Student)
                                            {
                                                Student studentRemoved = (Student)UserList[GenericFunction.IndexUserID(userID, UserList)];
                                                if (Classrooms != null && Classrooms.Count != 0)
                                                {
                                                    foreach (Classroom classroom in Classrooms)
                                                    {
                                                        if (classroom.ClassRoomStudents != null && classroom.ClassRoomStudents.Contains(studentRemoved))
                                                        {
                                                            classroom.ClassRoomStudents.Remove(studentRemoved);
                                                        }
                                                    }
                                                }
                                                UserList.Remove(studentRemoved);
                                            }
                                            else if (UserList[GenericFunction.IndexUserID(userID, UserList)] is Faculty)
                                            {
                                                Faculty facultyRemoved = (Faculty)UserList[GenericFunction.IndexUserID(userID, UserList)];
                                                if (Classrooms != null && Classrooms.Count != 0)
                                                {
                                                    foreach (Classroom classroom in Classrooms)
                                                    {
                                                        if (classroom.ClassRoomFaculties != null && classroom.ClassRoomFaculties.Contains(facultyRemoved))
                                                        {
                                                            classroom.ClassRoomFaculties.Remove(facultyRemoved);
                                                        }
                                                    }
                                                }
                                                UserList.Remove(facultyRemoved);
                                            }
                                            else if (UserList[GenericFunction.IndexUserID(userID, UserList)] is Administrator)
                                            {
                                                Administrator facultyRemoved = (Administrator)UserList[GenericFunction.IndexUserID(userID, UserList)];
                                                UserList.Remove(facultyRemoved);
                                            }
                                            Console.WriteLine("the user has been removed");
                                            stayEdit = false;
                                        }
                                    break;
                                case 4:
                                        stayEdit = false;
                                    break;
                                }
                            }
                        }
                        break;
                    case 3:
                        Console.WriteLine(GenericFunction.UsersPublicInformation(UserList));
                        break;
                    case 4:
                        stay = false;
                        break;
                }
            }
        }
        public bool ClassRoomMenu_Administrator()
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
                            Classroom choosenClassroom = Classrooms[GenericFunction.IndexClassroomID(classroomIDanswer, Classrooms)];
                            bool stayInTheEditClassroom = true;
                            while (stayInTheEditClassroom)
                            {
                                int editClassroomAnswer = EnterValue.AskingNumber("Enter what you want to do\n1 : Add a student\n2 : Add a faculty\n3 : Switch the discipline\n4 : Switch the classroom name\n5 : Edit time slots of the classroom\n6 : See the classroom information\n7 : Edit the attendance of a student\n8 : Go back to the previous menu\n9 : Log out", 1, 9);
                                switch (editClassroomAnswer)
                                {
                                    case 1:
                                        int studentIDAnswer = GenericFunction.ChoosingStudentID(UserList);
                                        if (studentIDAnswer != -1)
                                        {
                                            Student choosenStudent = (Student)UserList[GenericFunction.IndexUserID(studentIDAnswer, UserList)];
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
                                            Faculty choosenFaculty = (Faculty)UserList[GenericFunction.IndexUserID(facultyIDAnswer, UserList)];
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
                                            choosenClassroom.ClassRoomDiscipline = DisciplineList[GenericFunction.IndexDisciplineID(disciplineIDAnswer, DisciplineList)];
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
                                        #region
                                        bool stayEditAttendance = true;
                                        while (stayEditAttendance)
                                        {
                                            int functionAttendence = EnterValue.AskingNumber("Enter what you want to do\n1 : Add a missing class to a student\n2 : Remove a missing class to a student\n3 : Go back to the previous menu", 1, 3);
                                            switch (functionAttendence)
                                            {
                                                case 1:
                                                    bool stayAddAttendance2 = true;
                                                    while (stayAddAttendance2)
                                                    {
                                                        int addAttendence1 = EnterValue.AskingNumber("Enter what you want to do\n1 : Enter the index of the timeslot where the student where absent\n2 : Go back", 1, 2);
                                                        switch (addAttendence1)
                                                        {
                                                            case 1:
                                                                int indexTimeSlot = GenericFunction.ChoosingIndexTimeSlotList(choosenClassroom.Timetables);
                                                                if (indexTimeSlot != -1)
                                                                {
                                                                    TimeSlot choosenTimeSlot = choosenClassroom.Timetables[indexTimeSlot];
                                                                    bool stayThisStudent = true;
                                                                    while (stayThisStudent)
                                                                    {
                                                                        int addAttendence2 = EnterValue.AskingNumber("Enter what you want to do\n1 : Enter the ID of the absent student\n2 : See the time slot information\n3 : Change the time slot\n4 : Go back", 1, 4);
                                                                        switch (addAttendence2)
                                                                        {
                                                                            case 1:
                                                                                int missing_StudentID = GenericFunction.ChoosingStudentID_FromListStudent(choosenClassroom.ClassRoomStudents);
                                                                                if (missing_StudentID != -1)
                                                                                {
                                                                                    Student missingStudent = choosenClassroom.ClassRoomStudents[GenericFunction.IndexUserID_StudentList(missing_StudentID, choosenClassroom.ClassRoomStudents)];
                                                                                    Attendance missingClass = new Attendance(choosenClassroom, choosenTimeSlot);
                                                                                    missingStudent.Attendances.Add(missingClass);
                                                                                }
                                                                                break;
                                                                            case 2:
                                                                                Console.WriteLine(choosenTimeSlot.Information());
                                                                                break;
                                                                            case 3:
                                                                                stayThisStudent = false;
                                                                                break;

                                                                            case 4:
                                                                                stayThisStudent = false;
                                                                                stayAddAttendance2 = false;
                                                                                break;
                                                                        }
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    stayAddAttendance2 = false;
                                                                }
                                                                break;
                                                            case 2:
                                                                stayAddAttendance2 = false;
                                                                break;
                                                        }
                                                    }
                                                    break;
                                                case 2:
                                                    bool stayRemovedAttendance = true;
                                                    while (stayRemovedAttendance)
                                                    {
                                                        int chooseStudent = EnterValue.AskingNumber("Enter what you want to do\n1 : Enter the ID of the absent student\n2 : Go back", 1, 2);
                                                        switch (chooseStudent)
                                                        {
                                                            case 1:
                                                                int studentID = GenericFunction.ChoosingStudentID_FromListStudent(choosenClassroom.ClassRoomStudents);
                                                                if (studentID != -1)
                                                                {
                                                                    bool stayToThisStudent = true;
                                                                    while (stayToThisStudent)
                                                                    {
                                                                        Student choosenStudent = choosenClassroom.ClassRoomStudents[GenericFunction.IndexUserID_StudentList(studentID, choosenClassroom.ClassRoomStudents)];
                                                                        int addAttendence1 = EnterValue.AskingNumber("Enter what you want to do\n1 : Enter the index of the timeslot you want to remove\n2 : See student missing classroom\n3 : Change student\n4 : Go back", 1, 4);
                                                                        switch (addAttendence1)
                                                                        {
                                                                            case 1:
                                                                                int indexTimeSlot = GenericFunction.ChoosingAttendanceList(choosenStudent.Attendances);
                                                                                if (indexTimeSlot != -1)
                                                                                {
                                                                                    choosenStudent.Attendances.RemoveAt(indexTimeSlot);
                                                                                }
                                                                                break;
                                                                            case 2:
                                                                                choosenStudent.SeeAttenances();
                                                                                break;
                                                                            case 3:
                                                                                stayToThisStudent = false;
                                                                                break;
                                                                            case 4:
                                                                                stayToThisStudent = false;
                                                                                stayRemovedAttendance = false;
                                                                                break;
                                                                        }
                                                                    }
                                                                }
                                                                    break;
                                                                case 2:
                                                                stayRemovedAttendance = false;
                                                                break;
                                                        }
                                                    }

                                                    break;
                                                case 3:
                                                    stayEditAttendance = false;
                                                    break;
                                            }
                                        }
                                        break;
                                    #endregion
                                    case 8:
                                        stayInTheEditClassroom = false;
                                        break;
                                    case 9:
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
                                int enrollAnswer = EnterValue.AskingNumber("Enter what you want to do\n1 : Change the name\n2 : Remove the Discipline\n3 : See discipline information\n4 : Go back to the previous menu\n5 : Log out", 1, 5);
                                switch (enrollAnswer)
                                {
                                    case 1:
                                        Console.WriteLine("Enter the name you want");
                                        choosenDiscipline.DisciplineName = Console.ReadLine();
                                        break;
                                    case 2:
                                        Console.WriteLine("NOTHING HAS BEEN MADE FOR THIS");
                                        break;
                                    case 3:
                                        Console.WriteLine(choosenDiscipline.PublicInformation());
                                        break;
                                    case 4:
                                        #region
                                        stayInChooseFunction = false;
                                        #endregion
                                        break;
                                    case 5:
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
                int answer = EnterValue.AskingNumber("Enter what you want to do\n1 : See personal information\n2 : Change personal Information\n3 : See information about one of your student\n4 : Change/Add a mark\n5 : Log out", 1, 5);
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
                    case 4:
                        #region
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
                                                                        bool stayEdit = true;
                                                                        while (stayEdit)
                                                                        {
                                                                            int editChoice = EnterValue.AskingNumber("Enter what you want to do\n1 : Add a new note\n2 : Change a note\n3 : Choose an other exam\n4 :  Choose an other student\n5 : Choose an other classroom\n6 : Leave this menu", 1, 6);
                                                                            switch (editChoice)
                                                                            {
                                                                                case 1:
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
                                                                                    break;
                                                                                case 2:
                                                                                    int indexNote = GenericFunction.ChoosingIndexNoteList(choosenStudent.NotesReceive);
                                                                                    if (indexNote != -1)
                                                                                    {
                                                                                        Console.WriteLine("Enter the note value between 0 and 20");
                                                                                        double newNoteValue = -1;
                                                                                        try
                                                                                        {
                                                                                            newNoteValue = Convert.ToDouble(Console.ReadLine());
                                                                                        }
                                                                                        catch (FormatException)
                                                                                        {
                                                                                            Console.WriteLine("The input was not a double");
                                                                                        }
                                                                                        if (newNoteValue >= 0 && newNoteValue <= 20)
                                                                                        {
                                                                                            choosenStudent.NotesReceive[indexNote].NoteValue=newNoteValue;
                                                                                            Console.WriteLine("The note has been changed");
                                                                                        }
                                                                                        else
                                                                                        {
                                                                                            Console.WriteLine("the entered value ins't between 0 and 20");
                                                                                        }
                                                                                    }
                                                                                    break;
                                                                                case 3:
                                                                                    stayEdit = false;
                                                                                    break;
                                                                                case 4:
                                                                                    stayEdit = false;
                                                                                    stayInThisExam = false;
                                                                                    break;
                                                                                case 5:
                                                                                    stayEdit = false;
                                                                                    stayInThisExam = false;
                                                                                    stayStudent = false;
                                                                                    break;
                                                                                case 6:
                                                                                    stayEdit = false;
                                                                                    stayInThisExam = false;
                                                                                    stayStudent = false;
                                                                                    addingNotes = false;
                                                                                    break;
                                                                            }
                                                                            
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
                    #endregion
                    case 5:
                        logout = true;
                        break;
                }
            }
        }
        
        public int PutANewExamID()
        {
            LastExamID++;
            return LastExamID;
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



    }
}
