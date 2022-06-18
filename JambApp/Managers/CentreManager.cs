using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using JambApp.Models;
using JambApp.Managers.Interfaces;

namespace JambApp.Managers
{
    public class CentreManager : ICentreManager
    {       
        public static int numberOfCentres = 6;
        public static List<Centre> centres;

        MySqlConnection connection = new MySqlConnection("Server=localhost;Database=JambAppDatabase;Uid=root;Pwd=@belloAR2001;");

        public  void Register()
        {
            connection.Open();
            Console.Write("Input the centre name : ");
            string centreName = Console.ReadLine();

            Console.Write("Input the centre capacity : ");
            int centreCapacity;
            while(!int.TryParse(Console.ReadLine(),out centreCapacity))
            {
                Console.WriteLine("Invalid input\ninput an integer value");
            }

            Console.WriteLine("Input the town the centre is located in");
            string centreTown = Console.ReadLine();

            Console.Write("Input the city the centre is located: ");
            string centreCity = Console.ReadLine();

            Console.Write("Input the State centre is located : ");
            string centreState = Console.ReadLine();

            Console.Write("Input the account number to be used for payment : ");
            string accountNumber = Console.ReadLine();
            while(accountNumber.Count() > 8)
            {
                Console.WriteLine("character limit exceeded try again");
                accountNumber = Console.ReadLine();
            }

            int quota = centreCapacity * 21;

            string commandString = $"Insert into centre(centreName,centreCapacity,accountnumber,quota)values('{centreName}','{centreCapacity}','{accountNumber}','{quota}');";

            try
            {
                string commandString2 = $"insert into address(town,city,state)values('{centreTown}','{centreCity}','{centreState}')";
                
                MySqlCommand command2 = new MySqlCommand(commandString2,connection);
                var result = command2.ExecuteNonQuery();

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
                MySqlCommand command = new MySqlCommand(commandString,connection);
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

        }
        public  void PrintCentre(Centre centre)
        {
           Console.WriteLine($"{centre.CentreName}\t{centre.CentreAddress.City}\t{centre.CentreAddress.State}");
        }
        public  void GetAllCentre()
        {
            Centre centre = null;
            string commandString = $"select * from centre left join address on centreAddress = centre.id";
            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(commandString, connection);
                var reader = command.ExecuteReader();
                while(reader.Read())
                {
                    string centreName = (string)reader["centreName"];
                    int centreCapacity = (int)reader["centreCapacity"];
                    string town = (string)reader["state"];
                    string city = (string)reader["city"];
                    string state = (string)reader["state"];

                    Console.WriteLine($"Centre Name: {centreName}");
                    Console.WriteLine($"Centre Capacity: {centreCapacity }");
                    Console.WriteLine($"Town: {town}");
                    Console.WriteLine($"City: {city}");
                    Console.WriteLine($"State: {state}");
                }
                
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        public  List<Centre> GetCentreByState(string centreState)
        {
            List<Centre> centreList = new();
            string commandString = $"select * from centre left join address on centreAddress = address.id where address.state = '{centreState}'";
            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(commandString, connection);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string centreName = (string)reader["centreName"];
                    int centreCapacity = (int)reader["centreCapacity"];
                    int quota = (int)reader["quota"];
                    string town = (string)reader["state"];
                    string city = (string)reader["city"];
                    string state = (string)reader["state"];
                    string acctNumber = (string)reader["accountNumber"];

                    var address = new Address(town, city, state);
                    var centre = new Centre(centreName, centreCapacity, quota, address, acctNumber);
                    centreList.Add(centre);
                   
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
            return centreList;
        }

    
        public void GetCentre(string centreName)
        {
            Centre centre = null;
            string commandString = $"select * from centre left join address on centreAddress = centre.id where centrename = '{centreName}'";
            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(commandString, connection);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string CentreName = (string)reader["centreName"];
                    int centreCapacity = (int)reader["centreCapacity"];
                    string town = (string)reader["state"];
                    string city = (string)reader["city"];
                    string state = (string)reader["state"];

                    Console.WriteLine($"Centre Name: {centreName}");
                    Console.WriteLine($"Centre Capacity: {centreCapacity}");
                    Console.WriteLine($"Town: {town}");
                    Console.WriteLine($"City: {city}");
                    Console.WriteLine($"State: {state}");
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
        }
        public  Centre GenerateExamCentre(string studentState)
        {
            
            foreach(var centre in centres)
            {            
                if (centre.CentreAddress.State  == studentState && centre.CurrentQuota < centre.Quota)
                {
                    centre.CurrentQuota++;
                    return centre;
                }             
            }
            foreach(var centre in centres)
            {
                if(centre.CurrentQuota < centre.Quota)
                {
                    var random = new Random();
                    Console.WriteLine("there are no more centres available in your state");
                    return centres[random.Next(centres.Count)];
                }
              

            }

            return null;
        }
       
        
    }
}
