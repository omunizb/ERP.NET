using ERPProject.Data.Repositories;
using ERPProject.Models;

namespace ERPProject.Controllers
{
    public class ProductsController : GenericController<Product, ProductRepository>
    {
        public ProductsController(ProductRepository repository) : base(repository)
        {

        }
    }
}
