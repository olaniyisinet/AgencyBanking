using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BPayApi.Models
{
    public class CustomerDashboard
    {
        public CustomerAccountSummary AccountSummary { get; set; }
        public CustomerProfileResponse ProfileInfo { get; set; }
        public WalletInfoResponse WalletInfo { get; set; }
    }

    public class CustomerAccountSummary
    {
        public List<CustomerAccount> Accounts  { get; set; }
        public List<BeneficiaryResponse> Beneficiaries { get; set; }
    }

    public class CustomerAccount
    {
        public CustomerAccountSchemaResponse AccountInfo { get; set; }
    }

}
