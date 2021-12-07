using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BPayApi.Models
{
    public class ResponseModel1
    {
        public string message { get; set; }
        public string response { get; set; }
        public string responsedata { get; set; }
        public dynamic data { get; set; }
    }
    public class ResponseModel2
    {
        public string status { get; set; }
        public string code { get; set; }
        public string message { get; set; }
        public dynamic Data { get; set; }
    }

    public class LoginResponseModel
    {
        public string status { get; set; }
        public string code { get; set; }
        public string message { get; set; }
        public string token { get; set; }
        public dynamic Data { get; set; }
    }

    public class QuestionResponse
    {
        public Guid QuestionId { get; set; }
        public string Question { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? DateCreated { get; set; }
    }

    public class CustomerProfileResponse
    {
        public int CustomerId { get; set; }
        public string Smid { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Bvn { get; set; }
        public string PhoneNumber { get; set; }
        public string Fullname { get; set; }
        public bool? QuestionCompleted { get; set; }
        public bool? DeviceInfoExist { get; set; }
        public bool? IsAgent { get; set; }
        public bool? HasPryAccount { get; set; }
        public string PryAccount { get; set; }
        public string ReferralCode { get; set; }
        public bool? IsWalletOnly { get; set; }
        public string AgentCode { get; set; }
        public string LastLogin { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public bool? IsDefaultPassword { get; set; }
        public string RmdaoCode { get; set; }
        public string Rmname { get; set; }
        public string Rmemail { get; set; }
        public string Rmmobile { get; set; }
    }

    public class WalletInfoResponse
    {
        public int Id { get; set; }
        public string Customerid { get; set; }
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Nuban { get; set; }
        public decimal? Availablebalance { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
        public string FullName { get; set; }
        public string Currencycode { get; set; }
    }

    public class BeneficiaryResponse
    {
        public Guid BeneficiaryId { get; set; }
        public string UserId { get; set; }
        public string BeneficiaryAccountNumber { get; set; }
        public string BeneficiaryAccountName { get; set; }
        public string BeneficiaryBankName { get; set; }
        public string BeneficiaryBankCode { get; set; }
        public DateTime? DateCreated { get; set; }
    }

    public class CustomerAccountSchemaResponse
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string AccountGroup { get; set; }
        public string AccountType { get; set; }
        public string Name { get; set; }
        public decimal? Balance { get; set; }
        public string AccountNumber { get; set; }
        public string Currency { get; set; }
    }

    public class WalletTransaferResponse
    {
        public Guid Id { get; set; }
        public double? Amount { get; set; }
        public string Smid { get; set; }
        public string Category { get; set; }
        public string CurrencyCode { get; set; }
        public string ToAcct { get; set; }
        public string FromAct { get; set; }
        public string Remarks { get; set; }
        public DateTime? DateCreated { get; set; }
        public string Status { get; set; }
    }

    public class WalletHistoryResponse
    {
        public Guid Id { get; set; }
        [JsonProperty("amt")]
        public decimal? Amount { get; set; }
        public string Smid { get; set; }
        public string Category { get; set; }
        [JsonProperty("currencycode")]
        public string CurrencyCode { get; set; }
        public string ToAcct { get; set; }
        public string FromAct { get; set; }
        [JsonProperty("remarks")]
        public string Remarks { get; set; }
        [JsonProperty("TRA_DATE")]
        public DateTime? TransactionDate { get; set; }
        public string Status { get; set; }
        public bool IsDebit { get;  set; }
        [JsonProperty("val_date")]
        public DateTime? ValueDate { get; set; }  
        [JsonProperty("BalanceAD")]
        public int BalanceAfterDebit { get; set; }
        [JsonProperty("BalanceAC")]
        public int BalanceAfterCredit { get; set; }
        [JsonProperty("Balance")]
        public int Balance { get; set; }
        [JsonProperty("deb_cre_ind")]
        public string DebitCredit { get; set; }
    }
}
