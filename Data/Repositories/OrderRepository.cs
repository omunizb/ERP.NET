using ERPProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPProject.Data.Repositories
{
    public class OrderRepository : GenericRepository<Order, ERPContext>
    {
        public OrderRepository(ERPContext context) : base(context)
        {

        }

        public async Task<List<Order>> GetByDate(DateTime date)
        {
            return await GetContext().Set<Order>().Where(d => d.Time.Month == date.Month && d.Time.Year == date.Year).ToListAsync();
        }
    }
}
