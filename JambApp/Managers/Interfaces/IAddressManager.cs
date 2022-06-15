using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JambApp.Models;

namespace JambApp.Managers.Interfaces
{
    public interface IAddressManager
    {
        public void SaveAddress(Address address)
       
    }
}
