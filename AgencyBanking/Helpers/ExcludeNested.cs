using AgencyBanking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgencyBanking.Helpers
{
    public static class ExcludeNested
    {
        public static CustomerProfileResponse setProfile(Customerprofile profile)
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
                QuestionCompleted = profile.Questioncompleted,
                DeviceInfoExist = profile.Deviceinfoexist,
                IsAgent = profile.Isagent,
                HasPryAccount = profile.Haspryaccount,
                PryAccount = profile.Pryaccount,
                ReferralCode = profile.Referralcode,
                IsWalletOnly = profile.Iswalletonly,
                AgentCode = profile.Agentcode,
                LastLogin = profile.Lastlogin,
                DateOfBirth = profile.Dateofbirth,
                IsDefaultPassword = profile.Isdefaultpassword,
                RmdaoCode = profile.Rmdaocode,
                Rmname = profile.Rmname,
                Rmemail = profile.Rmemail,
                Rmmobile = profile.Rmmobile
            };
        }

        public static WalletInfoResponse setWalletInfo(Walletinfo wallet)
        {
            return new WalletInfoResponse()
            {
                Id = wallet.Id,
                Customerid = wallet.Customerid,
                FirstName = wallet.Firstname,
                Lastname = wallet.Lastname,
                Email = wallet.Email,
                Mobile = wallet.Mobile,
                Nuban = wallet.Mobile,
                Availablebalance = wallet.Availablebalance,
                Phone = wallet.Phone,
                Gender = wallet.Gender,
                FullName = wallet.Fullname,
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
                        BeneficiaryId  = ben.Beneficiaryid,
                        UserId = ben.Userid,
                        BeneficiaryAccountNumber = ben.Beneficiaryaccountnumber,
                        BeneficiaryAccountName = ben.Beneficiaryaccountname,
                        BeneficiaryBankName = ben.Beneficiarybankname,
                        BeneficiaryBankCode = ben.Beneficiarybankcode,
                        DateCreated = ben.Datecreated
    });
                }
            }
            else
            {
                Beneficiaries = null;
            }

            return Beneficiaries;
        }

        public static List<CustomerAccount> setAccounts(List<Customeraccountschema> accountSchemas)
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
                        UserId  = act.Userid,
                        AccountGroup = act.Accountgroup,
                        AccountType = act.Accounttype,
                        Name = act.Name,
                        Balance = act.Balance,
                        AccountNumber = act.Accountnumber,
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


        public static List<WalletHistoryResponse> setTransactionHistory(List<Wallettransfer> walletTransfer, string nuban)
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
                        CurrencyCode = trans.Currencycode,
                        ToAcct = trans.Toacct,
                        FromAct = trans.Fromact,
                        Remarks = trans.Remarks,
                        TransactionDate = trans.Datecreated,
                        Status = trans.Status,
                        ValueDate = trans.Datecreated,
                        BalanceAfterDebit = int.Parse(trans.Balanceafterdebit.ToString()),
                        BalanceAfterCredit = int.Parse(trans.Balanceaftercredit.ToString())
                    };

                    if (trans.Fromact == nuban)   
                    {
                        transaction.IsDebit = true;
                        transaction.DebitCredit = "1";
                        transaction.Balance = int.Parse(trans.Balanceafterdebit.ToString());
                    }
                    else    
                    {
                        transaction.IsDebit = false;
                        transaction.DebitCredit = "2";
                        transaction.Balance = int.Parse(trans.Balanceaftercredit.ToString());
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
