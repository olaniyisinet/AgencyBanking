using System;
using System.Collections.Generic;

#nullable disable

namespace AgencyBanking.sakila
{
    public partial class Apilogitem
    {
        public int Id { get; set; }
        public decimal? ResponseMillis { get; set; }
        public int? StatusCode { get; set; }
        public string Method { get; set; }
        public string Path { get; set; }
        public string QueryString { get; set; }
        public string RequestBody { get; set; }
        public string ResponseBody { get; set; }
    }
}
