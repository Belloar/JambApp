using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JambApp.enums;

namespace JambApp.Models;

public class Staff:Person 
{
    public int AccountNumber { get; set; }
    public string StaffNumber { get; set; }
    public StaffStatus  Status { get; set; }
    
    
    public Staff(int id, string firstName, string lastName, string email, string password, Gender gender, string address, string nin, Role role, string staffNumber, StaffStatus status, int accountNumber) :
        base(id, firstName, lastName, email, password, gender, address, nin, role)
    {
        StaffNumber = staffNumber;
        Status = status;
        AccountNumber = accountNumber;

    }

}
