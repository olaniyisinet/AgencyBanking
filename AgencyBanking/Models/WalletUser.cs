﻿using System;
using System.Collections.Generic;

#nullable disable

namespace AgencyBanking.Models
{
    public partial class WalletUser
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Transactionpin { get; set; }
        public string Deviceimei { get; set; }
        public string HardwareImei { get; set; }
        public string Deviceos { get; set; }
        public string Devicemake { get; set; }
        public string Devicemodel { get; set; }
        public string Ipaddress { get; set; }
        public string Referralcode { get; set; }
        public string CurrencyCode { get; set; }
    }
}
