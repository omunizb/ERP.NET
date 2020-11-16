using ERPProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
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

        public async Task<List<Stat>> GetMonthlySales()
        {
            DateTime now = DateTime.Now;
            int month, year;
            string label;
            double units, revenue;
            List<Stat> stats = new List<Stat>();
            
            for (int i = now.Month - 6; i < now.Month; i++)
            {
                if (i == 0)
                {
                    month = 12;
                    year = now.Year - 1;
                }
                else if (i < 0)
                {
                    month = i % 12;
                    year = now.Year - 1;
                }
                else
                {
                    month = i;
                    year = now.Year;
                }
                var ordersByDate = await GetContext().Set<Order>().Where(d => d.Time.Month == month && d.Time.Year == year).ToListAsync();

                label = new DateTime(year, month, 1).ToString("Y", CultureInfo.InvariantCulture);
                
                units = (from order in ordersByDate
                         select order.Quantity).Sum();

                revenue = (from order in ordersByDate
                           select order.Price).Sum();

                stats.Add(new Stat() { Label = label, Units = units, Revenue = revenue });
            }
            return stats;
        }
    }
}
