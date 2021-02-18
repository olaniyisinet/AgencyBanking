using AgencyBanking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgencyBanking.Helpers
{
    public static class ExcludeNested
    {
        public static CustomerProfileResponse setProfile(CustomerProfile profile)
        {
            return new CustomerProfileResponse()
            {
                CustomerId = profile.CustomerId,
                Smid = profile.Smid,
                Username = profile.Username,
                Email = profile.Email,
                Address = profile.Address,
                Bvn = profile.Bvn,
                PhoneNumber = profile.PhoneNumber,
                Fullname = profile.Fullname,
                QuestionCompleted = profile.QuestionCompleted,
                DeviceInfoExist = profile.DeviceInfoExist,
                IsAgent = profile.IsAgent,
                HasPryAccount = profile.HasPryAccount,
                PryAccount = profile.PryAccount,
                ReferralCode = profile.ReferralCode,
                IsWalletOnly = profile.IsWalletOnly,
                AgentCode = profile.AgentCode,
                LastLogin = profile.LastLogin,
                DateOfBirth = profile.DateOfBirth,
                IsDefaultPassword = profile.IsDefaultPassword,
                RmdaoCode = profile.RmdaoCode,
                Rmname = profile.Rmname,
                Rmemail = profile.Rmemail,
                Rmmobile = profile.Rmmobile
            };
        }

        public static WalletInfoResponse setWalletInfo(WalletInfo wallet)
        {
            return new WalletInfoResponse()
            {
                Id = wallet.Id,
                Customerid = wallet.Customerid,
                FirstName = wallet.FirstName,
                Lastname = wallet.Lastname,
                Email = wallet.Email,
                Mobile = wallet.Mobile,
                Nuban = wallet.Mobile,
                Availablebalance = wallet.Availablebalance,
                Phone = wallet.Phone,
                Gender = wallet.Gender,
                FullName = wallet.FullName,
                Currencycode = wallet.Currencycode
            };
        }

        public static List<BeneficiaryResponse> setBeneficiary(List<Beneficiary> beneficiary)
        {
            var Beneficiaries = new List<BeneficiaryResponse>();

            if(beneficiary.Any())
            {
                foreach (var ben in beneficiary)
                {
                    Beneficiaries.Add(new BeneficiaryResponse()
                    {
                        BeneficiaryId  = ben.BeneficiaryId,
                        UserId = ben.UserId,
                        BeneficiaryAccountNumber = ben.BeneficiaryAccountNumber,
                        BeneficiaryAccountName = ben.BeneficiaryAccountName,
                        BeneficiaryBankName = ben.BeneficiaryBankName,
                        BeneficiaryBankCode = ben.BeneficiaryBankCode,
                        DateCreated = ben.DateCreated
    });
                }
            }
            else
            {
                Beneficiaries = null;
            }

            return Beneficiaries;
        }

        public static List<CustomerAccount> setAccounts(List<CustomerAccountSchema> accountSchemas)
        {
         //   var AccountInfo = new List<CustomerAccountSchemaResponse>();
            var Accounts = new List<CustomerAccount>();

            if (accountSchemas.Any())
            {
                foreach (var act in accountSchemas)
                {
                    var customerAccount = new CustomerAccountSchemaResponse()
                    {
                        Id = act.Id,
                        UserId  = act.UserId,
                        AccountGroup = act.AccountGroup,
                        AccountType = act.AccountType,
                        Name = act.Name,
                        Balance = act.Balance,
                        AccountNumber = act.AccountNumber,
                        Currency = act.Currency
                    };

                    Accounts.Add(new CustomerAccount() { AccountInfo = customerAccount });
                }
            }
            else
            {
                Accounts = null;
            }

            return Accounts;
        }


        public static List<WalletTransaferResponse> setTransactionHistory(List<WalletTransfer> walletTransfer)
        {
            var transfers = new List<WalletTransaferResponse>();

            if (transfers.Any())
            {
                foreach (var trans in walletTransfer)
                {
                    transfers.Add(new WalletTransaferResponse()
                    {
                         Id = trans.Id,
                         Amount = trans.Amount,
                         Smid = trans.Smid,
                         Category = trans.Category,
                         CurrencyCode = trans.CurrencyCode,
                         ToAcct  = trans.ToAcct,
                         FromAct = trans.FromAct,
                         Remarks = trans.Remarks,
                         DateCreated = trans.DateCreated,
                         Status = trans.Status
                    });
                }
            }
            else
            {
                transfers = null;
            }

            return transfers;
        }
    }
}
