using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AgencyBanking.Models;
using AgencyBanking.Helpers;

namespace AgencyBanking.Controllers
{
    [Route("api/")]
    [ApiController]
    public class WalletTransfersController : ControllerBase
    {
        private readonly AgencyBankingContext _context;
        private double? senderBalanceAfterDebit;

        public WalletTransfersController(AgencyBankingContext context)
        {
            _context = context;
        }

        // POST: api/WalletTransfers
        // EndDate protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("WalletTransfer")]
        public IActionResult WalletTransfer(WalletTransferRequest walletTransfer)
        {
            if(!VerifySenderBalance(walletTransfer.SMID, walletTransfer.amt))
            {
                return Ok(new ResponseModel2
                {
                    Data = "Insufficient Funds",
                    status = "false",
                    code = HttpContext.Response.StatusCode.ToString(),
                    message = "Failed. Insufficient Funds"
                }) ;
            }

            if (!VerifyPin(walletTransfer.TransactionPin, walletTransfer.SMID))
            {

                return Ok(new ResponseModel2
                {
                    Data = "Invalid Transaction Pin",
                    status = "false",
                    code = HttpContext.Response.StatusCode.ToString(),
                    message = "Failed. Invalid Transaction Pin"
                });
            }

                var walletTrans = new WalletTransfer()
                {
                     Id = Guid.NewGuid(),
                     Amount  = walletTransfer.amt,
                     Smid = walletTransfer.SMID,
                     Category = walletTransfer.Category,
                     CurrencyCode = walletTransfer.CURRENCYCODE,
                     ToAcct = walletTransfer.toacct,
                     FromAct = walletTransfer.frmacct,
                     Remarks = walletTransfer.remarks,
                     Status = "Pending"
                 };

                try
                {
                    _context.WalletTransfers.Add(walletTrans);
                    _context.SaveChanges();
                }
                catch(Exception ex)
                {
                    return Ok(new ResponseModel2
                    {
                        Data = ex.Message,
                        status = "false",
                        code = HttpContext.Response.StatusCode.ToString(),
                        message = "Transaction Failed. " + ex.Message,
                    });
                }

            if (UpdateWalletBalances(walletTrans.Id, walletTransfer.toacct, walletTransfer.amt, walletTransfer.SMID, walletTransfer.saveBeneficiary))
            {
               
                return Ok(new ResponseModel2
                {
                    Data = "Transaction Successful",
                    status = "true",
                    code = HttpContext.Response.StatusCode.ToString(),
                    message = "Transaction Successful",
                });
            }
            else
            {
                walletTrans.Status = "Failed";
                _context.Entry(walletTransfer).State = EntityState.Modified;
                _context.SaveChangesAsync();

                return Ok(new ResponseModel2
                {
                    Data = "Transaction cannot be completed at the moment, Try again later",
                    status = "false",
                    code = HttpContext.Response.StatusCode.ToString(),
                    message = "Failed. Transaction cannot be completed at the moment, Try again later"
                });
            }
        }

        [HttpPost("GetWallet")]
        public IActionResult GetWallet(getWalletModel request)
        {
            
            var walletinfo = _context.WalletInfos.Where(x => x.Mobile.Equals(request.Mobile));

            try
            {
                if (!walletinfo.Any())
                {
                    throw new AppException("User not found, please enter the correct mobile number");
                }

                return Ok(new ResponseModel2
                {
                    Data = ExcludeNested.setWalletInfo(walletinfo.FirstOrDefault()),
                    status = "true",
                    code = HttpContext.Response.StatusCode.ToString(),
                    message = "Successful",
                });
            }
            catch(Exception ex)
            {
                return Ok(new ResponseModel2
                {
                    Data = ex.Message,
                    status = "false",
                    code = HttpContext.Response.StatusCode.ToString(),
                    message = ex.Message,
                });
            }
        }

