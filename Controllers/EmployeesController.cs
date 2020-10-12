﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ERPProject.Data;
using ERPProject.Models;
using Microsoft.AspNetCore.Cors;
using ERPProject.Data.Repositories;

namespace ERPProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("ERPPolicy")]
    public class EmployeesController : GenericController<Employee, EmployeeRepository>
    {
        public EmployeesController(EmployeeRepository repository) : base(repository)
        {

        }
    }
}
