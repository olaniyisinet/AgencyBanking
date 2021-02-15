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
    public class OtpsController : ControllerBase
    {
        private readonly AgencyBankingContext _context;

        public OtpsController(AgencyBankingContext context)
        {
            _context = context;
        }

        // POST: api/Otps
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("GenerateOtp")]
        public IActionResult GenerateOtp(GenerateOTPModel email)
        {
            var otp = new Otp()
            {
                Otp1 = generateCode(),
                Email = email.Email,
                Phone = "",
                DateCreated = DateTime.UtcNow,
                ExpiryDate = DateTime.UtcNow.AddMinutes(5),
                IsUsed = false
            };

            _context.Otps.Add(otp);
             _context.SaveChangesAsync();

            return Ok(new ResponseModel2
            {
                Data = otp.Otp1,
                status = "true",
                code = HttpContext.Response.StatusCode.ToString(),
                message = "OTP sent successfully. " +  otp.Otp1,
            });
        }

        [HttpPost("VerifyOtp")]
        public IActionResult VerifyOtp(VerifyOTPModel verifyotp)
        {
            var otp = _context.Otps.Where(x => x.Otp1 == verifyotp.OTP && x.Email == verifyotp.Email).FirstOrDefault();

            if (otp == null)
            {
                return Ok(new ResponseModel2
                {
                    Data = "Invalid OTP",
                    status = "false",
                    code = HttpContext.Response.StatusCode.ToString(),
                    message = "Invalid OTP",
                });
            }
            else if (DateTime.UtcNow > otp.ExpiryDate)
            {
                return Ok(new ResponseModel2
                {
                    Data = "Invalid Expired",
                    status = "false",
                    code = HttpContext.Response.StatusCode.ToString(),
                    message = "Invalid Expired",
                });
            }
            else
            {
                otp.IsUsed = true;

                _context.Entry(otp).State = EntityState.Modified;
                _context.SaveChangesAsync();
              
                return Ok(new ResponseModel2
                {
                    Data = "OTP Verified",
                    status = "true",
                    code = HttpContext.Response.StatusCode.ToString(),
                    message = "OTP  Verified Successfully",
                });
            }
        }


        private string generateCode()
        {
            var chars1 = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890";
            var stringChars1 = new char[6];
            var random1 = new Random();

            for (int i = 0; i < stringChars1.Length; i++)
            {
                stringChars1[i] = chars1[random1.Next(chars1.Length)];
            }

           return new String(stringChars1);
        }
    }
}
