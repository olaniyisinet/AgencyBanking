using System;
using System.Collections.Generic;

#nullable disable

namespace BPayApi.Models
{
    public partial class UserDeviceInfo
    {
        public Guid DeviceId { get; set; }
        public string UserId { get; set; }
        public string Imei { get; set; }
        public string Osversion { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Ipaddress { get; set; }
        public bool? IsCurrent { get; set; }
        public string HardwareImei { get; set; }
        public DateTime? DateCreated { get; set; }

        public virtual WalletUser User { get; set; }
    }
}
