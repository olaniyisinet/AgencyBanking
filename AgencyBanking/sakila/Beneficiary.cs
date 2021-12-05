using System;
using System.Collections.Generic;

#nullable disable

namespace AgencyBanking.sakila
{
    public partial class Beneficiary
    {
        public string BeneficiaryId { get; set; }
        public string UserId { get; set; }
        public string BeneficiaryAccountNumber { get; set; }
        public string BeneficiaryAccountName { get; set; }
        public string BeneficiaryBankName { get; set; }
        public string BeneficiaryBankCode { get; set; }

        public virtual Walletuser User { get; set; }
    }
}
