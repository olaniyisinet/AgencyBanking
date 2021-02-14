using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgencyBanking.Helpers;
using AgencyBanking.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AgencyBanking.Services
{

    public interface IUserService
    {
        WalletUser Authenticate(string username, string password, string DeviceIMEI);
        WalletUser Create(WalletUser user, string password);
        WalletUser GetById(string id);

        string errorMessage { get; set; }
        bool isSuccessful { get; set; }
    }


    public class UserService : IUserService
    {
        private AgencyBankingContext _context;
        private readonly IMapper mapper;

        public string errorMessage { get; set; }
        public bool isSuccessful { get; set; }

        public UserService(AgencyBankingContext context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }

        public WalletUser Authenticate(string username, string password, string DeviceIMEI)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;

            var user = _context.WalletUsers.Include(i => i.CustomerProfiles).Include(w => w.WalletInfos).SingleOrDefault(x => x.UserName == username);

            // check if username exists
            if (user == null)
                return null;

            // check if password is correct
            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            if (user.Deviceimei != DeviceIMEI)
               throw new AppException("Device Not Registered with your profile");

            // authentication successful
            return user;
        }

        public WalletUser Create(WalletUser user, string password)
        {
            // validation
            if (string.IsNullOrWhiteSpace(password))
                throw new AppException("Password is required");

            if (_context.WalletUsers.Any(x => x.UserName == user.UserName))
                throw new AppException("Username \"" + user.UserName + "\" is already taken");

            if (_context.WalletUsers.Any(x => x.EmailAddress == user.EmailAddress))
                throw new AppException("Email \"" + user.EmailAddress + "\" is already taken");
            
            if (_context.WalletUsers.Any(x => x.Deviceimei == user.Deviceimei))
                throw new AppException("Device already profiled with a user");


            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            user.HardwareImei = user.HardwareImei.Substring(0,20);

            //create wallet info
            var wallet = new WalletInfo
            {
                Customerid = user.Id,
                FirstName = user.FirstName,
                Lastname = user.LastName,
                Email = user.EmailAddress,
                Mobile = user.PhoneNumber,
                Nuban = "",
                Availablebalance = 0.00,
                Phone = user.PhoneNumber,
                Gender = user.Gender,
                FullName = user.FirstName + " " + user.LastName,
                Currencycode = "NGN"
            };

            var profile = new CustomerProfile
            {
                Username = user.UserName,
                Email = user.EmailAddress,
                Address = user.EmailAddress,
                Bvn = "",
                PhoneNumber = user.PhoneNumber,
                Fullname = wallet.FullName,
                QuestionCompleted = false,
                DeviceInfoExist = false,
                IsAgent = false,
                HasPryAccount = false,
                PryAccount = "",
                ReferralCode = "",
                IsWalletOnly = true,
                AgentCode = "",
                LastLogin = DateTime.UtcNow.ToString(),
                DateOfBirth = user.DateOfBirth,
                IsDefaultPassword = false,
                RmdaoCode = "",
                Rmname = "",
                Rmemail = "",
                Rmmobile = ""
            };

            user.WalletInfos.Add(wallet);
            user.CustomerProfiles.Add(profile);

            _context.WalletUsers.Add(user);
            _context.SaveChanges();

            isSuccessful = true;
            return user;
        }

        public WalletUser GetById(string id)
        {
            return _context.WalletUsers.Find(id);
        }

        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
            if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;
        }

        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

    }
}
