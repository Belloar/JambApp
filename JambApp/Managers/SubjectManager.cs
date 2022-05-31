using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JambApp.Models;

namespace JambApp.Managers
{
    public class SubjectManager
    {
        
        public  Dictionary<string,Dictionary<string,string>> CollectSubject()
        {
            Dictionary<string, Dictionary<string, string>> studentSubject = new();
            Console.WriteLine("Input the number of exam sittings you want to use,max sitting is 2");
            int NoOfSittings; 
            while(!int.TryParse(Console.ReadLine(), out NoOfSittings) || !(NoOfSittings > 0 && NoOfSittings <= 2))
            {
                Console.WriteLine("Invalid number of sittings please enter 1 or 2");
            }
            int n = 1;
            do
            {
                
                Dictionary<string, string> subjects = new Dictionary<string, string>();
                Console.Write($"enter your exam number for sitting {n} : ");
                string examNumber = Console.ReadLine(); n++;

                Console.WriteLine("Input your Grade for Mathematics : ");
                subjects.Add("Mathematics", Console.ReadLine());

                Console.WriteLine("input your grade for English : ");
                subjects.Add("english", $"{Console.ReadLine()}");

                for (int i = 1; i <= 7; i++)
                {
                    Console.Write("Input the next subject: ");
                    var subject = Console.ReadLine();
                    Console.Write($"Input the next Grade for {subject}: ");
                    var grade = Console.ReadLine();

                    if(subjects.ContainsKey(subject))
                    {
                        Console.WriteLine("you have added this subject before");i--;
                    }
                    else
                    {
                        subjects.Add(subject, grade);
                    }

                }
                studentSubject.Add(examNumber, subjects);
                NoOfSittings--;

            } while(NoOfSittings > 0);

           
            return studentSubject;

        }

    }
}

        
