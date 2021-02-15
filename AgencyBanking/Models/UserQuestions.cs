using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgencyBanking.Models
{
    public class UserQuestions
    {
        public string UserId { get; set; }
        public List<Qa> qa { get; set; }
    }

    public class Qa
    {
        public Guid? questionId { get; set; }
        public string answer { get; set; }
    }

}
