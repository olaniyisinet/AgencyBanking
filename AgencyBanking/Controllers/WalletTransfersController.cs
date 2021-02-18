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

        public WalletTransfersController(AgencyBankingContext context)
        {
            _context = context;
        }

        // POST: api/WalletTransfers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
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

            if (UpdateRecieverWalletBalance(walletTransfer.toacct, walletTransfer.amt, walletTransfer.SMID, walletTransfer.saveBeneficiary))
            {
                walletTrans.Status = "Successful";
                _context.Entry(walletTrans).State = EntityState.Modified;
                _context.SaveChanges();

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
            
            var walletinfo = _context.WalletInfos.Where(x => x.Mobile.Equals(request.mobile));

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


        [HttpPost("TransactionHistory")]
        public IActionResult TransactionHistory(getTransactions request)
        {
            var transactions = _context.WalletTransfers.Where(x => x.FromAct.Equals(request.From) || x.ToAcct.Equals(request.To)).ToList();

            try
            {
                return Ok(new ResponseModel2
                {
                    Data = ExcludeNested.setTransactionHistory(transactions),
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


        private bool VerifyPin(string pin, string smid)
        {
            return _context.WalletUsers.Any(e => e.Id == smid && e.Transactionpin == pin);
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
                sender.Availablebalance = sender.Availablebalance - amount;

                _context.Entry(sender).State = EntityState.Modified;
                _context.SaveChanges();

           //     Email.Send(sender.FirstOrDefault().FullName, sender.FirstOrDefault().Email, "Debit Alert on Agency Banking", "You have successfully sent NGN" + amount + " from the Agency Banking App wallet to a friend. \n Your new available balance is "
                  //  + sender.FirstOrDefault().Availablebalance + ".\n Log in to your wallet to confirm your balance. ");
            }
            else
            {
                return false;
            }

            return true;
        }

        private bool UpdateRecieverWalletBalance(string Nuban, double? amount, string senderID, bool saveBeneficiary)
        {
            var customer = _context.WalletInfos.Where(x => x.Nuban == Nuban).FirstOrDefault();

            if (customer != null)
            {
                if (DebitSender(senderID, amount))
                {
                    customer.Availablebalance = customer.Availablebalance + amount;

                    _context.Entry(customer).State = EntityState.Modified;
                    _context.SaveChanges();

                    Email.Send(customer.FullName, customer.Email, "Credit Alert on Agency Banking", "You have successfully recieved NGN" + amount + " on the Agency Banking App. \n Your new available balance is " + customer.Availablebalance
                        + ".\n Log in to your wallet to confirm your balance. ");

                    if (saveBeneficiary)
                    {
                        SaveBeneficiary(senderID, Nuban, customer.FullName);
                    }
                    return true;
                }
            }
            else
            { 
                return false;
            }

            return false;
        }

        private void SaveBeneficiary(string userId, string BeneficiaryAccountNumber, string BeneficiaryAccountName)
        {
            if (_context.Beneficiaries.Any(x => x.UserId.Equals(userId) && x.BeneficiaryAccountNumber.Equals(BeneficiaryAccountNumber)))
            {
                return;
            }

            var beneficiary = new Beneficiary()
            {
                UserId = userId,
                BeneficiaryAccountNumber = BeneficiaryAccountNumber,
                BeneficiaryAccountName = BeneficiaryAccountName,
                BeneficiaryBankName = "",
                BeneficiaryBankCode = ""
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
