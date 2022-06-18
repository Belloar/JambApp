using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace JambApp.Models
{
    public class Centre
    {
        public int CentreId { get; set; }
        public string CentreName { get; set; }
        public int CentreCapacity { get; set; }
        public int Quota { get; set; }
        public Address CentreAddress { get; set; }
        public string AccountNumber { get; set; }
        public int CurrentQuota { get; set; }
        public Centre(int centreId, string centreName, int centreCapacity, int quota,Address centreAddress, string accountNumber, int currentQuota)
        {
            CentreId = centreId;
            CentreName = centreName;
            CentreCapacity = centreCapacity;
            Quota = quota;
            CentreAddress = centreAddress;
            AccountNumber = accountNumber;
            CurrentQuota = currentQuota;
        }
        public Centre(string centreName, int centreCapacity, int quota, Address centreAddress, string accountNumber)
        {
            CentreName = centreName;
            CentreCapacity = centreCapacity;
            Quota = quota;
            CentreAddress = centreAddress;
            AccountNumber = accountNumber;
        }
    }
}
