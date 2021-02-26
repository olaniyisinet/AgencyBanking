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
        public IActionResult GenerateOtp(GenerateOTPModel request)
        {
            var user = _context.WalletUsers.Where(x => x.PhoneNumber.Equals(request.Nuban) || x.UserName.Equals(request.UserName)).FirstOrDefault();

            if (user != null)
            {
                var otp = new Otp()
                {
                    Otp1 = generateCode(),
                    Email = user.EmailAddress,
                    Phone = user.PhoneNumber,
                    DateCreated = DateTime.UtcNow,
                    ExpiryDate = DateTime.UtcNow.AddMinutes(5),
                    IsUsed = false
                };

                _context.Otps.Add(otp);
                _context.SaveChangesAsync();

                Email.Send(user.FirstName, user.EmailAddress, "BPay OTP", "Dear " + user.FirstName + ", <br> Complete your transaction with the OTP below: <br><br>" + otp.Otp1 + "<br> <br> OTP expires in 5 minutes. <br> <br> If you did not request this, kindly contact our customer care immediately.");

                return Ok(new ResponseModel2
                {
                    Data = null,
                    status = "true",
                    code = HttpContext.Response.StatusCode.ToString(),
                    message = "OTP sent successfully. ",
                });
            }
            else
            {
                return Ok(new ResponseModel2
                {
                    Data = null,
                    status = "false",
                    code = HttpContext.Response.StatusCode.ToString(),
                    message = "Failed. User not found",
                });

            }
        }

        [HttpPost("VerifyOtp")]
        public IActionResult VerifyOtp(VerifyOTPModel verifyotp)
        {
            var otp = _context.Otps.Where(x => x.Otp1 == verifyotp.OTP && x.Phone == verifyotp.Nuban).FirstOrDefault();

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
                    Data = "OTP Expired",
                    status = "false",
                    code = HttpContext.Response.StatusCode.ToString(),
                    message = "OTP Expired",
                });
            }
            else if (otp.IsUsed == true)
            {
                return Ok(new ResponseModel2
                {
                    Data = "OTP Used",
                    status = "false",
                    code = HttpContext.Response.StatusCode.ToString(),
                    message = "OTP Used",
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
                    message = "OTP Verified Successfully",
                });
            }
        }


        [HttpPost("addcustomererror")]
        public IActionResult addcustomererror(CustomerActivities request)
        {
            var error = new CustomerError()
            {
                Screen = request.Screen,
                Msg = request.Msg,
                Email = request.Email
            };
            _context.CustomerErrors.Add(error);
            _context.SaveChanges();

            return Ok();
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
