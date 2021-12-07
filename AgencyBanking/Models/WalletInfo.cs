using System;
using System.Collections.Generic;

#nullable disable

namespace AgencyBanking.Models
{
    public partial class WalletInfo
    {
        public int Id { get; set; }
        public string Customerid { get; set; }
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Nuban { get; set; }
        public double? Availablebalance { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
        public string FullName { get; set; }
        public string Currencycode { get; set; }

        public virtual WalletUser Customer { get; set; }
    }
}
