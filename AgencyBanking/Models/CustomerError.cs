using System;
using System.Collections.Generic;

namespace AgencyBanking.Models
{
    public partial class Customererror
    {
        public long Refid { get; set; }
        public string Mobilenum { get; set; }
        public string Bvn { get; set; }
        public string Msg { get; set; }
        public string Stage { get; set; }
        public DateTime? Datecreated { get; set; }
        public string Email { get; set; }
        public string Screen { get; set; }
    }
}
