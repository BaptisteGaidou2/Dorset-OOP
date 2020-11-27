using System;
using System.Collections.Generic;

namespace Dorset_OOP_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            //1stcommit
            //Student : OOP Group 14 Paul Froidefond 23192, Yoan Gabison 23208, Baptiste Gaidou 22845, Clarysse GIELEN 23394, Eliott TOURTOULOU 23409
            Application schoolApplication = new Application();
            Discipline info = new Discipline("info");
            Classroom classroom = new Classroom("Class1",info);
            schoolApplication.Classrooms.Add(classroom);
            for(int i = 0; i < 30; i++)
            {
                schoolApplication.AddNewUser(new Student($"student{i}", $"sc{i}", $"student{i}@app.com", $"{i}"));
                classroom.AddStudent((Student)schoolApplication.UserList[schoolApplication.UserList.Count - 1]);
            }
            Faculty faculty1 = new Faculty("faculty1", "fc", "faculty1@app.com", "0");//userID=3 password=0
            schoolApplication.AddNewUser(faculty1);
            Faculty faculty2 = new Faculty("faculty2", "fc", "faculty1@app.com", "0");//userID=4 password=0
            schoolApplication.AddNewUser(faculty2);
            Administrator secondAdministrator = new Administrator("adm2", "ad", "adm@app.com", "0");//userID=5 password=0
            schoolApplication.AddNewUser(secondAdministrator);
            schoolApplication.AddDiscipline(info);//disciplineID=1
            schoolApplication.StartingMenu();
            Console.ReadLine();
        }
    }
}
