namespace bulky_DataAccess.Repository
{
    using Bulky_Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface ICategoryRepository : IRepository<Category>
    {
        void Update(Category category);

    }
}
