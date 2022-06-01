using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JambApp.enums;
using JambApp.Models;
using JambApp.Managers.Interfaces;

namespace JambApp.Managers
{
    public class StudentManager
    {
        int NoOfStudents = 0;
        ICentreManager centreManager = new CentreManager();
        SubjectManager subjectManager = new();
        InstitutionsManager institutionsManager = new();


        public List<Student> students;
        public const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public StudentManager()
        {
           /* students = new()
            {
                new Student(1,"warri","man","warriman@gmail.com","0000",Gender.Male,"warriLand","00000",Role.Student,"0000aa",CentreManager.centres[2],DateTime.Now,0,"ogun","")
            }*/
        }
        public void RegisterStudent()
        {
            NoOfStudents++;
            Console.Write("input your first name : ");
            string firstName = Console.ReadLine();

            Console.Write("Input your last name : ");
            string lastName = Console.ReadLine();

            Console.Write("Input your email address : ");
            string email = Console.ReadLine();
            
            foreach(var aStudent in students )
            {
                if(aStudent.Email == email)
                {
                    Console.WriteLine("a Student with this email has already been added");
                }
            }
            Console.Write("Input a password : ");
            string password = Console.ReadLine();

            Console.Write("Confirm password");
            string password1 = Console.ReadLine();

            while(password != password1)
            {
                Console.WriteLine(" \t invalid password please input password again");
                password1 = Console.ReadLine();
            }

            Console.Write("what is your gender\ninput 1 for male\n 2 for female \n 3 for rather not say");
            int gender;
            while(!int.TryParse(Console.ReadLine(),out gender ) && gender > 0 && gender < 4)
            {
                Console.WriteLine("invalid input enter 1,2,or 3 : ");
            }

            Console.Write("Input your home address : ");
            string address = Console.ReadLine();

            Console.Write("In what state : ");
            string studentState = Console.ReadLine();

            Console.Write("Input your NIN : ");
            string nin = Console.ReadLine();
            

            Role role = Role.Student;

            string jambNumber = JambNumberGenerator();
            Centre examCentre = centreManager.GenerateExamCentre(studentState);

            var date = DateTime.Now;

            int examScore = 0;

            Dictionary<string, Dictionary<string, string>> studentSubjects = new();
            studentSubjects = subjectManager.CollectSubject();

            List<Institutions> studentInstitutions = new();
            studentInstitutions = institutionsManager.PickInstitution();

            var student = new Student(NoOfStudents, firstName, lastName, email, password, (Gender)gender, address, nin, role, jambNumber, examCentre, date, examScore, studentState, studentSubjects, studentInstitutions);
                students.Add(student);

        }
        public string JambNumberGenerator()
        {
            StringBuilder stringBuilder = new();
            Random random = new();

            string jambNumber = string.Empty;
            string letters = string.Empty;
            for(int i = 0; i < 2; i++)
            {
               letters = stringBuilder.Append(chars[random.Next(chars.Length)]).ToString();
               jambNumber = $"{random.Next(1000, 9999)}{random.Next(1000, 9999)}{letters}";
            }
            return jambNumber;

        }
        public void Print(Student student)
        {
                Console.WriteLine($"{student.LastName}{student.FirstName}\n {student.Email}\n{student.Password}\n\t{student.Gender}\n\t{student.Address}\n\t{student.Nin}\n{student.Role}\n{student.JambNumber}\n{student.ExamCentre}\n{student.Date}\n{student.ExamScore}\n{student.StudentState}\n{student.StudentSubjects}\n{student.StudentInstitutions}");           
        }
        public void GetAllStudents()
        {
            foreach(var student in students)
            {
                Console.WriteLine($"{student.LastName}{student.FirstName}\n {student.Email}\n{student.Password}\n\t{student.Gender}\n\t{student.Address}\n\t{student.Nin}\n{student.Role}\n{student.JambNumber}\n{student.ExamCentre}\n{student.Date}\n{student.ExamScore}\n{student.StudentState}\n{student.StudentSubjects}\n{student.StudentInstitutions}");
            }
        }
        public void GetStudentByJnum(string jambNumber)
        {
            foreach(var student in students)
            {
                if(student.JambNumber == jambNumber)
                {
                    Print(student);
                }
                else
                {
                    Console.WriteLine("A Student with this JambNumber does not exist");
                }
            }
        }
        public void GetStudentByEmail(string email)
        {
            foreach (var student in students)
            {
                if (student.Email == email)
                {
                    Print(student);
                }
                else
                {
                    Console.WriteLine("A Student with this JambNumber does not exist");
                }
            }
        }

    }
}
