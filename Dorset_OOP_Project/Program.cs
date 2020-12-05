using System;
using System.Collections.Generic;
using System.IO;


namespace Dorset_OOP_Project
{
    class Program
    {
        static void Main(string[] args)
        {

            //Student : OOP Group 14 Paul Froidefond 23192, Yoan Gabison 23208, Baptiste Gaidou 22845, Clarysse GIELEN 23394, Eliott TOURTOULOU 23409,Navarre Quentin 23218
            string path_UserDB = "path_UserDB.csv";
            string path_DisciplineDB = "path_DisciplineDB.csv";
            string path_ExamDB = "path_ExamDB.csv";
            string path_ClassroomDB = "path_ClassroomDB.csv";
            string path_StudentAttendences = "path_StudentAttendences.csv";
            string path_StudentNotes = "path_StudentNotes.csv";
            string path_LastID = "path_LastID.csv";
            string path_StudentInvoices = "path_StudentInvoices.csv";
            int reset = EnterValue.AskingNumber("Enter what you want to do\n1 : Continue with the database\n2 : Reset the database", 1, 2);
            switch (reset)
            {
                case 2:
                    reset = EnterValue.AskingNumber("Enter what you want to do\n1 : Reset the database\n2 : Don't reset the database", 1, 2);
                    switch (reset)
                    {
                        case 1:
                            StreamWriter userDB = new StreamWriter(path_UserDB);
                            userDB.WriteLine($"Type;Administrator");
                            userDB.WriteLine("ID;0");
                            userDB.WriteLine("FirstName;First");
                            userDB.WriteLine("LastName;Admin");
                            userDB.WriteLine("Email;firstadmin@app.com");
                            userDB.WriteLine("Password;0");
                            userDB.Close();
                            StreamWriter disciplineDB = new StreamWriter(path_DisciplineDB);
                            disciplineDB.Close();
                            StreamWriter examDB = new StreamWriter(path_ExamDB);
                            examDB.Close();
                            StreamWriter classroomDB = new StreamWriter(path_ClassroomDB);
                            classroomDB.Close();
                            StreamWriter studentAttendencesDB = new StreamWriter(path_StudentAttendences);
                            studentAttendencesDB.Close();
                            StreamWriter studentNotesDB = new StreamWriter(path_StudentNotes);
                            studentNotesDB.Close();
                            StreamWriter lastID = new StreamWriter(path_LastID);
                            #region
                            lastID.WriteLine("LastUserID;0");
                            lastID.WriteLine("LastDisciplineID;-1");
                            lastID.WriteLine("LastClassroomID;-1");
                            lastID.WriteLine("LastExamID;-1");
                            lastID.Close();
                            #endregion
                            StreamWriter Invoices = new StreamWriter(path_StudentInvoices);
                            Invoices.Close();
                            break;
                    }
                    break;
            }
            Application schoolApplication = new Application(path_UserDB, path_DisciplineDB, path_ExamDB, path_ClassroomDB, path_StudentAttendences, path_StudentNotes, path_LastID, path_StudentInvoices);
            schoolApplication.StartingMenu();
            /*
            Application saveSimpleDatabase = new Application();
            Discipline info = new Discipline("info");
            Classroom classroom = new Classroom("Class1",info);
            saveSimpleDatabase.Classrooms.Add(classroom);
            for(int i = 0; i < 30; i++)
            {
                saveSimpleDatabase.AddNewUser(new Student($"student{i}", $"sc{i}", $"student{i}@app.com", $"{i}"));
                classroom.AddStudent((Student)saveSimpleDatabase.UserList[saveSimpleDatabase.UserList.Count - 1]);
                Student newStud = (Student)saveSimpleDatabase.UserList[saveSimpleDatabase.UserList.Count - 1];
               classroom.AddStudent(newStud);
                newStud.AddClassroom(classroom);

            }
            Faculty faculty1 = new Faculty("faculty1", "fc", "faculty1@app.com", "0");//userID=3 password=0
            saveSimpleDatabase.AddNewUser(faculty1);
            Faculty faculty2 = new Faculty("faculty2", "fc", "faculty1@app.com", "0");//userID=4 password=0
            saveSimpleDatabase.AddNewUser(faculty2);
            Administrator secondAdministrator = new Administrator("adm2", "ad", "adm@app.com", "0");//userID=5 password=0
            saveSimpleDatabase.AddNewUser(secondAdministrator);
            saveSimpleDatabase.AddDiscipline(info);//disciplineID=1
            saveSimpleDatabase.StartingMenu();
            */
            Console.ReadLine();
        }
    }
}
