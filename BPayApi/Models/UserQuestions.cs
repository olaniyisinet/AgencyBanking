using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BPayApi.Models
{
    public class UserQuestions
    {
        public string smid { get; set; }
        public List<Qa> qa { get; set; }
    }

    public class Qa
    {
        public Guid questionId { get; set; }
        public string answer { get; set; }
    }

}
