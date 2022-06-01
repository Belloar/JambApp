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
        
        

        public CentreManager()
        {
            centres = new()
            {
                new Centre(1,"zaFirstCentre",100,1680,"warri","rivers","5955",0),
                new Centre(2,"zaSecondCentre",80,1680,"ilorin","kwara","5955",0),
                new Centre(3,"zaThirdCentre",150,3150,"abeokuta","ogun","5955",0),
                new Centre(4,"zaFourthCentre",50,1050,"lagos MainLand","Lagos","5955",0),
                new Centre(5,"zaFifthCentre",10,210,"lagos island","Lagos","5955",0),
                new Centre(6,"zaFourthCentre",50,1050,"ikorodu","Lagos","5955",0)
            };
        }
        public  void Register()
        {
            numberOfCentres++;
            Console.Write("Input the centre name : ");
            string centreName = Console.ReadLine();

            Console.Write("Input the centre capacity : ");
            int centreCapacity;
            while(!int.TryParse(Console.ReadLine(),out centreCapacity))
            {
                Console.WriteLine("Invalid input\ninput an integer value");
            }
            Console.Write("Input the location of the centre : ");
            string centreLocation = Console.ReadLine();

            Console.Write("Input the State centre is located : ");
            string centreState = Console.ReadLine();

            Console.Write("Input the account number to be used for payment : ");
            string accountNumber = Console.ReadLine();

            int quota = centreCapacity * 21;
            int currentQuota = 0;
            

            var centre = new Centre(numberOfCentres ,centreName ,centreCapacity ,quota ,centreLocation ,centreState ,accountNumber,currentQuota);
            centres.Add(centre);
            Console.WriteLine("You have successfully registered your centre to partake in jamb");

        }
        public  void PrintCentre(Centre centre)
        {
           Console.WriteLine($"{centre.CentreName}\t{centre.CentreLocation}\t{centre.CentreState}");
        }
        public  void GetAllCentre()
        { int count = 0;
            foreach(var centre in centres)
            {
                PrintCentre(centre);
                count++;
            }
            if(count == 0)
            {
                Console.WriteLine("No centres have been registered");
            }

        }
        public  void GetCentreByState(string centreState)
        {
           foreach(var centre in centres)
            {
                if(centre.CentreState == centreState)
                {
                    PrintCentre(centre);
                }
            }
        }
        public  Centre GenerateExamCentre(string studentState)
        {
            
            foreach(var centre in centres)
            {            
                if (centre.CentreState == studentState && centre.CurrentQuota < centre.Quota)
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
