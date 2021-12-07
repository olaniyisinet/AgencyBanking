using System;
using System.Collections.Generic;

#nullable disable

namespace AgencyBanking.Models
{
    public partial class UserQa
    {
        public Guid UserQaid { get; set; }
        public string UserId { get; set; }
        public Guid? QuestionId { get; set; }
        public string Answer { get; set; }
        public DateTime? DateCreated { get; set; }

        public virtual Question Question { get; set; }
        public virtual WalletUser User { get; set; }
    }
}
