using ERPProject.Data.Repositories;
using ERPProject.Models;

namespace ERPProject.Controllers
{
    public class EmployeesController : GenericController<Employee, EmployeeRepository>
    {
        public EmployeesController(EmployeeRepository repository) : base(repository)
        {

        }
    }
}
