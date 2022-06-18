using MySql.Data.MySqlClient;
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
        public static List<Staff> staffs;

        MySqlConnection connection = new MySqlConnection("Server=localhost;Database=JambAppDatabase;Uid=root;Pwd=@belloAR2001;");

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

                Console.Write("Confirm password: ");
                string password1 = Console.ReadLine();
                while(password != password1)
                {
                    Console.Write("passwords do not match, try again: ");
                    password1 = Console.ReadLine();


                }

               /* Console.Write("Enter your phone number: ");
                string phone = Console.ReadLine();*/

                Console.Write("Enter home address: ");
                string homeAddress = Console.ReadLine();

                Console.Write("Enter resident town");
                string town = Console.ReadLine();

                Console.Write("Enter resident city: ");
                string city = Console.ReadLine();

                Console.Write("Enter resident state: ");
                string state = Console.ReadLine();

               

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

                string commandString = $"insert into address(homeaddress, town , city , state) values('{homeAddress}','{town}','{city}','{state}');";

                string commandString1 = $"insert into staff(firstName,lastName,email,password,gender,nin,accountNumber,role,staffNumber,)";

                try
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(commandString, connection);
                    var result = command.ExecuteNonQuery();
                    Console.WriteLine("{0} rows affected",result);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    connection.Close();
                }

                try
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(commandString1, connection);
                    var result = command.ExecuteNonQuery();
                    Console.WriteLine("{0} rows affected", result);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    connection.Close();
                }


            }
        }
        private string StaffNoGenerator()
        {
            var random = new Random();
            return $"ST{random.Next(9999)}";
        }
        public Staff Login()
        {
            Staff staff = null;
            connection.Open();
            Console.Write("Enter your email: ");
            var email = Console.ReadLine();
            Console.Write("Enter your password: ");
            var password = Console.ReadLine();


            string commandString = $"select * from staff left join staffaddress on staff.id = staffid where email = '{email}' and password = '{password}';";
            try
            {
                MySqlCommand command = new MySqlCommand(commandString, connection);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int id = (int)reader["id"];
                    string firstName = (string)reader["firstName"];
                    string lastName = (string)reader["lastName"];
                    string eemail = (string)reader["email"];
                    string staffNumber = (string)reader["Staffnumber"];
                    string homeAddress = "wer";//(string)reader["homeaddress"];
                    string town = (string)reader["town"];
                    string nin = (string)reader["nin"];
                    string city = (string)reader["city"];
                    string state = (string)reader["state"];
                    string country = (string)reader["nationality"];
                    string accountNumber = (string)reader["accountNumber"];
                    StaffStatus status = (StaffStatus)reader["staffstatus"];//(StaffStatus)Enum.Parse(typeof (StaffStatus),(string)reader["status"]);
                    Gender gender = (Gender)reader["gender"];
                    Role role = (Role)reader["role"];
                    var address = new Address(homeAddress, town, city, state, country);
                    staff = new Staff(id, firstName, lastName, eemail, password, gender, address, nin, role, staffNumber, status, accountNumber);
                }
                reader.Close();
                return staff;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return staff;
            }
            finally
            {
                connection.Close();
            }
            //return staff;

        }
    }
}
