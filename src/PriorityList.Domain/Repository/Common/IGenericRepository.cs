using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PriorityList.Domain.Repository.Common
{
    public interface IGenericRepository<TEntity>
    {
        IApplicationDbContext Context { get; }

        Task AddAsync(TEntity entity);
        void Add(TEntity entity);
        Task<IEnumerable<TEntity>> GetAsync();
        Task<TEntity> GetAsync(int id);
        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate = default);

    }
}
