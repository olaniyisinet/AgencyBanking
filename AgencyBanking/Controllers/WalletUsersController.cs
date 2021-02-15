using AgencyBanking.Helpers;
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
                        Accounts =  ExcludeNested.setAccounts(walletuser.CustomerAccountSchemas.ToList()),
                        Beneficiaries = ExcludeNested.setBeneficiary(walletuser.Beneficiaries.ToList())
                    };

                    var dashbaord = new CustomerDashboard
                    {
                        WalletInfo = ExcludeNested.setWalletInfo(walletuser.WalletInfos.FirstOrDefault()),
                        ProfileInfo = ExcludeNested.setProfile(walletuser.CustomerProfiles.FirstOrDefault()),
                        AccountSummary = acctsummary
                    };

                    return Ok(new ResponseModel2
                    {
                        Data = dashbaord,
                        status = "true",
                        code = HttpContext.Response.StatusCode.ToString(),// "200",
                        message = "User registered successfully",
                    });

                }
                else
                {
                    return Ok(new ResponseModel2
                    {
                        Data = _userService.errorMessage,
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
                    Data = ex.Message,
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
                var user = _userService.Authenticate(model.SMUsername, model.SMPassword, model.LogDetails.DeviceIMEI);

                if (user == null)
                    return BadRequest(new ResponseModel2
                    {
                        Data = "Login failed",
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
                    // Accounts = new CustomerAccount { AccountInfo = ExcludeNested.setAccounts( user.CustomerAccountSchemas.ToList()) },
                    Accounts = ExcludeNested.setAccounts(user.CustomerAccountSchemas.ToList()),
                    Beneficiaries = ExcludeNested.setBeneficiary( user.Beneficiaries.ToList())
                };

                var dashbaord = new CustomerDashboard
                {
                    WalletInfo = ExcludeNested.setWalletInfo(user.WalletInfos.FirstOrDefault()),
                    ProfileInfo = ExcludeNested.setProfile(user.CustomerProfiles.FirstOrDefault()),
                    AccountSummary = acctsummary
                };

                return Ok(new LoginResponseModel
                {
                  //  token = tokenString,
                    Data = dashbaord,
                    status = "true",
                    code = HttpContext.Response.StatusCode.ToString(),
                    message = "Login successful",
                }) ;
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseModel2
                {
                    Data = ex.Message,
                    status = "false",
                    code = HttpContext.Response.StatusCode.ToString(),
                    message = "Login Failed. " + ex.Message
                });
            }

        }
    }
}
