using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgencyBanking.Models
{
    public class RequestModels
    {
    }
    public class GenerateOTPModel
    {
        public string Email { get; set; }
    }

    public class VerifyOTPModel
    {
        public string Email { get; set; }
        public string OTP { get; set; }

    }
    public class WalletTransferRequest
    {
        public double? amt { get; set; }
        public string SMID { get; set; }
        public string TransactionPin { get; set; }
        public string Category { get; set; }
        public string CURRENCYCODE { get; set; }
        public string toacct { get; set; }
        public string frmacct { get; set; }
        public string remarks { get; set; }
        public bool saveBeneficiary { get; set; }
    }

    public class getWalletModel
    {
        public string mobile { get; set; }
    }

    public class getBeneficiary
    {
        public string UserId { get; set; }
    }

    public class getTransactions
    {
        public string SMID { get; set; }
        public string From { get; set; }
        public string To { get; set; }
}
}
