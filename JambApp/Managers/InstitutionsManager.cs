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
    public class InstitutionsManager : IInstitutionsManager, IAddressManager
    {
        public int NoOfInstitutions = 3;
        public static Dictionary<int, Institutions> institutions = new();
        public static List<Institutions> pickedInstitutions = new();

        MySqlConnection connection = new MySqlConnection("Server=localhost;Database=JambAppDatabase;Uid=root;Pwd=@belloAR2001;");

        
        public void PrintInstitution(Institutions institution)
        {
            Console.WriteLine($"{NoOfInstitutions}, {institution.InstitutionName}, {institution.InstitutionAddress}");
        }
        public void AddNewInstitution()
        {
            NoOfInstitutions++;

            Console.Write("input the Institution name : ");
            string institutionName = Console.ReadLine();

            Console.Write("Input the institution address : ");
            Address institutionAddress;

            Console.Write("What state is this institution located : ");
            string institutionState = Console.ReadLine();

            Console.Write("What city is thid institution located");
            string institutionCity = Console.ReadLine();

            var institution = new Institutions(NoOfInstitutions, institutionName, institutionAddress);
            institutions.Add(NoOfInstitutions, institution);

        }
        public void StoreInstitution(int key)
        {
            foreach (var institution in institutions)
            {
                if (institution.Key == key)
                {
                    pickedInstitutions.Add(institution.Value);
                }
            }
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
                var result = commandString.ExecuteNonQuery();
                Console.WriteLine("{0} number of rows was affected", result);
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
        public void AddInstitution(Institutions institution, Address address)
        {
            string commandString1 = $"insert into institutions(institutionName,)values('{institution.InstitutionName}'),";
            string commandString2 = $"insert into address(city,state) values('{address.City}','{address.State}')";

            try
            {
                connection.Open();
                MySqlCommand command1 = new MySqlCommand(commandString1, connection);
                var reader = command1.ExecuteReader();
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
            try
            {
                connection.Open();
                MySqlCommand command2 = new MySqlCommand(commandString2, connection);
                var reader2 = command2.ExecuteReader();
                var result2 = command2.ExecuteNonQuery();
                Console.WriteLine("{0} number of row(s) affected in address", result2);
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
