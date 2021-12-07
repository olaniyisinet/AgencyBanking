using System;
using System.Collections.Generic;

#nullable disable

namespace BPayApi.Models
{
    public partial class Otp
    {
        public int Id { get; set; }
        public string Otp1 { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public DateTime? DateCreated { get; set; }
        public bool? IsUsed { get; set; }
    }
}
