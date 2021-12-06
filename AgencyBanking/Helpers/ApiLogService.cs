using AgencyBanking.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgencyBanking.Helpers
{
    public class ApiLogService
    {
        private readonly AgencyBankingContext _db;

        public ApiLogService(AgencyBankingContext db)
        {
            _db = db;
        }

        public async Task Log(Apilogitem apiLogItem)
        {
            try
            {
                _db.ApiLogItems.Add(apiLogItem);
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _ = ex.Message;
            }
        }

        public async Task<IEnumerable<Apilogitem>> Get()
        {
            var items = from i in _db.ApiLogItems
                        orderby i.Id descending
                        select i;

            return await items.ToListAsync();
        }
    }
}
