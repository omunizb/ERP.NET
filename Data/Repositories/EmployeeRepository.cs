using ERPProject.Models;

namespace ERPProject.Data.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee, ERPContext>
    {
        public EmployeeRepository(ERPContext context) : base(context)
        {

        }
    }
}
