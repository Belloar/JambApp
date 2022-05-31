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
        public string InstitutionState { get; set; }
        public string InstitutionCity { get; set; }
        public Course CourseToOffer { get; set; }

        
        public Institutions(int id, string institutionName, string institutionAddress, string institutionState, string institutionCity)
        {
            Id = id;
            InstitutionName = institutionName;
            InstitutionAddress = institutionAddress;
            InstitutionState = institutionState;
            InstitutionCity = institutionCity;
            
        }
        public Institutions()
        {
            Institutions inst1 = new Institutions(1, "FUTA", "somewhere in akure", "ondo", "akure");
            Institutions inst2 = new Institutions(2, "OOU", "somewhere in ago-iwoye", "ogun", "ago-iwoye");
            Institutions inst3 = new Institutions(3, "FUTO", "somewhere in owerri", "imo", "owerri");
            

        }
    }
}
