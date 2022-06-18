using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JambApp.Models
{
    public class Address
    {
        public string HomeAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }
        public string Country { get; set; }
        public string Town { get; set; }
        public Address(string homeAddress, string city, string state, int zipCode, string country, string town)
        {
            HomeAddress = homeAddress;
            City = city;
            State = state;
            ZipCode = zipCode;
            Country = country;
            Town = town;
        }
        public Address(string town, string city, string state,string country)
        {
            Town = town;
            City = city;
            State = state;
            Country = country;
        }
        public Address(string town ,string city, string state)
        {
            Town = town;   
            City = city;
            State = state;
            
            
        }
        public Address(string homeAddress, string town, string city, string state, string country)
        {
            HomeAddress = homeAddress;
            City = city;
            State = state;
            Country = country;
            Town = town;
        }
    }
}
