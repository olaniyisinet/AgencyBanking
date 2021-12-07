using BPayApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BPayApi.Helpers
{
    public static class ExcludeNested
    {
        public static CustomerProfileResponse setProfile(CustomerProfile profile)
        {
            return new CustomerProfileResponse()
            {
                CustomerId = profile.Customerid,
                Smid = profile.Smid,
                Username = profile.Username,
                Email = profile.Email,
                Address = profile.Address,
                Bvn = profile.Bvn,
                PhoneNumber = profile.Phonenumber,
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
                Lastname = wallet.LastName,
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


        public static List<WalletHistoryResponse> setTransactionHistory(List<WalletTransfer> walletTransfer, string nuban)
        {
            var transfers = new List<WalletHistoryResponse>();

            if (walletTransfer.Any())
            {
                foreach (var trans in walletTransfer)
                {
                    var transaction = new WalletHistoryResponse
                    {
                        Id = trans.Id,
                        Amount = trans.Amount,
                        Smid = trans.Smid,
                        Category = trans.Category,
                        CurrencyCode = trans.CurrencyCode,
                        ToAcct = trans.ToAcct,
                        FromAct = trans.FromAct,
                        Remarks = trans.Remarks,
                        TransactionDate = trans.DateCreated,
                        Status = trans.Status,
                        ValueDate = trans.DateCreated,
                        BalanceAfterDebit = int.Parse(trans.BalanceAfterDebit.ToString()),
                        BalanceAfterCredit = int.Parse(trans.BalanceAfterCredit.ToString())
                    };

                    if (trans.FromAct == nuban)   
                    {
                        transaction.IsDebit = true;
                        transaction.DebitCredit = "1";
                        transaction.Balance = int.Parse(trans.BalanceAfterDebit.ToString());
                    }
                    else    
                    {
                        transaction.IsDebit = false;
                        transaction.DebitCredit = "2";
                        transaction.Balance = int.Parse(trans.BalanceAfterCredit.ToString());
                    }

                    transfers.Add(transaction);
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
