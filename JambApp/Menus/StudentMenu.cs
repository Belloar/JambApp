using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JambApp.Managers;
using JambApp.Managers.Interfaces;
using JambApp.Models;
using JambApp.enums;

namespace JambApp.Menus
{
    public class StudentMenu
    {
        StudentManager studentManager = new StudentManager();
        SubjectManager subjectManager = new SubjectManager();
       
        public void PrintMenu()
        {
            Console.WriteLine("1.login");
            Console.WriteLine("2.Register");
            Console.WriteLine("3.exit");
        }

        public void Menu()
        {
            PrintMenu();
            
            var quit = true;

            while (quit)
            {
                
                Console.Write("Input your option: ");
                int option = int.Parse(Console.ReadLine());
               
                switch (option)
                {
                    case 1:
                        studentManager.Login();
                        
                        //PrintStudentOption();
                        break;
                    case 2:
                        Student student = null;
                        Address address = null;
                        Console.Write("Input your email address : ");
                        string email = Console.ReadLine();
                        Console.Write("input your first name : ");
                        string firstName = Console.ReadLine();
                        Console.Write("Input your last name : ");
                        string lastName = Console.ReadLine();
                        Console.Write("Input a password : ");
                        string password = Console.ReadLine();
                        Console.Write("Confirm password");
                        string password1 = Console.ReadLine();
                        while (password != password1)
                        {
                            Console.WriteLine(" \t invalid password please input password again");
                            password1 = Console.ReadLine();
                        }
                        Console.Write("what is your gender\ninput 1 for male\n 2 for female \n 3 for rather not say");
                        int gender;
                        while (!int.TryParse(Console.ReadLine(), out gender) && gender > 0 && gender < 4)
                        {
                            Console.WriteLine("invalid input enter 1,2,or 3 : ");
                        }
                        Console.Write("Input your home address : ");
                        string homeAddress = Console.ReadLine();
                        Console.WriteLine("Input your city of residence ");
                        string city = Console.ReadLine();
                        Console.Write("Input your state of residence : ");
                        string state = Console.ReadLine();
                        Console.WriteLine("what is your nationality");
                        string country = Console.ReadLine();
                        Console.Write("Input your NIN : ");
                        string nin = Console.ReadLine();
                        Role role = (Role)1;
                        string JambNumber = studentManager.JambNumberGenerator();
                        student = new Student(firstName, lastName, email, (Gender)gender, address, nin, JambNumber);
                        address = new Address(homeAddress, city, state, country);
                        studentManager.RegisterStudent(student);
                        subjectManager.CollectSubject(email);
                        break;
                    case 3:
                        quit = false;
                        break;
                    default:
                        Console.WriteLine("invalid Option input a valid option");
                        
                        break;

                }
            }
        }
    }
}
