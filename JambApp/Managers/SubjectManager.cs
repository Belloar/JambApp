using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JambApp.Models;
using MySql.Data.MySqlClient;

namespace JambApp.Managers
{
    public class SubjectManager
    {
        MySqlConnection connection = new MySqlConnection("Server=localhost;Database=JambAppDatabase;Uid=root;Pwd=@belloAR2001;");

        public void CollectSubject(string studentEmail)
        {
            connection.Open();
            Dictionary<string, string> subjects = new Dictionary<string, string>();
            
            Console.WriteLine("Input the number of exam sittings you want to use,max sitting is 2");
            int NoOfSittings; 
            while(!int.TryParse(Console.ReadLine(), out NoOfSittings) || !(NoOfSittings > 0 && NoOfSittings <= 2))
            {
                Console.WriteLine("Invalid number of sittings please enter 1 or 2");
            }
            int n = 1;
            do
            {
                
                
                Console.Write($"enter your exam number for sitting {n} : ");
                string examNumber = Console.ReadLine(); n++;

                Console.WriteLine("Input your Grade for Mathematics : ");
                subjects.Add("Mathematics", Console.ReadLine());

                Console.WriteLine("input your grade for English : ");
                subjects.Add("english", $"{Console.ReadLine()}");

                string subject = string.Empty ;
                string grade = string.Empty ;
                for (int i = 1; i <= 7; i++)
                {
                    Console.Write("Input the next subject: ");
                    subject = Console.ReadLine();
                    Console.Write($"Input the next Grade for {subject}: ");
                    grade = Console.ReadLine();

                    if(subjects.ContainsKey(subject))
                    {
                        Console.WriteLine("you have added this subject before");i--;
                    }
                    else
                    {
                        subjects.Add(subject, grade);
                    }

                }
                
                foreach (KeyValuePair<string,string>studentSubjects in subjects)
                {
                    try
                    {
                        subject = studentSubjects.Key;
                        grade = studentSubjects.Value;
                        string commandString = $"insert into studentSubjects(subject,grade,studentemail)values('{subject}','{grade}','{studentEmail}');";
                        MySqlCommand command = new MySqlCommand(commandString, connection);
                        var result = command.ExecuteNonQuery();
                        Console.WriteLine("{0} row(s) affected ", result);
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
                NoOfSittings--;
            } while(NoOfSittings > 0);
            
        }

    }
}

        
