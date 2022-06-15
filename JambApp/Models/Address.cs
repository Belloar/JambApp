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
        public Address()
        {

        }
        public Address(string city, string state)
        {
            City = city;
            State = state;
            
            
        }
    }
}
