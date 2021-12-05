using System;
using System.Collections.Generic;

#nullable disable

namespace AgencyBanking.sakila
{
    public partial class Otp
    {
        public int Id { get; set; }
        public string Otp1 { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public byte? IsUsed { get; set; }
    }
}
