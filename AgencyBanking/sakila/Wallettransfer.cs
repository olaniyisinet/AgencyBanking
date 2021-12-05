using System;
using System.Collections.Generic;

#nullable disable

namespace AgencyBanking.sakila
{
    public partial class Wallettransfer
    {
        public string Id { get; set; }
        public double? Amount { get; set; }
        public string Smid { get; set; }
        public string Category { get; set; }
        public string CurrencyCode { get; set; }
        public string ToAcct { get; set; }
        public string FromAct { get; set; }
        public string Remarks { get; set; }
        public string Status { get; set; }
        public double? BalanceAfterDebit { get; set; }
        public double? BalanceAfterCredit { get; set; }
        public double? Balance { get; set; }

        public virtual Walletuser Sm { get; set; }
    }
}
