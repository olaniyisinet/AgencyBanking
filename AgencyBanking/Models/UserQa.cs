using System;
using System.Collections.Generic;

namespace AgencyBanking.Models
{
    public partial class Userqa
    {
        public string Userqaid { get; set; }
        public string Userid { get; set; }
        public string Questionid { get; set; }
        public string Answer { get; set; }
        public DateTime? Datecreated { get; set; }

        public virtual Question Question { get; set; }
        public virtual Walletuser User { get; set; }
    }
}
