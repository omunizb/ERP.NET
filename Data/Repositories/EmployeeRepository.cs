using ERPProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPProject.Data.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee, ERPContext>
    {
        public EmployeeRepository(ERPContext context) : base(context)
        {

        }
    }
}
