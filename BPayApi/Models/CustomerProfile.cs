using System;
using System.Collections.Generic;

#nullable disable

namespace BPayApi.Models
{
    public partial class CustomerProfile
    {
        public int Customerid { get; set; }
        public string Smid { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Bvn { get; set; }
        public string Phonenumber { get; set; }
        public string Fullname { get; set; }
        public bool? QuestionCompleted { get; set; }
        public bool? DeviceInfoExist { get; set; }
        public bool? IsAgent { get; set; }
        public bool? HasPryAccount { get; set; }
        public string PryAccount { get; set; }
        public string ReferralCode { get; set; }
        public bool? IsWalletOnly { get; set; }
        public string AgentCode { get; set; }
        public string LastLogin { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public bool? IsDefaultPassword { get; set; }
        public string RmdaoCode { get; set; }
        public string Rmname { get; set; }
        public string Rmemail { get; set; }
        public string Rmmobile { get; set; }

        public virtual WalletUser Sm { get; set; }
    }
}
