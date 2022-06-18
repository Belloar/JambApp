using MySql.Data.MySqlClient;
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
        //InstitutionsManager institutionsManager = new();

        MySqlConnection connection = new MySqlConnection("Server=localhost;Database=JambAppDatabase;Uid=root;Pwd=@belloAR2001;");
        public List<Student> students;
        public const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        
        public void RegisterStudent(Student student)
        {
            connection.Open();
            

            string commandString = $"insert into students(firstName,lastName,email,password,gender,nin,jambNumber,role)values('{student.FirstName}','{student.LastName}','{student.Email}','{student.Password}','{student.Gender}','{student.Nin}','{student.JambNumber}','{student.Role}');";

            try
            {
                MySqlCommand command = new MySqlCommand(commandString ,connection);
                var result = command.ExecuteNonQuery();
                Console.WriteLine("{0} rows affected ",result);
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

        public void Print(Student student)
        {
            Console.WriteLine($"{student.LastName}{student.FirstName}\n\t {student.Email}\n\t{student.Gender}\n\t{student.Address.HomeAddress}/ {student.Address.Town}/{student.Address.State}/{student.Address.Country}\n\t{student.Nin}\n{student.JambNumber}");
        }

        public void GetAllStudents()
        {
            string commandString = "select * from students;";

            try
            {

                Student student = null;
                connection.Open();
                MySqlCommand command = new MySqlCommand(commandString, connection);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    student.FirstName = (string)reader["firstName"];
                    student.LastName = (string)reader["Lastname"];
                    student.Email = (string)reader["email"];
                    student.JambNumber = (string)reader["jambnumber"];
                    student.Gender = (Gender)reader["gender"];
                    student.Id = (int)reader["id"];

                    Console.WriteLine(student.FirstName);
                    Console.WriteLine(student.LastName);
                    Console.WriteLine(student.Email);
                    Console.WriteLine(student.JambNumber);
                    Console.WriteLine(student.Gender);
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            //Console.WriteLine(reader.ToString()); ASK ALFA REGARDING THIS LINE

        }
        public Student GetStudentByJnum(string jambNumber)
        {
            Student student = null;
            string commandString = $"select * from students where students.jambNumber = {jambNumber} inner join address on addressid = address.id";
            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(commandString, connection);
                var reader = command.ExecuteReader();

                string firstName = (string)reader["firstName"];
                string lastName = (string)reader["lastName"];
                string email = (string)reader["email"];
                string jjambNumber = (string)reader["jambNumber"];
                string homeAddress = (string)reader["homeaddress"];
                string town = (string)reader["homeAddress"];
                string nin = (string)reader["nin"];
                string city = (string)reader["city"];
                string state = (string)reader["state"];
                string country = (string)reader["country"];
                Gender gender = (Gender)reader["gender"];

                var address = new Address(homeAddress, town, city, state, country);
                student = new Student(firstName, lastName, email, gender, address, nin, jjambNumber);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return student;
        }
        public Student GetStudentByEmail(string email)
        {
            string commandString = $"select * from students left join address on student.addressid = address.id where students.email = {email}";
            Student student = null;
            try
            {

                connection.Open();
                MySqlCommand command = new MySqlCommand(commandString, connection);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    student.FirstName = (string)reader["firstName"];
                    student.LastName = (string)reader["lastname"];
                    student.Email = (string)reader["email"];
                    student.Gender = (Gender)reader["gender"];
                    student.Role = (Role)reader["role"];
                    student.Date = DateTime.Parse((string)reader["datee"]);
                    student.Address.HomeAddress = (string)reader["homeAddress"];
                    student.Address.City = (string)reader["city"];
                    student.Address.State = (string)reader["state"];
                    student.Address.ZipCode = (int)reader["zipcode"];
                    student.Address.Country = (string)reader["country"];
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return student;



        }
        public void GetStudent(string email)
        {
            string commandString = $"select * from students left join address on student.addressid = address.id where students.email = {email}";
            Student student = null;
            try
            {

                connection.Open();
                MySqlCommand command = new MySqlCommand(commandString, connection);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    student.FirstName = (string)reader["firstName"];
                    student.LastName = (string)reader["lastname"];
                    student.Email = (string)reader["email"];
                    student.Gender = (Gender)reader["gender"];
                    student.Role = (Role)reader["role"];
                    student.Date = DateTime.Parse((string)reader["datee"]);
                    student.Address.HomeAddress = (string)reader["homeAddress"];
                    student.Address.City = (string)reader["city"];
                    student.Address.State = (string)reader["state"];
                    student.Address.ZipCode = (int)reader["zipcode"];
                    student.Address.Country = (string)reader["country"];
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            Print(student);

        }
        public string JambNumberGenerator()
        {
            StringBuilder stringBuilder = new();
            Random random = new();

            string jambNumber = string.Empty;
            string letters = string.Empty;
            for (int i = 0; i < 2; i++)
            {
                letters = stringBuilder.Append(chars[random.Next(chars.Length)]).ToString();
                jambNumber = $"{random.Next(1000, 9999)}{random.Next(1000, 9999)}{letters}";
            }
            return jambNumber;

        }
        public Student Login()
        {
            connection.Open();
            Console.Write("Enter your email: ");
            var email = Console.ReadLine();
            Console.Write("Enter your password: ");
            var password = Console.ReadLine();

            Student student = null;

            string commandString = $"select * from students inner join address on students.id = studentid where email = '{email}' and password = '{password}'";
            try
            {
                MySqlCommand command = new MySqlCommand(commandString, connection);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string firstName = (string)reader["firstName"];
                    string lastName = (string)reader["lastName"];
                    string eemail = (string)reader["email"];
                    string jjambNumber = (string)reader["jambNumber"];
                    string homeAddress = "wer";//(string)reader["homeaddress"];
                    string town =(string)reader["town"];
                    string nin = (string)reader["nin"];
                    string city = (string)reader["city"];
                    string state = (string)reader["state"];
                    string country = (string)reader["nationality"];
                    Gender gender = (Gender)reader["gender"];
                    var address = new Address(homeAddress, town, city, state, country);
                    student = new Student(firstName, lastName, eemail, gender, address, nin, jjambNumber);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            
            return student;
           

        }

        public void PrintBiodata(string jambNumber)
        {
            string connectionString = $"select * from student where jambNumber = {jambNumber}";
            Console.WriteLine(connectionString);
        }
       
    }
}
