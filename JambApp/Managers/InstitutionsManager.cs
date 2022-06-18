using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JambApp.Models;
using JambApp.Managers.Interfaces;


namespace JambApp.Managers
{
    public class InstitutionsManager : IInstitutionsManager
    {
        public int NoOfInstitutions = 3;
        public static Dictionary<int, Institutions> institutions = new();
        public static List<Institutions> pickedInstitutions = new();

        MySqlConnection connection = new MySqlConnection("Server=localhost;Database=JambAppDatabase;Uid=root;Pwd=@belloAR2001;");

        
        public void PrintInstitution(Institutions institution)
        {
            Console.WriteLine($"{NoOfInstitutions}, {institution.InstitutionName}, {institution.InstitutionAddress}");
        }
        
        

        public void DisplayInstitution()
        {
            if (institutions.Count == 0)
            {
                Console.WriteLine("no available Institutions");
            }
            else
            {
                foreach (var institution in institutions)
                {
                    Console.WriteLine($"{institution.Key},{institution.Value.InstitutionName}");
                }
            }
        }
        public List<Institutions> PickInstitution()
        {
            for (int i = 0; i < 4; i++)
            {
                if (institutions.Count == 0)
                {
                    Console.WriteLine("no available institutions");

                }
                else
                {
                    DisplayInstitution();
                    Console.Write("Input the number in front of the institution to choose it : ");
                    int n = int.Parse(Console.ReadLine());

                    while (pickedInstitutions.Contains(institutions[n]) && institutions.Count != null)
                    {
                        Console.Write("this institution has already been chosen\nchoose any other institution : ");
                        n = int.Parse(Console.ReadLine());
                    }
                    pickedInstitutions.Add(institutions[n]);
                }
            }
            return pickedInstitutions;
        }
        public void ListAllInstitutions()
        {
            MySqlCommand commandString = new MySqlCommand("select * from institutions inner join address", connection);

            try
            {
                connection.Open();
                var reader = commandString.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"InstitutionName: {reader["institutionName"]} \n {reader["address.town"]}\n {reader["address.city"]}");
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
        public void GetInstitutionByState(string state)
        {

            string commandString = $"select from institutions left join address where address.state = {state}";
            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(commandString, connection);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"\tInstitution Name: {reader["institutionName"]}\n\t institution City {reader["city"]}");
                }
                reader.Close();
                var result = command.ExecuteNonQuery();
                Console.WriteLine(result);
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
        public void AddInstitution(Institutions institution)
        {
            string commandString1 = $"insert into institutions(institutionName,institutuionAddress)values('{institution.InstitutionName}','{institution.InstitutionAddress}'),";
            

            try
            {
                connection.Open();
                MySqlCommand command1 = new MySqlCommand(commandString1, connection);
                var result = command1.ExecuteNonQuery();
                Console.WriteLine("{0} number of row(s) affected in institutions", result);
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
}
