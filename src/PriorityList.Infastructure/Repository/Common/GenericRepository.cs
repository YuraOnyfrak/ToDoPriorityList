using Microsoft.EntityFrameworkCore;
using PriorityList.Domain.Entity.Common;
using PriorityList.Domain.Repository.Common;
using PriorityList.Infastructure.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PriorityList.Infastructure.Repository.Common
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
      where TEntity : Identifiable
    {
        private readonly ApplicationDbContext _context;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IApplicationDbContext Context
        {
            get { return _context; }
        }

        public virtual async Task<IEnumerable<TEntity>> GetAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public virtual async Task AddAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
        }

        public virtual void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }

        public virtual async Task<TEntity> GetAsync(int id)
           => await _context.Set<TEntity>().FindAsync(new { id });

        public virtual IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate = default)
            => _context.Set<TEntity>().Where(predicate);
    }
}