        [HttpPost("GetBeneficiary")]
        public IActionResult GetBeneficiary(getBeneficiary request)
        {
            var beneficiaries = _context.Beneficiaries.Where(x => x.UserId.Equals(request.UserId)).ToList();

            try
            {
                    return Ok(new ResponseModel2
                    {
                        Data = ExcludeNested.setBeneficiary(beneficiaries),
                        status = "true",
                        code = HttpContext.Response.StatusCode.ToString(),
                        message = "Successful",
                    });
            }
            catch (Exception ex)
            {
                return Ok(new ResponseModel2
                {
                    Data = ex.Message,
                    status = "false",
                    code = HttpContext.Response.StatusCode.ToString(),
                    message = ex.Message,
                });
            }
        }
        
        [HttpPost("addbeneficiary")]
        public IActionResult addbeneficiary(AddBeneficiary request)
        {
            try
            {
                SaveBeneficiary(request.userId, request.beneficiaryAccountNumber, request.beneficiaryAccountName);

                    return Ok(new ResponseModel2
                    {
                        Data = null,
                        status = "true",
                        code = HttpContext.Response.StatusCode.ToString(),
                        message = "Successful",
                    });
            }
            catch (Exception ex)
            {
                return Ok(new ResponseModel2
                {
                    Data = ex.Message,
                    status = "false",
                    code = HttpContext.Response.StatusCode.ToString(),
                    message = ex.Message,
                });
            }
        }

        [HttpPost("getwallethistory")]
        public IActionResult getwallethistory(getTransactions request)
        {
            var user = _context.WalletInfos.Where(x => x.Customerid.Equals(request.SMID)).FirstOrDefault();
            if(user == null)
            {
                return Ok(new ResponseModel2
                {
                    Data = null,
                    status = "true",
                    code = HttpContext.Response.StatusCode.ToString(),
                    message = "Successful",
                });
            }
            var transactions = _context.WalletTransfers.Where(x => x.FromAct.Equals(user.Nuban) || x.ToAcct.Equals(user.Nuban)).OrderByDescending(x => x.DateCreated);

            try 
            { 
                var from = DateTime.Parse(request.StartDate);
                var to = DateTime.Parse(request.EndDate);
                transactions = transactions.Where(x => x.DateCreated >= from && x.DateCreated <= to).OrderByDescending(x => x.DateCreated);
            }
            catch
            {
            }

            try
            {
                return Ok(new ResponseModel2
                {
                    Data = ExcludeNested.setTransactionHistory(transactions.ToList(), user.Nuban),
                    status = "true",
                    code = HttpContext.Response.StatusCode.ToString(), 
                    message = "Successful",
                });
            }
            catch (Exception ex)
            {
                return Ok(new ResponseModel2
                {
                    Data = ex.Message,
                    status = "false",
                    code = HttpContext.Response.StatusCode.ToString(),
                    message = ex.Message,
                });
            }
        }

        [HttpPost("getwallethistorywithnuban")]
        public IActionResult getwallethistorywithnuban(getTransactionswithnuban request)
        {

            var transactions = _context.WalletTransfers.Where(x => x.FromAct.Equals(request.Nuban) || x.ToAcct.Equals(request.Nuban));

            try
            {
                var from = DateTime.Parse(request.StartDate).Date;
                var to = DateTime.Parse(request.EndDate).Date.AddDays(1);
                transactions = _context.WalletTransfers.Where(x => x.FromAct.Equals(request.Nuban) || x.ToAcct.Equals(request.Nuban) && x.DateCreated >= from && x.DateCreated < to);    
            }
            catch      
            {
            }

            try
            {
                return Ok(new ResponseModel2
                {
                    Data = ExcludeNested.setTransactionHistory(transactions.ToList(), request.Nuban),
                    status = "true",
                    code = HttpContext.Response.StatusCode.ToString(),
                    message = "Successful",
                });
            }
            catch (Exception ex)
            {
                return Ok(new ResponseModel2
                {
                    Data = ex.Message,
                    status = "false",
                    code = HttpContext.Response.StatusCode.ToString(),
                    message = ex.Message,
                });
            }
        }























