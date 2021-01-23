using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgencyBanking.Models
{
    public class CreateWalletRequest
    {
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string mobile { get; set; }
        public DateTime DOB { get; set; }
        public string Gender { get; set; }
        public string CURRENCYCODE { get; set; }
    }
}
