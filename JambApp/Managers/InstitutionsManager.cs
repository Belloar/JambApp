using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JambApp.Models;
using JambApp.Managers.Interfaces;


namespace JambApp.Managers
{
    public class InstitutionsManager :IInstitutionsManager
    {
        public  int NoOfInstitutions = 3;
        public static Dictionary<int, Institutions> institutions = new();
        public static List<Institutions> pickedInstitutions = new();

        public InstitutionsManager()
        {
            var inst1 = new Institutions(1, "OOU", "somewhere in ago-iwoye", "ogun", "ago-iwoye");
            var inst2 = new Institutions(2, "FUTA", "somewhere in akure", "ondo", "akure");
            var inst3 = new Institutions(3, "FUT minna", "somewhere in minna", "Niger", "minna");
            var inst4 = new Institutions(3, "CLH", "obantoko", "ogun", "abeokuta");
            var inst5 = new Institutions(3, "Sysbeams ", "Also obantoko", "still ogun", "abeokuta");

            institutions.Add(1, inst1);
            institutions.Add(2, inst2);
            institutions.Add(3, inst3);
            institutions.Add(4, inst4);
            institutions.Add(5, inst5);
        }


        public  void GetInstitutions()
        {
            foreach(var institution in institutions)
            {
                PrintInstitution(institution.Value);
            }
        }
        public  void PrintInstitution(Institutions institution)
        {
            Console.WriteLine($"{NoOfInstitutions}, {institution.InstitutionName}, {institution.InstitutionState}, {institution.InstitutionAddress}");
        }
        public  void AddNewInstitution()
        {
            NoOfInstitutions ++;
            Console.Write("Input the institution id : ");
            string institutionId = Console.ReadLine();

            Console.Write("input the Institution name : ");
            string institutionName = Console.ReadLine();

            Console.Write("Input the institution address : ");
            string institutionAddress = Console.ReadLine();

            Console.Write("What state is this institution located : ");
            string institutionState = Console.ReadLine();

            Console.Write("What city is thid institution located");
            string institutionCity = Console.ReadLine();

            var institution = new Institutions(NoOfInstitutions ,institutionName,institutionAddress,institutionState,institutionCity);
            institutions.Add(NoOfInstitutions,institution);

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
            if(institutions.Count == 0)
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



    }
}