        // Helper methods *******************************************************************************

        private bool VerifyPin(string pin, string smid)
        {
            return _context.WalletUsers.Any(e => e.Id == smid && e.TransPin== Encryption.Encrypt(pin));
        }

        private bool VerifySenderBalance(string smid, double? amount)
        {
            var sender = _context.WalletInfos.Where(x => x.Customerid == smid);

            if (!sender.Any())
            {
                return false;
            }

            if (sender.FirstOrDefault().Availablebalance >= amount)
            {
                return true;
            }
            else
            {

                return false;
            }
        }
   
        private bool DebitSender(string customerID, double? amount)
        {
            var sender = _context.WalletInfos.Where(x => x.Customerid == customerID).FirstOrDefault();

            if (sender != null)
            {
                sender.Availablebalance -= amount;

                _context.Entry(sender).State = EntityState.Modified;
                _context.SaveChanges();

                //Email.Send(sender.FullName, sender.Email, "Debit Alert on Agency Banking", "Dear " + sender.FullName + ", <br> You have successfully sent NGN" + amount + " from the Agency Banking App wallet to a friend. \n Your new available balance is "
                //    + sender.Availablebalance + ".\n Log in to your wallet to confirm your balance. ");
            }
            else
            {
                return false;
            }
            senderBalanceAfterDebit = sender.Availablebalance;
            return true;
        }

        private bool UpdateWalletBalances(Guid transactionId, string Nuban, double? amount, string senderID, bool saveBeneficiary)
        {
            var customer = _context.WalletInfos.Where(x => x.Nuban == Nuban).FirstOrDefault();

            if (customer != null)
            {
                if (DebitSender(senderID, amount))
                {
                    customer.Availablebalance += amount;
                    _context.Entry(customer).State = EntityState.Modified;
                    _context.SaveChanges();

                    UpdateTransationStatus(transactionId, senderBalanceAfterDebit, customer.Availablebalance, senderBalanceAfterDebit);

                    if (saveBeneficiary)
                    {
                        SaveBeneficiary(senderID, Nuban, customer.FullName);
                    }

                 //   Email.Send(customer.FullName, customer.Email, "Credit Alert on BPay Banking", "Dear "+ customer.FullName+ ", <br> You have successfully recieved NGN" + amount + " on the Agency Banking App. \n Your new available balance is " + customer.Availablebalance
                 //     + ".\n Log in to your wallet to confirm your balance. ");

                    return true;
                }
            }
            else
            { 
                return false;
            }

            return false;
        }

        private void UpdateTransationStatus(Guid transactionId, double? BalanceAfterDebit, double? BalanceAfterCredit, double? Balance)
        {
            var transaction = _context.WalletTransfers.Find(transactionId);
            transaction.Status = "Successful";
            transaction.Balance = Balance;
            transaction.BalanceAfterCredit = BalanceAfterCredit;
            transaction.BalanceAfterDebit = BalanceAfterDebit;

            _context.Entry(transaction).State = EntityState.Modified;
            _context.SaveChanges();

        }

        private void SaveBeneficiary(string userId, string BeneficiaryAccountNumber, string BeneficiaryAccountName)
        {
            if (_context.Beneficiaries.Any(x => x.UserId.Equals(userId) && x.BeneficiaryAccountNumber.Equals(BeneficiaryAccountNumber)))
            {
                return;
            }

            var beneficiary = new Beneficiary()
            {
                BeneficiaryId = Guid.NewGuid(),
                UserId = userId,
                BeneficiaryAccountNumber = BeneficiaryAccountNumber,
                BeneficiaryAccountName = BeneficiaryAccountName,
                BeneficiaryBankName = "BelloKano",
                BeneficiaryBankCode = "999566"
            };

            try
            {
                _context.Beneficiaries.Add(beneficiary);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
            }
        }
    }
}
