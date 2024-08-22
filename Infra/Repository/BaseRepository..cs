using Infra.Entidades;
using Infra.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repository
{
    public class BaseRepository<TEntity> : IBaseBaseRepository<TEntity> where TEntity : Base
    {
        private readonly DbContext _context;
        private readonly DbSet<TEntity> _entities;

        public BaseRepository(DbContext context)
        {
            _context = context;
            _entities = context.Set<TEntity>();
        }

        public async Task CreateAsync(TEntity entity) 
        {
            entity.DateCreated = DateTime.Now;
            await _context.AddAsync(entity); 
            await _context.SaveChangesAsync(); 
        }

        public async Task UpdateAsync(TEntity entity) 
        {
            entity.DateUpdated = DateTime.Now;
            _context.Update(entity);
            await _context.SaveChangesAsync(); 
        }

        public async Task DeleteAsync(TEntity entity) 
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync(); 
        }


        public async Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.Set<TEntity>().ToListAsync(cancellationToken);
        }

        public async Task<TEntity> GetAsync(int id, CancellationToken cancellationToken)
        {
            return await _context.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }
    }
}
