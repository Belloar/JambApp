using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using JambApp.Models;

namespace JambApp.Repositories
{
    public class InstitutionRepository
    {

        MySqlConnection connection = new MySqlConnection("Server=localhost;Database=JambAppDatabase;Uid=root;Pwd=@belloAR2001;");
        public  void ListAllInstitutions()
        {  
            MySqlCommand commandString = new MySqlCommand("select * from institutions inner join address",connection);

            try
            {
                connection.Open();
                var reader = commandString.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"InstitutionName: {reader["institutionName"]} \n {reader["address.town"]}\n {reader["address.city"]}");
                }
                var result = commandString.ExecuteNonQuery();
                Console.WriteLine("{0} number of rows was affected",result);
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
        public  void GetInstitutionByState(string state)
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
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
           
        }
        public  void AddInstitution(Institutions institution,Address address)
        {
            string commandString1 = $"insert into institutions(institutionName,)values('{institution.InstitutionName}')," ;
            string commandString2 = $"insert into address(city,state) values('{address.City}','{address.State}')";
            
           try
           {
                connection.Open();
                MySqlCommand command1 = new MySqlCommand(commandString1, connection);
                var reader = command1.ExecuteReader();
                var result = command1.ExecuteNonQuery();
                Console.WriteLine("{0} number of row(s) affected in institutions", result);
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
