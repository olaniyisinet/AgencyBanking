using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgencyBanking.Models
{
    public class ResponseModel
    {
        public string message { get; set; }
        public string response { get; set; }
        public string responsedata { get; set; }
        public Data data { get; set; }
    }

    public class Data
    {
        
    }
}
