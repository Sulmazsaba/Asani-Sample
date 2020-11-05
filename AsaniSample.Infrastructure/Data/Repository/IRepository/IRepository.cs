using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AsaniSample.Infrastructure.Data.Repository.IRepository
{
   public interface IRepository<T> where T:class
   {
       T Get(Guid id);

       IEnumerable<T> Get(Expression<Func<T, bool>> filter = null, 
           Func<IQueryable<T>,IOrderedQueryable<T>> orderBy =null, 
           string includeProperties = null
       );

       T GetFirstOrDefault(Expression<Func<T,bool>> filter=null,
           string includeProperties=null
           );

       void Add(T entity);

       void Remove(Guid id);

       void Remove(T entity);

       void Update(T entity);
   }
}
