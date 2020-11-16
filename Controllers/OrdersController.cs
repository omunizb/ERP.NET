using ERPProject.Data.Repositories;
using ERPProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        [HttpGet("{action}")]
        public async Task<ActionResult<IEnumerable<Stat>>> GetMonthlySales()
        {
            return await GetRepository().GetMonthlySales();
        }
    }
}
