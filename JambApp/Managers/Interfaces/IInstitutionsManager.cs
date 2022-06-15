using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JambApp.Models;

namespace JambApp.Managers.Interfaces
{
    public interface IInstitutionsManager
    {
        public void AddInstitution(Institutions institution, Address address);
    }
}
