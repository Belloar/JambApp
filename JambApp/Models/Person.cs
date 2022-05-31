using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JambApp.enums;

namespace JambApp.Models;

public abstract class Person
{
    public int Id { get; set; }
    public string FirstName { get; set; }    
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public Gender Gender { get; set; }
    public string Address { get; set; }
    public string Nin { get; set; }
    public Role Role { get; set; }

    public Person(int id, string firstName, string lastName, string email, string password , Gender gender, string address, string nin, Role role)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
        Gender = gender;
        Address = address;
        Nin = nin;
        Role = role;
    }

}
