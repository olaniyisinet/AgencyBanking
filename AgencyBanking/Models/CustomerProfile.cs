using System;
using System.Collections.Generic;

namespace AgencyBanking.Models
{
    public partial class Customerprofile
    {
        public int Customerid { get; set; }
        public string Smid { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Bvn { get; set; }
        public string Phonenumber { get; set; }
        public string Fullname { get; set; }
        public bool? Questioncompleted { get; set; }
        public bool? Deviceinfoexist { get; set; }
        public bool? Isagent { get; set; }
        public bool? Haspryaccount { get; set; }
        public string Pryaccount { get; set; }
        public string Referralcode { get; set; }
        public bool? Iswalletonly { get; set; }
        public string Agentcode { get; set; }
        public string Lastlogin { get; set; }
        public DateOnly? Dateofbirth { get; set; }
        public bool? Isdefaultpassword { get; set; }
        public string Rmdaocode { get; set; }
        public string Rmname { get; set; }
        public string Rmemail { get; set; }
        public string Rmmobile { get; set; }

        public virtual Walletuser Sm { get; set; }
    }
}
