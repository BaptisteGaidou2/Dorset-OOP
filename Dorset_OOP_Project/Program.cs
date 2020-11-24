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
            Student student1 = new Student("student1", "sc", "student1@app.com", "0");//userID=1 password=0
            schoolApplication.AddNewUser(student1);
            Student student2 = new Student("student2", "sc", "student2@app.com", "0");//userID=2 password=0
            schoolApplication.AddNewUser(student2);
            Faculty faculty1 = new Faculty("faculty1", "fc", "faculty1@app.com", "0");//userID=3 password=0
            schoolApplication.AddNewUser(faculty1);
            Faculty faculty2 = new Faculty("faculty2", "fc", "faculty1@app.com", "0");//userID=4 password=0
            schoolApplication.AddNewUser(faculty2);
            Administrator secondAdministrator = new Administrator("adm2", "ad", "adm@app.com", "0");//userID=5 password=0
            schoolApplication.AddNewUser(secondAdministrator);
            Discipline info = new Discipline("info");
            schoolApplication.AddDiscipline(info);//disciplineID=1
            schoolApplication.DisciplineList[0].EnrollAStudent(student2);
            schoolApplication.DisciplineList[0].EnrollAStudent(student2);
            schoolApplication.DisciplineList[0].EnrollAStudent(student1);
            schoolApplication.DisciplineList[0].EnrollAFaculty(faculty2);
            schoolApplication.DisciplineList[0].EnrollAFaculty(faculty2);
            schoolApplication.DisciplineList[0].EnrollAFaculty(faculty1);
            schoolApplication.StartingMenu();
            Console.ReadLine();
        }
    }
}
