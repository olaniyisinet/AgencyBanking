using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgencyBanking.Models
{
    public class CustomerDashboard
    {
        public CustomerAccountSummary AccountSummary { get; set; }
        public CustomerProfile ProfileInfo { get; set; }
        public WalletInfo WalletInfo { get; set; }
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
