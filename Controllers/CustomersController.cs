using ERPProject.Data.Repositories;
using ERPProject.Models;

namespace ERPProject.Controllers
{
    public class CustomersController : GenericController<Customer, CustomerRepository>
    {
        public CustomersController(CustomerRepository repository) : base(repository)
        {

        }
    }
}
