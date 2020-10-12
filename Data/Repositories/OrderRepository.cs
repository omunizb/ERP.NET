using ERPProject.Models;
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
    }
}
