using System;
using System.Collections.Generic;

namespace AgencyBanking.Models
{
    public partial class Customeraccountschema
    {
        public int Id { get; set; }
        public string Userid { get; set; }
        public string Accountgroup { get; set; }
        public string Accounttype { get; set; }
        public string Name { get; set; }
        public double? Balance { get; set; }
        public string Accountnumber { get; set; }
        public string Currency { get; set; }

        public virtual Walletuser User { get; set; }
    }
}
