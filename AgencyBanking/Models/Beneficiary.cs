using System;
using System.Collections.Generic;

#nullable disable

namespace AgencyBanking.Models
{
    public partial class Beneficiary
    {
        public int BeneficiaryId { get; set; }
        public string UserId { get; set; }
        public string BeneficiaryAccountNumber { get; set; }
        public string BeneficiaryAccountName { get; set; }
        public string BeneficiaryBankName { get; set; }
        public string BeneficiaryBankCode { get; set; }
        public DateTime? DateCreated { get; set; }

        public virtual WalletUser User { get; set; }
    }
}
