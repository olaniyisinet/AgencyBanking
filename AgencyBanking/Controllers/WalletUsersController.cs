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
    [Route("[controller]")]
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
            model.Id = Guid.NewGuid().ToString();
            var walletuser = _mapper.Map<WalletUser>(model);
            try
            {
                // create user

                var userCreated = _userService.Create(walletuser, model.Password);
                if (_userService.isSuccessful)
                {
                    return Ok(new ResponseModel2
                    {
                        response = userCreated,
                        status = "true",
                        code = "200",
                        message = "User registered successfully",
                    });
                }
                else
                {
                    return Ok(new ResponseModel2
                    {
                        response = _userService.errorMessage,
                        status = "false",
                        code = "200",
                        message = "User registeration failed",
                    });
                }

            }
            catch (Exception ex)
            {
                return Ok(new ResponseModel2
                {
                    response = ex.Message,
                    status = "false",
                    code = "200",
                    message = "User registeration failed",
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
                        code = "200",
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

                  return Ok(new ResponseModel2
                {
                    response = tokenString ,
                    status = "true",
                    code = "200",
                    message = "Login successful",
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseModel2
                {
                    response = ex.Message,
                    status = "false",
                    code = "200",
                    message = "Login Failed",
                });
            }

        }
    }
}
