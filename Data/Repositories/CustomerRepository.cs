using ERPProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPProject.Data.Repositories
{
    public class CustomerRepository : GenericRepository<Customer, ERPContext>
    {
        public CustomerRepository(ERPContext context) : base(context)
        {

        }
    }
}
