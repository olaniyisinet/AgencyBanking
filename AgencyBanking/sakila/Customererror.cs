using System;
using System.Collections.Generic;

#nullable disable

namespace AgencyBanking.sakila
{
    public partial class Customererror
    {
        public long Refid { get; set; }
        public string MobileNum { get; set; }
        public string Bvn { get; set; }
        public string Msg { get; set; }
        public string Stage { get; set; }
        public string Email { get; set; }
        public string Screen { get; set; }
    }
}
