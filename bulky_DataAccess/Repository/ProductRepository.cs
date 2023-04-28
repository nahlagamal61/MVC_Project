namespace bulky_DataAccess.Repository
{
    using Bulky_Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext context;

        public ProductRepository(ApplicationDbContext _context) : base(_context)
        {
            context = _context;
        }

        public void Update(Product product)
        {
            context.Update(product);
        }
    }
}
