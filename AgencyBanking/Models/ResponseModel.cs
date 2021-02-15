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
        public dynamic data { get; set; }
    }

    public class LoginResponseModel
    {
        public string status { get; set; }
        public string code { get; set; }
        public string message { get; set; }
        public string token { get; set; }
        public dynamic response { get; set; }
    }

    public class QuestionResponse
    {
        public Guid QuestionId { get; set; }
        public string Question { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? DateCreated { get; set; }
    }

}
