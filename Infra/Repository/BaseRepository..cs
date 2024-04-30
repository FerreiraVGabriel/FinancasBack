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

        public void Create(TEntity entity)
        {
            entity.DateCreated = DateTime.Now;
            _context.Add(entity);
        }

        public void Update(TEntity entity)
        {
            entity.DateUpdated = DateTime.Now;
            _context.Update(entity);
        }

        public void Delete(TEntity entity)
        {
            _context.Remove(entity);
        }

        public async Task<List<TEntity>> GetAll(CancellationToken cancellationToken)
        {
            return await _context.Set<TEntity>().ToListAsync(cancellationToken);
        }

        public async Task<TEntity> Get(int id, CancellationToken cancellationToken)
        {
            return await _context.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }
    }
}
