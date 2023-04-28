namespace bulky_DataAccess.Repository
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext context;
        internal DbSet<T> dbSet;
         public Repository(ApplicationDbContext _context)
        {
            context = _context;
            dbSet = context.Set<T>();
            context.Products.Include(p => p.Category);


        }
        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public T Delete(T entity)
        {
            dbSet.Remove(entity);
            return entity;
        }

        public IEnumerable<T> DeleteRange(IEnumerable<T> entities)
        {
            dbSet.RemoveRange(entities);
            return entities;
        }

        public T? Get(Expression<Func<T, bool>> filter, string? IncludeProperties = null)
        {
            IQueryable<T> query = dbSet;
            if (IncludeProperties != null)
            {

                foreach (var prop in IncludeProperties
                    .Split(new Char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(prop);
                }
            }
            query = query.Where(filter);
            return query.FirstOrDefault();
        }

        public IEnumerable<T> GetAll(string? IncludeProperties = null)
        {
            IQueryable<T> query = dbSet;
            if(IncludeProperties != null)
            {

                foreach(var prop in IncludeProperties
                    .Split(new Char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(prop);
                }
            }
            return query.ToList();
        }

    }
}
