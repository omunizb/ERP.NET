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

namespace ERPProject.Controllers
{
    public class ProductsController : GenericController<Product, ProductRepository>
    {
        public ProductsController(ProductRepository repository) : base(repository)
        {

        }
    }
}
