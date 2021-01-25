using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgencyBanking.Models
{
    public class ResponseModel1
    {
        public string message { get; set; }
        public string response { get; set; }
        public string responsedata { get; set; }
        public dynamic data { get; set; }
    }
    public class ResponseModel2
    {
        public string status { get; set; }
        public string code { get; set; }
        public string message { get; set; }
        public dynamic response { get; set; }

    }

}
