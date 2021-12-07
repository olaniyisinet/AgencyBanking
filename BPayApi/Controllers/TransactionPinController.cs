using BPayApi.Helpers;
using BPayApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgencyBanking.Controllers
{
    [Route("api/")]
    [ApiController]
    public class TransactionPinController : ControllerBase
    {
        private readonly postgresContext _context;

        public TransactionPinController(postgresContext context)
        {
            _context = context;
        }

        [HttpPost("VerifyTransationPin")]
        public IActionResult VerifyTransationPin(VerifyTransactionPin request)
        {
            if (_context.WalletUsers.Any(x => x.Phonenumber.Equals(request.Nuban) && x.Transpin.Equals(Encryption.Encrypt(request.Pin))))
            {
                return Ok(new ResponseModel2
                {
                    Data = "Pin Verified",
                    status = "true",
                    code = HttpContext.Response.StatusCode.ToString(),
                    message = "Pin Verified Successfully",
                });
            }
            else
            {
                return Ok(new ResponseModel2
                {
                    Data = null,
                    status = "false",
                    code = HttpContext.Response.StatusCode.ToString(),
                    message = "Invalid Transaction Pin",
                });
            }
        }


        [HttpPost("changetransactionpin")]
        public IActionResult Changetransactionpin(ChangetransactionPin request)
        {
            var user = _context.WalletUsers.Where(x => x.Id.Equals(request.userId) && x.Transactionpin.Equals(request.oldtransactionpin)).FirstOrDefault();

            if(user != null)
            {
                user.Transactionpin = " ";
                user.Transpin = Encryption.Encrypt(request.newtransactionpin);
                _context.Entry(user).State = EntityState.Modified;
                _context.SaveChanges();

                return Ok(new ResponseModel2
                {
                    Data = "Pin Changed",
                    status = "true",
                    code = HttpContext.Response.StatusCode.ToString(),
                    message = "Pin Changed Successfully",
                });

            }
            else
            {
                return Ok(new ResponseModel2
                {
                    Data = null,
                    status = "false",
                    code = HttpContext.Response.StatusCode.ToString(),
                    message = "Invalid Old Transaction Pin",
                });
            }
        }
        }
        }