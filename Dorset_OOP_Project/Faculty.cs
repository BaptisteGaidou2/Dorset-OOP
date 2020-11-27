using System;
using System.Collections.Generic;
using System.Text;

namespace Dorset_OOP_Project
{
    public class Faculty : User
    {
        public List<Classroom> ClassroomsTeaching { get; set; }

        public Faculty(string lastName, string firstName) : base(lastName, firstName)
        {
            ClassroomsTeaching = new List<Classroom>();
        }

        public Faculty(string lastName, string firstName, string email, string password) : base(lastName, firstName, email, password)
        {

            ClassroomsTeaching = new List<Classroom>();
        }

        public Faculty(string lastName, string firstName, string email, string password, int userID) : base(lastName, firstName, email, password, userID)
        {
            ClassroomsTeaching = new List<Classroom>();
        }
        public void RemoveClassroom_FromAnID(int classroomID)
        {
            if (GenericFunction.ContainClassroomID(classroomID, ClassroomsTeaching))
            {
                ClassroomsTeaching.RemoveAt(GenericFunction.IndexClassroomID(classroomID, ClassroomsTeaching));
            }
        }
        public List<Discipline> DisciplinesTeaching()
        {
            List<Discipline> discplinesTeaching = new List<Discipline>();
            foreach (Classroom classroom in ClassroomsTeaching)
            {
                if (!discplinesTeaching.Contains(classroom.ClassRoomDiscipline))
                {
                    discplinesTeaching.Add(classroom.ClassRoomDiscipline);
                }
            }
            return discplinesTeaching;
        }
        public void MenuSeeStudentInformation()
        {
            bool stay = true;
            while (stay)
            {
                int answer = EnterValue.AskingNumber("Enter what you want to do\n1 : See a student information in your classroom\n2 : Go to the previous menu", 1, 2);
                switch (answer)
                {
                    case 1:
                        bool stayInClassroom = true;
                        while (stayInClassroom)
                        {
                            int classroomIDAnswer = GenericFunction.ChoosingClassroomID(ClassroomsTeaching);
                            if (classroomIDAnswer != -1)
                            {
                                Classroom choosenClassroom = ClassroomsTeaching[GenericFunction.IndexClassroomID(classroomIDAnswer, ClassroomsTeaching)];
                                bool stayInStudent = true;
                                while (stayInStudent)
                                {
                                    int answerStudent = EnterValue.AskingNumber("Enter what you want to do\n1 : Choose a student  in the classroom choosen\n2 : Change classroom\n3 : Leave this menu", 1, 3);
                                    switch (answerStudent)
                                    {
                                        case 1:
                                            int studentIDAnswer = GenericFunction.ChoosingStudentID_FromListStudent(choosenClassroom.ClassRoomStudents);
                                            if (studentIDAnswer != -1)
                                            {
                                                Student choosenStudent = choosenClassroom.ClassRoomStudents[GenericFunction.IndexUserID_StudentList(studentIDAnswer, choosenClassroom.ClassRoomStudents)];
                                                bool stayInInformation = true;
                                                while (stayInInformation)
                                                {
                                                    int informationChoosen = EnterValue.AskingNumber("Enter what you want to do\n1 : See student discline learning\n2 : See note from this discpline classroom\n3 : Choose another student\n4 : Choose another classroom\n5 : Leave this menu", 1, 5);
                                                    switch (informationChoosen)
                                                    {
                                                        case 1:
                                                            Console.WriteLine(choosenStudent.SeeDisciplineStudying());
                                                            break;
                                                        case 2:
                                                            Console.WriteLine(choosenStudent.SeeNotesFromADiscipline(choosenClassroom.ClassRoomDiscipline));
                                                            break;
                                                        case 3:
                                                            stayInInformation = false;
                                                            break;
                                                        case 4:
                                                            stayInInformation = false;
                                                            stayInStudent = false;
                                                            break;
                                                        case 5:
                                                            stayInInformation = false;
                                                            stayInStudent = false;
                                                            stayInClassroom = false;
                                                            stay = false;
                                                            break;

                                                    }

                                                }
                                            }
                                            else
                                            {
                                                stayInStudent = false;
                                            }
                                            break;
                                        case 2:
                                            stayInStudent = false;
                                            break;
                                        case 3:
                                            stayInStudent = false;
                                            stayInClassroom = false;
                                            stay = false;
                                            break;
                                    }

                                }
                            }
                            else
                            {
                                stayInClassroom = false;
                            }
                        }
                        break;
                    case 2:
                        stay = false;
                        break;
                }
                

            }
        }
        public override string PublicApplicationInformation()
        {
            return $"{base.PublicApplicationInformation()} | type : faculty ";
        }
        public override string PersonalInformation()
        {
            return $"{base.PersonalInformation()} | type : faculty ";
        }
        public bool AddClassroom(Classroom classroom)
        {
            bool added = false;
            if (ClassroomsTeaching==null||ClassroomsTeaching.Count==0||!ClassroomsTeaching.Contains(classroom))
            {
                ClassroomsTeaching.Add(classroom);
                added = true;
            }
            return added;
        }

    }
}
