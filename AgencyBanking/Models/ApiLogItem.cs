using System;
using System.Collections.Generic;

namespace AgencyBanking.Models
{
    public partial class Apilogitem
    {
        public int Id { get; set; }
        public DateTime? Requesttime { get; set; }
        public decimal? Responsemillis { get; set; }
        public int? Statuscode { get; set; }
        public string Method { get; set; }
        public string Path { get; set; }
        public string Querystring { get; set; }
        public string Requestbody { get; set; }
        public string Responsebody { get; set; }
    }
}
