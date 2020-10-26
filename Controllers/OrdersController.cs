using System;
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
using Microsoft.AspNetCore.Authorization;

namespace ERPProject.Controllers
{
    public class OrdersController : GenericController<Order, OrderRepository>
    {
        public OrdersController(OrderRepository repository) : base(repository)
        {

        }

        [HttpGet("{year:int}/{month:int}")]
        public async Task<ActionResult<IEnumerable<double>>> GetByDate(int year, int month)
        {
            return await GetRepository().GetByDate(year, month);
        }
    }
}
