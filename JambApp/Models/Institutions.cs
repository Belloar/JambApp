using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using JambApp.Managers;

namespace JambApp.Models
{
    public class Institutions
    {
        public int Id { get; set; }
        public string InstitutionName { get; set; }
        public string InstitutionAddress { get; set; }
        
        public Course CourseToOffer { get; set; }

        
        public Institutions(int id, string institutionName, string institutionAddress)
        {
            Id = id;
            InstitutionName = institutionName;
            InstitutionAddress = institutionAddress;
            
            
        }
        public Institutions()
        {

        }
        public Institutions(int id, string institutionName, string institutionAddress, Course courseToOffer)
        {
            Id = id;
            InstitutionName = institutionName;
            InstitutionAddress = institutionAddress;
            CourseToOffer = courseToOffer;
        }
    }
}
