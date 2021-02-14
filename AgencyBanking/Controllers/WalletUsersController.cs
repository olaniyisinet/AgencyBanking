﻿using AgencyBanking.Helpers;
using AgencyBanking.Models;
using AgencyBanking.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AgencyBanking.Controllers
{
    [Authorize]
    [ApiController]
    [Route("/api")]
    public class WalletUsersController : ControllerBase
    {
        private IUserService _userService;
        private IMapper _mapper;
        private readonly AppSettings _appSettings;

        public WalletUsersController(IUserService userService, IMapper mapper, IOptions<AppSettings> appSettings)
        {
            _userService = userService;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }


        [AllowAnonymous]
        [HttpPost("OnboardWalletCustomer")]
        public IActionResult OnboardWalletCustomer([FromBody] CreateWalletRequest model)
        {
            // map model to entity
            var walletuser = _mapper.Map<WalletUser>(model);
            walletuser.Id = Guid.NewGuid().ToString();
            try
            {
                // create user
                var userCreated = _userService.Create(walletuser, model.Password);
                if (_userService.isSuccessful)
                {
                
                    var acctsummary = new CustomerAccountSummary
                    {
                        Accounts = new CustomerAccount { AccountInfo = walletuser.CustomerAccountSchemas.FirstOrDefault() },
                        Beneficiaries = walletuser.Beneficiaries.FirstOrDefault()
                    };

                    var dashbaord = new CustomerDashboard
                    {
                        WalletInfo = walletuser.WalletInfos.FirstOrDefault(),
                        ProfileInfo = walletuser.CustomerProfiles.FirstOrDefault(),
                        AccountSummary = acctsummary
                    };

                    return Ok(new ResponseModel2
                    {
                        response = dashbaord,
                        status = "true",
                        code = HttpContext.Response.StatusCode.ToString(),// "200",
                        message = "User registered successfully",
                    });

                }
                else
                {
                    return Ok(new ResponseModel2
                    {
                        response = _userService.errorMessage,
                        status = "false",
                        code = HttpContext.Response.StatusCode.ToString(),
                        message = "User registeration failed. " + _userService.errorMessage,
                    });
                }

            }
            catch (Exception ex)
            {
                return Ok(new ResponseModel2
                {
                    response = ex.Message,
                    status = "false",
                    code = HttpContext.Response.StatusCode.ToString(),
                    message = "User registeration failed. " + ex.Message,
                });
            }
        }

        [AllowAnonymous]
        [HttpPost("CustomerLogin")]
        public IActionResult CustomerLogin([FromBody] LoginModel model)
        {
            try
            {
                var user = _userService.Authenticate(model.Username, model.Password, model.logDetails.DeviceIMEI);

                if (user == null)
                    return BadRequest(new ResponseModel2
                    {
                        response = "Login failed",
                        status = "false",
                        code = HttpContext.Response.StatusCode.ToString(),
                        message = "Invalid username or password",
                    });

                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                    }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                var tokenString = tokenHandler.WriteToken(token);
                var acctsummary = new CustomerAccountSummary
                {
                    Accounts = new CustomerAccount { AccountInfo = user.CustomerAccountSchemas.FirstOrDefault() },
                    Beneficiaries = user.Beneficiaries.FirstOrDefault()
                };

                var dashbaord = new CustomerDashboard
                {
                    WalletInfo = user.WalletInfos.FirstOrDefault(),
                    ProfileInfo = user.CustomerProfiles.FirstOrDefault(),
                    AccountSummary = acctsummary
                };

                return Ok(new LoginResponseModel
                {
                    token = tokenString,
                    response = dashbaord,
                    status = "true",
                    code = HttpContext.Response.StatusCode.ToString(),
                    message = "Login successful",
                }) ;
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseModel2
                {
                    response = ex.Message,
                    status = "false",
                    code = HttpContext.Response.StatusCode.ToString(),
                    message = "Login Failed. " + ex.Message
                });
            }

        }
    }
}
