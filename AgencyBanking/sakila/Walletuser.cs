using System;
using System.Collections.Generic;

#nullable disable

namespace AgencyBanking.sakila
{
    public partial class Walletuser
    {
        public Walletuser()
        {
            Beneficiaries = new HashSet<Beneficiary>();
            Customeraccountschemas = new HashSet<Customeraccountschema>();
            Customerprofiles = new HashSet<Customerprofile>();
            Userdeviceinfos = new HashSet<Userdeviceinfo>();
            Userqas = new HashSet<Userqa>();
            Walletinfos = new HashSet<Walletinfo>();
            Wallettransfers = new HashSet<Wallettransfer>();
        }

        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Transactionpin { get; set; }
        public string Deviceimei { get; set; }
        public string HardwareImei { get; set; }
        public string Deviceos { get; set; }
        public string Devicemake { get; set; }
        public string Devicemodel { get; set; }
        public string Ipaddress { get; set; }
        public string Referralcode { get; set; }
        public string TransPin { get; set; }

        public virtual ICollection<Beneficiary> Beneficiaries { get; set; }
        public virtual ICollection<Customeraccountschema> Customeraccountschemas { get; set; }
        public virtual ICollection<Customerprofile> Customerprofiles { get; set; }
        public virtual ICollection<Userdeviceinfo> Userdeviceinfos { get; set; }
        public virtual ICollection<Userqa> Userqas { get; set; }
        public virtual ICollection<Walletinfo> Walletinfos { get; set; }
        public virtual ICollection<Wallettransfer> Wallettransfers { get; set; }
    }
}
