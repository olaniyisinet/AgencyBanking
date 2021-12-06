using System;
using System.Collections.Generic;

namespace AgencyBanking.Models
{
    public partial class Beneficiary
    {
        public string Beneficiaryid { get; set; }
        public string Userid { get; set; }
        public string Beneficiaryaccountnumber { get; set; }
        public string Beneficiaryaccountname { get; set; }
        public string Beneficiarybankname { get; set; }
        public string Beneficiarybankcode { get; set; }
        public DateTime? Datecreated { get; set; }

        public virtual Walletuser User { get; set; }
    }
}
