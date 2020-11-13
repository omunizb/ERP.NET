using ERPProject.Data.Repositories;
using ERPProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERPProject.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    // [EnableCors("ERPPolicy")]
    public class GenericController<TEntity, TRepository> : ControllerBase
        where TEntity : class, IEntity
        where TRepository : IRepository<TEntity>
    {
        private readonly TRepository _repository;

        public TRepository GetRepository()
        {
            return _repository;
        }

        public GenericController(TRepository repository)
        {
            _repository = repository;
        }

        // GET: api/[controller]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TEntity>>> GetAll()
        {
            return await _repository.GetAll();
        }

        // GET: api/[controller]/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TEntity>> Get(Guid id)
        {
            var entity = await _repository.Get(id);

            if (entity == null)
            {
                return NotFound();
            }

            return entity;
        }

        // PUT: api/[controller]/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, TEntity entity)
        {
            if (id != entity.Id)
            {
                return BadRequest();
            }

            await _repository.Update(entity);

            return NoContent();
        }

        // POST: api/Orders
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TEntity>> Post(TEntity entity)
        {
            await _repository.Add(entity);

            return CreatedAtAction("Get", new { id = entity.Id }, entity);
        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TEntity>> Delete(Guid id)
        {

            var entity = await _repository.Delete(id);

            if (entity == null)
            {
                return NotFound();
            }

            return entity;
        }
    }
}
