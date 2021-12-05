using System;
using System.Collections.Generic;

#nullable disable

namespace AgencyBanking.sakila
{
    public partial class Question
    {
        public Question()
        {
            Userqas = new HashSet<Userqa>();
        }

        public string QuestionId { get; set; }
        public string Question1 { get; set; }
        public string CreatedBy { get; set; }

        public virtual ICollection<Userqa> Userqas { get; set; }
    }
}
