using System;
using System.Collections.Generic;
using System.Text;
using JambApp.Managers;
using JambApp.Models;

namespace JambApp.Managers.Interfaces
{
    public interface ICentreManager
    {
        public void Register();
        public void GetCentreByState(string centreState);
        public void GetAllCentre();
        public Centre GenerateExamCentre(string studentState);


    }
}
