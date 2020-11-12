using ERPProject.Models;

namespace ERPProject.Data.Repositories
{
    public class ProductRepository : GenericRepository<Product, ERPContext>
    {
        public ProductRepository(ERPContext context) : base(context)
        {

        }
    }
}
