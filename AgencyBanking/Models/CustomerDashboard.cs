using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgencyBanking.Models
{
    public class CustomerDashboard
    {
        public CustomerAccountSummary AccountSummary { get; set; }
        public CustomerProfileResponse ProfileInfo { get; set; }
        public WalletInfoResponse WalletInfo { get; set; }
    }

    public class CustomerAccountSummary
    {
        public CustomerAccount Accounts  { get; set; }
        public Beneficiary Beneficiaries { get; set; }
    }

    public class CustomerAccount
    {
        public CustomerAccountSchema AccountInfo { get; set; }
    }

}
