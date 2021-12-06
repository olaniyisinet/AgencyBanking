using System;
using System.Collections.Generic;

namespace AgencyBanking.Models
{
    public partial class Userdeviceinfo
    {
        public string Deviceid { get; set; }
        public string Userid { get; set; }
        public string Imei { get; set; }
        public string Osversion { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Ipaddress { get; set; }
        public bool? Iscurrent { get; set; }
        public DateTime? Datecreated { get; set; }
        public string Hardwareimei { get; set; }

        public virtual Walletuser User { get; set; }
    }
}
