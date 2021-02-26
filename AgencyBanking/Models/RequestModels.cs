using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AgencyBanking.Models
{
    public class RequestModels
    {
    }
    public class GenerateOTPModel
    {
        public string Nuban { get; set; }
        public string UserName { get; set; }
        public bool IsWallet { get; set; }

    }

    public class VerifyOTPModel
    {
        public string Nuban { get; set; }
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
        public string StartDate { get; set; }
        public string EndDate { get; set; }
}

    public class getTransactionswithnuban
    {
        public string Nuban { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }

    public class AuthenticateModel
    {
        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Password { get; set; }
    }

    public class ChangeLoginPassword
    {
        public string userId { get; set; }
        public string oldpassword { get; set; }
        public string newpassword { get; set; }
    }

    public class AddBeneficiary
    {
        public string userId { get; set; }
        public string beneficiaryAccountNumber { get; set; }
        public string beneficiaryAccountName { get; set; }
        public string beneficiaryBankName { get; set; }
        public string beneficiaryBankCode { get; set; }
        public int AppVersion { get; set; }
    }

    public class CustomerActivities
    {
        public string Screen { get; set; }
        public string Msg { get; set; }
        public string Email { get; set; }
    }

    public class VerifyUserQuestion
    {
        public string UserID { get; set; }
        public string QuestionID { get; set; }
        public string Answer { get; set; }
    }

    public class VerifyTransactionPin
    {
        public string Nuban { get; set; }
        public string Pin { get; set; }
    }

    public class AddNewDevice
    {
        public string userId { get; set; }
        public string deviceos { get; set; }
        public string deviceimei { get; set; }
        public string devicemake { get; set; }
        public string devicemodel { get; set; }
        public string ipaddress { get; set; }
    }

    public class ChangetransactionPin
    {
        public string userId { get; set; }
        public string oldtransactionpin { get; set; }
        public string newtransactionpin { get; set; }
    }
}
