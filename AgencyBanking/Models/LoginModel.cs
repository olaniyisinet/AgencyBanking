using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgencyBanking.Models
{
    public class LoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public int appversion { get; set; }
        public string LoginMethod { get; set; }
        public LogDetails logDetails { get; set; }
    }

    public class LogDetails
    {
        public string DeviceOS { get; set; }
        public string DeviceIMEI { get; set; }
        public string HardwareIMEI { get; set; }
        public string IPAddress { get; set; }
    }
}
