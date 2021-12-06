using System;
using System.Collections.Generic;

namespace AgencyBanking.Models
{
    public partial class Question
    {
        public Question()
        {
            UserQas = new HashSet<Userqa>();
        }
        public string Questionid { get; set; }
        public string Question1 { get; set; }
        public string Createdby { get; set; }
        public DateTime? Datecreated { get; set; }

        public virtual ICollection<Userqa> UserQas { get; set; }
    }
}
