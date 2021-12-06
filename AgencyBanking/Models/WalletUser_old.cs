using System;
using System.Collections.Generic;

namespace AgencyBanking.Models
{
    public partial class WalletUser_old
    {
        public string Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Username { get; set; }
        public byte[] Passwordhash { get; set; }
        public byte[] Passwordsalt { get; set; }
        public string Emailaddress { get; set; }
        public string Phonenumber { get; set; }
        public string Gender { get; set; }
        public DateOnly? Dateofbirth { get; set; }
        public string Transactionpin { get; set; }
        public string Deviceimei { get; set; }
        public string Hardwareimei { get; set; }
        public string Deviceos { get; set; }
        public string Devicemake { get; set; }
        public string Devicemodel { get; set; }
        public string Ipaddress { get; set; }
        public string Referralcode { get; set; }
        public string Transpin { get; set; }
    }
}
