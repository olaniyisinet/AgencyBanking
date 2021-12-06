using System;
using System.Collections.Generic;

namespace AgencyBanking.Models
{
    public partial class Wallettransfer
    {
        public string Id { get; set; }
        public double? Amount { get; set; }
        public string Smid { get; set; }
        public string Category { get; set; }
        public string Currencycode { get; set; }
        public string Toacct { get; set; }
        public string Fromact { get; set; }
        public string Remarks { get; set; }
        public DateTime? Datecreated { get; set; }
        public string Status { get; set; }
        public double? Balanceafterdebit { get; set; }
        public double? Balanceaftercredit { get; set; }
        public double? Balance { get; set; }

        public virtual Walletuser Sm { get; set; }
    }
}
