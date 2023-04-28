namespace bulky_DataAccess.Repository
{
    using Bulky_Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Text;
    using System.Threading.Tasks;

    public interface IRepository<T> where T: class
    {
        IEnumerable<T> GetAll(string? IncludeProperties = null);
        public T? Get(Expression<Func<T, bool>> filter, string? IncludeProperties = null);
        void Add(T entity);
        T Delete(T entity);
        IEnumerable<T> DeleteRange(IEnumerable<T> entities);
             
    }
}
