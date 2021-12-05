using System;
using System.Collections.Generic;

#nullable disable

namespace AgencyBanking.sakila
{
    public partial class Userdeviceinfo
    {
        public string DeviceId { get; set; }
        public string UserId { get; set; }
        public string Imei { get; set; }
        public string Osversion { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Ipaddress { get; set; }
        public byte? IsCurrent { get; set; }
        public string HardwareImei { get; set; }

        public virtual Walletuser User { get; set; }
    }
}
