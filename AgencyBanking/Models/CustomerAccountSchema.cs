using System;
using System.Collections.Generic;

#nullable disable

namespace AgencyBanking.Models
{
    public partial class CustomerAccountSchema
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string AccountGroup { get; set; }
        public string AccountType { get; set; }
        public string Name { get; set; }
        public double? Balance { get; set; }
        public string AccountNumber { get; set; }
        public string Currency { get; set; }

        public virtual WalletUser User { get; set; }
    }
}
