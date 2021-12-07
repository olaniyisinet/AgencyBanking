using System;
using System.Collections.Generic;

#nullable disable

namespace BPayApi.Models
{
    public partial class Question
    {
        public Question()
        {
            UserQas = new HashSet<UserQa>();
        }

        public Guid Questionid { get; set; }
        public string Question1 { get; set; }
        public string Createdby { get; set; }
        public DateTime? Datecreated { get; set; }

        public virtual ICollection<UserQa> UserQas { get; set; }
    }
}
