using ERPProject.Models;
using Microsoft.EntityFrameworkCore;
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

        public async Task<List<double>> GetByDate(int year, int month)
        {
            var ordersByDate = await GetContext().Set<Order>().Where(d => d.Time.Month == month && d.Time.Year == year).ToListAsync();

            List<double> stats = new List<double>();

            double totalUnits =
                (from order in ordersByDate
                 select order.Quantity).Sum();

            double revenue =
                (from order in ordersByDate
                 select order.Price).Sum();

            stats.Add(totalUnits);
            stats.Add(revenue);

            return stats;
        }
    }
}
