using System;
using System.Collections.Generic;

#nullable disable

namespace AgencyBanking.sakila
{
    public partial class Customerprofile
    {
        public int CustomerId { get; set; }
        public string Smid { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Bvn { get; set; }
        public string PhoneNumber { get; set; }
        public string Fullname { get; set; }
        public byte? QuestionCompleted { get; set; }
        public byte? DeviceInfoExist { get; set; }
        public byte? IsAgent { get; set; }
        public byte? HasPryAccount { get; set; }
        public string PryAccount { get; set; }
        public string ReferralCode { get; set; }
        public byte? IsWalletOnly { get; set; }
        public string AgentCode { get; set; }
        public string LastLogin { get; set; }
        public byte? IsDefaultPassword { get; set; }
        public string RmdaoCode { get; set; }
        public string Rmname { get; set; }
        public string Rmemail { get; set; }
        public string Rmmobile { get; set; }

        public virtual Walletuser Sm { get; set; }
    }
}
