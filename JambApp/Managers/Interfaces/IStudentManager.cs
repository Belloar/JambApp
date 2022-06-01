using System;
using System.Collections.Generic;
using System.Text;
using JambApp.Models;

namespace JambApp.Managers.Interfaces
{
    public interface IStudentManager
    {
        public void Register();
        public string JambNoGenerator();
        public  string FullName(Student student);
        public void PrintBiodata(string jambNumber);
        public Student Login();


    }
}
