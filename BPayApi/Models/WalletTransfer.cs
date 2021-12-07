using System;
using System.Collections.Generic;

#nullable disable

namespace BPayApi.Models
{
    public partial class WalletTransfer
    {
        public Guid Id { get; set; }
        public string Smid { get; set; }
        public decimal? Amount { get; set; }
        public string Category { get; set; }
        public string CurrencyCode { get; set; }
        public string ToAcct { get; set; }
        public string FromAct { get; set; }
        public string Remarks { get; set; }
        public string Status { get; set; }
        public decimal? BalanceAfterDebit { get; set; }
        public decimal? BalanceAfterCredit { get; set; }
        public decimal? Balance { get; set; }
        public DateTime? DateCreated { get; set; }

        public virtual WalletUser Sm { get; set; }
    }
}
