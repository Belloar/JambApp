using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JambApp.enums;
using JambApp.Managers;

namespace JambApp.Models
{
    public class Student : Person 
    {
      public string JambNumber { get; set; }
        public Centre ExamCentre { get; set; }
        public DateTime Date { get; set; }
        public int ExamScore { get; set; }
        
       
        public Dictionary<string,Dictionary<string,string>> StudentSubjects { get; set; } = new Dictionary<string,Dictionary<string,string>>();
        public List<Institutions> StudentInstitutions { get; set; } = new List<Institutions>();
       
        
        
        public Student(int id, string firstName, string lastName, string email, string password, Gender gender, Address address, string nin, Role role, string jambNumber, Centre examCentre , DateTime date, int examScore, Dictionary<string, Dictionary<string, string>> studentSubjects,List<Institutions>studentInstitutions) : base
            (id, firstName, lastName, email, password, gender, address, nin, role)
        {
            JambNumber = jambNumber;
            ExamCentre = examCentre;
            Date = date;
            ExamScore = examScore;
            StudentSubjects = studentSubjects;
            StudentInstitutions = studentInstitutions;
            
        }
        public Student(string firstName,string lastName,string email, Gender gender,Address address,string nin,string jambNumber):base(firstName,lastName, email, gender, address, nin)
        {
            
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Gender = gender;
            Address = address;
            Nin = nin;
            JambNumber =jambNumber;

        }
       
        



    }
}
