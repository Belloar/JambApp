using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JambApp.Menus
{
    internal class MainMenu
    {
        
        StaffMenu staffMenu = new StaffMenu();
        StudentMenu StudentMenu = new StudentMenu();


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
                            staffMenu.Menu();
                            break;
                        case 2:
                            StudentMenu.Menu();
                            break;
                        case 0:
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Invalid inpute...\nPress any key to try again...");
                            Console.ReadKey();
                            break;
                    }
                }

            }
        }

        private void PrintMenu()
        {
            Console.WriteLine("======oooooooooooooooooooo========");
            Console.WriteLine("<<<<<< Welcome to JambApp >>>>>>>>");
            Console.WriteLine("======oooooooooooooooooooo========");
            Console.WriteLine();
            Console.WriteLine("1.\tStaff Menu.");
            Console.WriteLine("2.\tStudent Menu.");
            Console.WriteLine("0.\tExit.");
        }
    }
}

    

