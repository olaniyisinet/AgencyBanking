using System;
using System.Collections.Generic;

namespace AgencyBanking.Models
{
    public partial class Otp
    {
        public int Id { get; set; }
        public string Otp1 { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime? Datecreated { get; set; }
        public DateTime? Expirydate { get; set; }
        public bool? Isused { get; set; }
    }
}
