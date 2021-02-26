﻿using AgencyBanking.Models;
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
        private readonly AgencyBankingContext _context;

        public TransactionPinController(AgencyBankingContext context)
        {
            _context = context;
        }

        [HttpPost("VerifyTransationPin")]
        public IActionResult VerifyTransationPin(VerifyTransactionPin request)
        {
            if (_context.WalletUsers.Any(x => x.PhoneNumber.Equals(request.Nuban) && x.Transactionpin.Equals(request.Pin)))
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
        public IActionResult changetransactionpin(ChangetransactionPin request)
        {
            var user = _context.WalletUsers.Where(x => x.Id.Equals(request.userId) && x.Transactionpin.Equals(request.oldtransactionpin)).FirstOrDefault();

            if(user != null)
            {
                user.Transactionpin = request.newtransactionpin;
                _context.Entry(user).State = EntityState.Modified;
                _context.SaveChanges();

                return Ok(new ResponseModel2
                {
                    Data = "Pin Chnaged",
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