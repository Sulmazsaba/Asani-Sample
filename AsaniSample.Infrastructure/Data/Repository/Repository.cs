using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AsaniSample.Infrastructure.Data.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace AsaniSample.Infrastructure.Data.Repository
{
   public class Repository<T> : IRepository<T> where T : class
   {
       protected readonly AsaniSampleContext context;
       internal DbSet<T> dbSet;

       public Repository(AsaniSampleContext context)
       {
           this.context = context;
           this.dbSet = context.Set<T>();
       }

       public T Get(Guid id)
       {
           if(id==Guid.Empty)
               throw new ArgumentNullException(nameof(T));
          return dbSet.Find(id);
       }

        public IEnumerable<T> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = null)
        {
            IQueryable<T> query = dbSet;
            if (filter != null)
               query= dbSet.Where(filter);


            if (!string.IsNullOrEmpty(includeProperties))
            {
                var includePropertyCharacters =
                    includeProperties.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries);
                foreach (var property in includePropertyCharacters)
                {
                    query = query.Include(property);
                }
            }

            if (orderBy != null)
                return orderBy(query).ToList();

            return query.ToList();
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter = null, string includeProperties = null)
        {
            IQueryable<T> query = dbSet;

            if (filter!=null)
            {
                query = dbSet.Where(filter);
            }

            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var property in includeProperties.Split(new char[]{','},StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(property);
                }
            }

            return query.FirstOrDefault();
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public void Remove(Guid id)
        {
            var entityToRemove = dbSet.Find(id);
            dbSet.Remove(entityToRemove);
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void Update(T entity)
        {
           
        }
    }
}
