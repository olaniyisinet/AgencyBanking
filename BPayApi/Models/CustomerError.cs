using System;
using System.Collections.Generic;

#nullable disable

namespace BPayApi.Models
{
    public partial class CustomerError
    {
        public long Refid { get; set; }
        public string Mobilenum { get; set; }
        public string Bvn { get; set; }
        public string Msg { get; set; }
        public string Stage { get; set; }
        public string Email { get; set; }
        public string Screen { get; set; }
        public DateTime? Datecreated { get; set; }
    }
}
