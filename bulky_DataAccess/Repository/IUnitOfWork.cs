namespace bulky_DataAccess.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IUnitOfWork
    {
        public CategoryRepository category { get; }
        public ProductRepository product { get; }
        
        void save();
    }
}
