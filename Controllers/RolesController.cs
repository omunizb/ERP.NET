using ERPProject.Data;
using ERPProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private UserManager<User> _userManager;

        public RolesController(UserManager<User> userManager, ERPContext context)
        {
            _userManager = userManager;
        }

        [HttpGet("{username}")]
        public async Task<ActionResult<string>> Get(string username)
        {
            var user = await _userManager.FindByNameAsync(username);

            if (user == null)
            {
                return NotFound();
            }

            var roleList = await _userManager.GetRolesAsync(user);
            string role = roleList.FirstOrDefault();
            return await Task.FromResult(role);
        }
    }
}
