using System;
using System.Collections.Generic;

#nullable disable

namespace AgencyBanking.sakila
{
    public partial class Userqa
    {
        public string UserQaid { get; set; }
        public string UserId { get; set; }
        public string QuestionId { get; set; }
        public string Answer { get; set; }

        public virtual Question Question { get; set; }
        public virtual Walletuser User { get; set; }
    }
}
