using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JambApp.Models
{
    public class Centre
    {
        public int CentreId { get; set; }
        public string CentreName { get; set; }
        public int CentreCapacity { get; set; }
        public int Quota { get; set; }
        public string CentreLocation { get; set; }
        public string CentreState { get; set; }
        public string AccountNumber { get; set; }
        public int CurrentQuota { get; set; }
        public Centre(int centreId, string centreName, int centreCapacity, int quota, string centreLocation, string centreState, string accountNumber, int currentQuota)
        {
            CentreId = centreId;
            CentreName = centreName;
            CentreCapacity = centreCapacity;
            Quota = quota;
            CentreLocation = centreLocation;
            CentreState = centreState;
            AccountNumber = accountNumber;
            CurrentQuota = currentQuota;
        }
    }
}
