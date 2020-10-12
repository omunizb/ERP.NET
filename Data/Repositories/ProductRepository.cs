using ERPProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPProject.Data.Repositories
{
    public class ProductRepository : GenericRepository<Product, ERPContext>
    {
        public ProductRepository(ERPContext context) : base(context)
        {

        }
    }
}
