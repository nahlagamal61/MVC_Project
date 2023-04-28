namespace bulky_DataAccess.Repository
{
    using Bulky_Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext context;

        public CategoryRepository(ApplicationDbContext _context) : base(_context)
        {
            context = _context;
        }

  

        public void Update(Category category)
        {
            context.Update(category);
        }
    }
}
