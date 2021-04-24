using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using MMT.CustomerOrder.Infrastructure.Data;
using MMT.CustomerOrder.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MMT.CustomerOrder.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, IEntity
    {
        internal AppDbContext DbContext;
        public Repository(AppDbContext dbContext)
        {
            DbContext = dbContext;
        }
        public async Task<IEnumerable<T>> GetAllLazyLoadAsync(Expression<Func<T, bool>> predicate ,params Expression<Func<T, object>>[] includeRelatedEntities)
        {
            includeRelatedEntities.ToList().ForEach(x => DbContext.Set<T>().Include(x).Load());
            return await DbContext.Set<T>().Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllLazyLoadAsync(params Expression<Func<T, object>>[] includeRelatedEntities)
        {
            includeRelatedEntities.ToList().ForEach(x => DbContext.Set<T>().Include(x).Load());
            return await DbContext.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllLazyLoadAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null)
        {
            IQueryable<T> queryable =  DbContext.Set<T>().Where(predicate);

            if (includes != null)
            {
                queryable = includes(queryable);
            }

            return await queryable.ToListAsync();
        }

        public async Task<T> GetByIdAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeRelatedEntities)
        {
            includeRelatedEntities.ToList().ForEach(x => DbContext.Set<T>().Include(x).Load());
            return await DbContext.Set<T>().SingleOrDefaultAsync(predicate);
        }
    }
}
