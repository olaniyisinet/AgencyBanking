using System;
using System.Collections.Generic;

#nullable disable

namespace AgencyBanking.Models
{
    public partial class Question
    {
        public Question()
        {
            UserQas = new HashSet<UserQa>();
        }

        public Guid QuestionId { get; set; }
        public string Question1 { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? DateCreated { get; set; }

        public virtual ICollection<UserQa> UserQas { get; set; }
    }
}
