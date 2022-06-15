using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JambApp.Managers;
using JambApp.Models;
using JambApp.enums;
using JambApp.Managers.Interfaces;
using JambApp.Repositories;


namespace JambApp.Menus
{
    public class StaffMenu
    {
        ICentreManager centreManager = new CentreManager();
        StaffManager staffManager = new();
        ICourseManager courseManager = new CourseManager();
        //IStudentManager studentManager = new StudentManager();
        IInstitutionsManager institutionsManager = new InstitutionsManager();
        InstitutionRepository instituteRepo = new InstitutionRepository();
        
        public void Menu()
        {
            var exit = false;

            while (!exit)
            {
                Console.Clear();
                PrintMenu();
                int op;
                if (int.TryParse(Console.ReadLine(), out op))
                {
                    switch (op)
                    {
                        case 1:
                            var staff = staffManager.Login();
                            if (staff == null)
                            {
                                Console.Write("Invalid email or password...\nPress enter key to try again.");
                                Console.ReadKey();
                            }
                            else
                            {
                                OtherMenu(staff);
                                Console.WriteLine("Thank you for using our app.");
                                HookScreen();
                            }
                            break;
                        case 0:
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Invalid input...\nPress any key to try again...");
                            Console.ReadKey();
                            break;
                    }
                }

            }
        }

        private void PrintMenu()
        {
            Console.WriteLine("=======oooooooooooooooooo=========");
            Console.WriteLine("<<<< Welcome to JambApp.Staffs >>>");
            Console.WriteLine("=======oooooooooooooooooo=========");
            Console.WriteLine();
            Console.WriteLine("1.\tLogin.");
            Console.WriteLine("0.\tGo back to main menu.");
        }

        private void PrintOtherMenu()
        {

            Console.WriteLine("1.\tAdd new centre");
            Console.WriteLine("2.\tAdd new course.");
            Console.WriteLine("3.\tAdd new staff.");
            Console.WriteLine("4.\tremove a course.");
            Console.WriteLine("5.\tshow Student details");
            Console.WriteLine("6.\tAdd new institution");
            Console.WriteLine("7.\t");
            Console.WriteLine("0.\tLogout.");
        }

        public void OtherMenu(Staff staff)
        {
            var exit = false;

            while (!exit)
            {
                Console.Clear();
                PrintOtherMenu();
                int op;
                if (int.TryParse(Console.ReadLine(), out op))
                {
                    switch (op)
                    {
                        case 1:
                            centreManager.Register();
                            HookScreen();
                        break;

                        case 2:
                            courseManager.RegisterCourse();
                            HookScreen();
                        break;

                        case 3:
                            staffManager.AddNewStaff(staff);
                            HookScreen();
                        break;

                        case 4:
                            Console.Write("Input student jambNumber: ");
                            string jambNumber = Console.ReadLine();
                            studentManager.PrintBiodata(jambNumber);
                            HookScreen();
                        break;
                        case 6:
                            var institution = new Institutions();
                            var address = new Address();
                            Console.Write("Input the institution name: ");
                            institution.InstitutionName = Console.ReadLine();
                            Console.Write("Input the institution city: ");
                            address.City = Console.ReadLine();
                            Console.Write("Input the institution state: ");
                            address.State = Console.ReadLine();
                            institutionsManager.AddInstitution(institution, address);
                            HookScreen();
                            break;



                        case 0:
                        exit = true;                        
                        break;

                    }
                }

            }
        }

        private void HookScreen()
        {
            Console.WriteLine("Press enter key to continue...");
            Console.ReadKey();
        }
    }
}

