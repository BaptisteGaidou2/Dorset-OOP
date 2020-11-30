using System;
using System.Collections.Generic;

namespace Dorset_OOP_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            Application schoolApplication = new Application("path_UserDB.csv", "path_DisciplineDB.csv", "path_ExamDB.csv", "path_ClassroomDB.csv", "path_FacultyClassroom.csv", "path_StudentClassroom.csv", "path_StudentAttendences.csv", "path_StudentNotes.csv", "path_LastID.csv");
            schoolApplication.StartingMenu();
            //Student : OOP Group 14 Paul Froidefond 23192, Yoan Gabison 23208, Baptiste Gaidou 22845, Clarysse GIELEN 23394, Eliott TOURTOULOU 23409
            Application saveSimpleDatabase = new Application();
            Discipline info = new Discipline("info");
            Classroom classroom = new Classroom("Class1",info);
            saveSimpleDatabase.Classrooms.Add(classroom);
            for(int i = 0; i < 30; i++)
            {
                saveSimpleDatabase.AddNewUser(new Student($"student{i}", $"sc{i}", $"student{i}@app.com", $"{i}"));
                //classroom.AddStudent((Student)schoolApplication.UserList[schoolApplication.UserList.Count - 1]);
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
            Console.ReadLine();
        }
    }
}
