using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JambApp.Models;
using JambApp.enums;
using JambApp.Managers.Interfaces;

namespace JambApp.Managers
{
    public class StaffManager : IStaffManager
    {
        ICourseManager courseManager = new CourseManager();
        IStudentManager studentManager = new StudentManager();
        ICentreManager centreManager = new CentreManager();

        int NoOfStaffs = 8;
        public static List<Staff> staffs;


        public StaffManager()
        {
            staffs = new()
            {
                new Staff(1,"Brother","Muftau","Murphy@Gmail.com","0000",Gender.Male,"abeokuta","5955",Role.invigilator,StaffNoGenerator(), StaffStatus.Standby,00000000000),
                new Staff(2,"alfa","Mahmud","mahmud@Gmail.com","0000",Gender.Male,"abeokuta","5955",Role.inspector,StaffNoGenerator(), StaffStatus.Standby,00000000000),
                new Staff(3,"alfa","Qayum","qayum@Gmail.com","0000",Gender.Male,"abeokuta","5955",Role.invigilator,StaffNoGenerator(), StaffStatus.Standby,00000000000),
                new Staff(4,"Alfa","Awwal","awwal@Gmail.com","0000",Gender.Male,"abeokuta","5955",Role.inspector,StaffNoGenerator(), StaffStatus.Standby,00000000000),
                new Staff(5,"H.O.C","Shefik","shefik@Gmail.com","0000",Gender.Male,"abeokuta","5955",Role.invigilator,StaffNoGenerator(), StaffStatus.Standby,00000000000),
                new Staff(6,"alfa","waris","waris@Gmail.com","0000",Gender.Male,"abeokuta","5955",Role.Staff,StaffNoGenerator(), StaffStatus.Standby,00000000000),
                new Staff(7,"SenDev","Taofeek","tao@Gmail.com","0000",Gender.Male,"abeokuta","5955",Role.admin,StaffNoGenerator(), StaffStatus.Standby,00000000000),
                new Staff(8,"Mr","Yusuf","mr_yusuf@Gmail.com","0000",Gender.Male,"abeokuta","5955",Role.admin,StaffNoGenerator(), StaffStatus.Standby,00000000000)
            };
        }
        public void AddNewStaff(Staff staff)
        {
            if (staff.Role != Role.admin)
            {
                Console.WriteLine("Sorry, only Manager can add a new staff.");
            }
            else
            {
                Console.Write("Enter your first name: ");
                string firstName = Console.ReadLine();
                Console.Write("Enter your last name: ");
                string lastName = Console.ReadLine();
                Console.Write("Enter your email: ");
                string email = Console.ReadLine();
                Console.Write("Enter your password: ");
                string password = Console.ReadLine();
                Console.Write("Enter your phone number: ");
                string phone = Console.ReadLine();
                Console.Write("Enter your address: ");
                string address = Console.ReadLine();
                Console.Write("Enter your gender\n1 for Male\n2 for Female\n3 for others: ");
                int gender;
                while (!int.TryParse(Console.ReadLine(), out gender) && (gender > 0 && gender < 4))
                {
                    Console.Write("Invalid option, please enter 1, 2 or 3: ");
                }

                Console.Write("Input your National Identity Number");
                string nin = Console.ReadLine();

                Console.Write("Input the account number to be used for payment");
                int accountNumber = int.Parse(Console.ReadLine());

                StaffStatus status = StaffStatus.Standby;
                Role role = Role.Staff;
                string staffNumber = StaffNoGenerator();
                
                NoOfStaffs++;

                var newStaff = new Staff(NoOfStaffs, firstName, lastName, email, password, (Gender)gender, address, nin, (Role)role, staffNumber, status, accountNumber) ;

                staffs.Add(newStaff);
                Console.WriteLine($"You have successfully added a new staff with staff number {newStaff.StaffNumber}.");
            }
        }
        public string StaffNoGenerator()
        {
            var random = new Random();
            return $"ST{random.Next(9999)}";
        }
        public Staff Login()
        {
            Console.Write("Enter your email: ");
            var email = Console.ReadLine();
            Console.Write("Enter your password: ");
            var password = Console.ReadLine();

            foreach (var staff in staffs)
            {
                if (staff.Email == email && staff.Password == password)
                {
                    return staff;
                }
            }
            return null;
        }
    }
}
