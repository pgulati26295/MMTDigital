using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MMT.CustomerOrder.SharedKernel.Interfaces
{
   public interface IRepository<T> where T: IEntity
    {
         Task<IEnumerable<T>> GetAllLazyLoadAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null);
        Task<IEnumerable<T>> GetAllLazyLoadAsync( params Expression<Func<T, object>>[] includeRelatedEntities);
        Task<IEnumerable<T>> GetAllLazyLoadAsync(Expression<Func<T, bool>> predicate ,params Expression<Func<T, object>>[] includeRelatedEntities);
        Task<T> GetByIdAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeRelatedEntities);

    }
}
