using System;
using System.Collections.Generic;

#nullable disable

namespace BPayApi.Models
{
    public partial class WalletUser
    {
        public WalletUser()
        {
            Beneficiaries = new HashSet<Beneficiary>();
            CustomerAccountSchemas = new HashSet<CustomerAccountSchema>();
            CustomerProfiles = new HashSet<CustomerProfile>();
            UserDeviceInfos = new HashSet<UserDeviceInfo>();
            UserQas = new HashSet<UserQa>();
            WalletInfos = new HashSet<WalletInfo>();
            WalletTransfers = new HashSet<WalletTransfer>();
        }

        public string Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Username { get; set; }
        public byte[] Passwordhash { get; set; }
        public byte[] Passwordsalt { get; set; }
        public string Emailaddress { get; set; }
        public string Phonenumber { get; set; }
        public string Gender { get; set; }
        public DateTime? Dateofbirth { get; set; }
        public string Transactionpin { get; set; }
        public string Deviceimei { get; set; }
        public string Hardwareimei { get; set; }
        public string Deviceos { get; set; }
        public string Devicemake { get; set; }
        public string Devicemodel { get; set; }
        public string Ipaddress { get; set; }
        public string Referralcode { get; set; }
        public string Transpin { get; set; }

        public virtual ICollection<Beneficiary> Beneficiaries { get; set; }
        public virtual ICollection<CustomerAccountSchema> CustomerAccountSchemas { get; set; }
        public virtual ICollection<CustomerProfile> CustomerProfiles { get; set; }
        public virtual ICollection<UserDeviceInfo> UserDeviceInfos { get; set; }
        public virtual ICollection<UserQa> UserQas { get; set; }
        public virtual ICollection<WalletInfo> WalletInfos { get; set; }
        public virtual ICollection<WalletTransfer> WalletTransfers { get; set; }
    }
}
