using ERPProject.Models;

namespace ERPProject.Data.Repositories
{
    public class CustomerRepository : GenericRepository<Customer, ERPContext>
    {
        public CustomerRepository(ERPContext context) : base(context)
        {

        }
    }
}
