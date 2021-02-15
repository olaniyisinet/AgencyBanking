using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgencyBanking.Models
{
    public class LoginModel
    {
        public string SMUsername { get; set; }
        public string SMPassword { get; set; }
        public int AppVersion { get; set; }
        public string LoginMethod { get; set; }
        public LogDetails LogDetails { get; set; }
    }

    public class LogDetails
    {
        public string DeviceOS { get; set; }
        public string DeviceIMEI { get; set; }
        public string HardwareIMEI { get; set; }
        public string IPAddress { get; set; }
    }
}
