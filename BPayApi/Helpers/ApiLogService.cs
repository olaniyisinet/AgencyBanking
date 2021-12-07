using BPayApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BPayApi.Helpers
{
    public class ApiLogService
    {
        private readonly postgresContext _db;

        public ApiLogService(postgresContext db)
        {
            _db = db;
        }

        public async Task Log(ApiLogItem apiLogItem)
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

        public async Task<IEnumerable<ApiLogItem>> Get()
        {
            var items = from i in _db.ApiLogItems
                        orderby i.Id descending
                        select i;

            return await items.ToListAsync();
        }
    }
}
