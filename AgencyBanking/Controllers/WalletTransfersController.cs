using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AgencyBanking.Models;

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
        [HttpPost("WalletTransfar")]
        public IActionResult WalletTransfer(WalletTransferRequest walletTransfer)
        {
            if(!VerifySenderBalance(walletTransfer.SMID, walletTransfer.amt))
            {
                return Ok(new ResponseModel2
                {
                    Data = "Transaction Failed, Insufficient Funds",
                    status = "false",
                    code = HttpContext.Response.StatusCode.ToString(),
                    message = "Transaction Failed, Insufficient Funds",
                });
            }

            if (!VerifyPin(walletTransfer.TransactionPin, walletTransfer.SMID))
            {
                return Ok(new ResponseModel2
                {
                    Data = "Invalid Transaction Pin",
                    status = "false",
                    code = HttpContext.Response.StatusCode.ToString(),// "200",
                    message = "Invalid Transaction Pin",
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
                    _context.SaveChangesAsync();

                    if (UpdateWalletBalance(walletTransfer.toacct, walletTransfer.amt))
                    {
                        walletTrans.Status = "Successful";
                        _context.Entry(walletTransfer).State = EntityState.Modified;
                        _context.SaveChangesAsync();

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
                            Data = "Transaction Failed, Try again later",
                            status = "false",
                            code = HttpContext.Response.StatusCode.ToString(),
                            message = "Transaction Failed, Try again later",
                        });
                    }
               
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
            }
         











        private bool VerifyPin(string pin, string smid)
        {
            return _context.WalletUsers.Any(e => e.Id == smid && e.Transactionpin == pin);
        }




        private bool VerifySenderBalance(string smid, double? amount)
        {
            var sender = _context.WalletInfos.Where(x => x.Customerid == smid);

            if (sender.FirstOrDefault().Availablebalance >= amount)
            {
                return true;
            }
            else
            {

                return false;
            }
        }


        private bool UpdateWalletBalance(string Nuban, double? amount)
        {
            var customer = _context.WalletInfos.Where(x => x.Nuban == Nuban);

            if (customer.Any())
            {
                customer.FirstOrDefault().Availablebalance = customer.FirstOrDefault().Availablebalance + amount;

                _context.Entry(customer).State = EntityState.Modified;
                _context.SaveChangesAsync();
            }
            else
            {
                return false;
            }

            return true;
        }
    }
}
