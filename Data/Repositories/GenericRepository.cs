using ERPProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPProject.Data.Repositories
{
    public abstract class GenericRepository<TEntity, TContext> : IRepository<TEntity> 
        where TEntity : class, IEntity 
        where TContext : DbContext
    {
        private readonly TContext _context;

        public TContext GetContext()
        {
            return _context;
        }

        public GenericRepository(TContext context)
        {
            _context = context;
        }
        
        public async Task<TEntity> Get(long id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }
        
        public async Task<List<TEntity>> GetAll()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }
        
        public async Task<TEntity> Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        
        public async Task<TEntity> Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> Delete(long id)
        {
            var entity = await _context.Set<TEntity>().FindAsync(id);
            if (entity == null)
            {
                return entity;
            }

            _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync();
            
            return entity;
        }
    }
}
