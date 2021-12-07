using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using BPayApi.Helpers;
using BPayApi.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace BPayApi.Services
{

    public interface IUserService
    {
        WalletUser Authenticate(string username, string password, string DeviceIMEI);
        WalletUser Create(WalletUser user, string password);
        WalletUser GetById(string id);
        WalletUser FindByPhone(string phone);
        bool ResetPassword(string Nuban);
        WalletUser FindByID(string smid);
        string ChangePassword(string userName, string oldpassword, string newPassword);
        UserDeviceInfo AddUserDevice(Adddevice request);
        bool UpdateProfile(UserProfileUpdate request);

        string errorMessage { get; set; }
        bool isSuccessful { get; set; }
    }


    public class UserService : IUserService
    {
        private postgresContext _context;
        private readonly IMapper mapper;

        public string errorMessage { get; set; }
        public bool isSuccessful { get; set; }

        public UserService(postgresContext context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }

        public WalletUser Authenticate(string username, string password, string DeviceIMEI)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;

            var user = _context.WalletUsers.Include(i => i.CustomerProfiles).Include(w => w.WalletInfos).Include(b => b.Beneficiaries).SingleOrDefault(x => x.Username == username);

            // check if username exists
            if (user == null)
                return null;

            // check if password is correct
            if (!VerifyPasswordHash(password, user.Passwordhash, user.Passwordsalt))
                return null;

            if (!_context.UserDeviceInfos.Any(x => x.UserId.Equals(user.Id) && x.Imei.Equals(DeviceIMEI) && x.IsCurrent.Equals(true)))
               throw new AppException("Device Not Registered with your Profile");

            // authentication successful
           // Email.Send(user.FirstName + " " + user.LastName, user.EmailAddress, "Agency Banking Login Successful", "You have successfully log in to the Agency Banking APP");

            return user;
        }

        public WalletUser Create(WalletUser user, string password)
        {
            // validation
            if (string.IsNullOrWhiteSpace(password))
                throw new AppException("Password is required");

            if (_context.WalletUsers.Any(x => x.Username == user.Username))
                throw new AppException("Username \"" + user.Username + "\" is already taken");

            if (_context.WalletUsers.Any(x => x.Emailaddress == user.Emailaddress))
                throw new AppException("Email \"" + user.Emailaddress + "\" is already taken");
            
           // if (_context.WalletUsers.Any(x => x.Deviceimei == user.Deviceimei))
             //   throw new AppException("Device already profiled with this user");

            if (_context.WalletUsers.Any(x => x.Phonenumber == user.Phonenumber))
                throw new AppException("Phone number already profiled with a user");


            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.Passwordhash = passwordHash;
            user.Passwordsalt = passwordSalt;
            user.Transpin = Encryption.Encrypt(user.Transactionpin);
            user.Transactionpin = "";

            if (user.Hardwareimei.Length > 50)
            {
                user.Hardwareimei = user.Hardwareimei.Substring(0, 50);
            }
            //create wallet info
            var wallet = new WalletInfo
            {
                Customerid = user.Id,
                FirstName = user.Firstname,
                LastName = user.Lastname,
                Email = user.Emailaddress,
                Mobile = user.Phonenumber,
                Nuban = user.Phonenumber,
                Availablebalance = (decimal?)10000.00,
                Phone = user.Phonenumber,
                Gender = user.Gender,
                FullName = user.Firstname + " " + user.Lastname,
                Currencycode = "NGN"
            };

            var profile = new CustomerProfile
            {
                Username = user.Username,
                Email = user.Emailaddress,
                Address = user.Emailaddress,
                Bvn = "",
                Phonenumber = user.Phonenumber,
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
                DateOfBirth = user.Dateofbirth,
                IsDefaultPassword = false,
                RmdaoCode = "",
                Rmname = "",
                Rmemail = "",
                Rmmobile = ""
            };

            var deviceInfo = new UserDeviceInfo
            {
                DeviceId = Guid.NewGuid(),
                Imei = user.Deviceimei,
                Osversion = user.Deviceos,
                Make = user.Devicemake,
                Model = user.Devicemodel,
                Ipaddress = user.Ipaddress,
                IsCurrent = true,
                HardwareImei = user.Hardwareimei
            };

            user.UserDeviceInfos.Add(deviceInfo);
            user.WalletInfos.Add(wallet);
            user.CustomerProfiles.Add(profile);

            _context.WalletUsers.Add(user);
            _context.SaveChanges();

         //   Email.Send(profile.Fullname, user.EmailAddress, "BPay Agent Banking Successful Registration", "Dear " + profile.Fullname + ", <br> You have successfully registered on the BPay Agency Banking APP.");

            isSuccessful = true;
            return user;
        }

        public bool UpdateProfile(UserProfileUpdate request)
        {
            var user = _context.WalletUsers.Find(request.SMID.ToString());

            if(user != null)
            {
                return false;
            }

            user.WalletInfos.FirstOrDefault().FirstName = request.FirstName;
            user.WalletInfos.FirstOrDefault().LastName = request.LastName;
            user.WalletInfos.FirstOrDefault().Gender = request.Gender;
            user.WalletInfos.FirstOrDefault().FullName = request.FirstName + " " + request.LastName;
         
            user.CustomerProfiles.FirstOrDefault().Fullname = request.FirstName + " " + request.LastName;
            user.CustomerProfiles.FirstOrDefault().DateOfBirth = request.DateOfBirth;

            _context.Entry(user).State = EntityState.Modified;
            _context.SaveChanges();

            return true;
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

        public WalletUser FindByPhone(string phone)
        {
            var user = _context.WalletUsers.Where(x => x.Phonenumber == phone).FirstOrDefault();
            return user;
        } 
        
        public WalletUser FindByID(string smid)
        {
            var user = _context.WalletUsers.Find(smid);
            return user;
        }

        public bool ResetPassword(string Nuban)
        {
            try
            {
                var user = _context.WalletUsers.Where(x => x.Phonenumber == Nuban).FirstOrDefault();
                if (user == null)
                {
                    return false;
                }

                var newPassword = GetRandomPassword(6);
                byte[] passwordHash, passwordSalt;
                CreatePasswordHash(newPassword, out passwordHash, out passwordSalt);
                user.Passwordhash = passwordHash;
                user.Passwordsalt = passwordSalt;

                _context.WalletUsers.Update(user);
                _context.SaveChanges();

                try
                {
                    Email.Send(user.Firstname + " " + user.Lastname, user.Emailaddress, "BPay App Password Reset Successful", "You have successfully reset you BetterPay password." +
                       " Log in with the password below . <br> <br> New Password: " + newPassword + "<br> <br> Make sure you change your password when you successfully log in");
                }
                catch
                {

                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        } 
        
        public string ChangePassword(string userID, string oldpassword, string newPassword)
        {
            try
            {
                var user = _context.WalletUsers.Where(x => x.Id == userID).FirstOrDefault();
                if (user == null)
                {
                    return "User not found";
                }

                if (!VerifyPasswordHash(oldpassword, user.Passwordhash, user.Passwordsalt))
                {
                    return "Old Password is incorrect";
                }

                byte[] passwordHash, passwordSalt;
                CreatePasswordHash(newPassword, out passwordHash, out passwordSalt);
                user.Passwordhash = passwordHash;
                user.Passwordsalt = passwordSalt;

                _context.WalletUsers.Update(user);
                _context.SaveChanges();
                Email.Send(user.Firstname + " " + user.Lastname, user.Emailaddress, "BPay App Password Reset Successful", "You have successfully reset you KMN APP (KnowMyNeighbour) password");
                return "Success";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public UserDeviceInfo AddUserDevice(Adddevice request)
        {
            var user = _context.WalletUsers.Where(x => x.Username.Equals(request.UserName));
            if(!user.Any())
                throw new AppException("User Not Found");

            var userdevice = _context.UserDeviceInfos.Where(x => x.UserId.Equals(user.FirstOrDefault().Id));

             var previousDevice = userdevice.Where(x => x.Imei != request.DeviceIMEI && x.IsCurrent == true).FirstOrDefault();
             var SameIMEIpreviousDevice = userdevice.Where(x => x.Imei == request.DeviceIMEI && x.IsCurrent == false).FirstOrDefault();
             var SameIMEICurrentDevice = userdevice.Where(x => x.Imei == request.DeviceIMEI && x.IsCurrent == true).FirstOrDefault();

            if (previousDevice != null)
            {
                previousDevice.IsCurrent = false;
                _context.UserDeviceInfos.Update(previousDevice);
                _context.SaveChanges();
            }
            if (SameIMEIpreviousDevice != null)
            {
                SameIMEIpreviousDevice.IsCurrent = true;
                SameIMEIpreviousDevice.Ipaddress = request.Ipaddress;
                _context.UserDeviceInfos.Update(SameIMEIpreviousDevice);
                _context.SaveChanges();

                return SameIMEIpreviousDevice;
            }

             if(SameIMEICurrentDevice != null)
               {
                        return SameIMEICurrentDevice;
               }
  

            var deviceInfo = new UserDeviceInfo
            {
                DeviceId = Guid.NewGuid(),
                UserId = user.FirstOrDefault().Id,
                Imei = request.DeviceIMEI,
                Osversion = request.DeviceOS,
                Make = request.Make,
                Model = request.Model,
                Ipaddress = request.Ipaddress,
                IsCurrent = true,
                HardwareImei = request.HardwareIMEI
            };

            _context.UserDeviceInfos.Add(deviceInfo);
            _context.SaveChanges();

            return deviceInfo;
        }

        private static string GetRandomPassword(int length)
        {
            byte[] rgb = new byte[length];
            var rngCrypt = new RNGCryptoServiceProvider();
            rngCrypt.GetBytes(rgb);
            return Convert.ToBase64String(rgb);
        }
    }
}
