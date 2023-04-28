namespace bulky_DataAccess.Repository
{
    using Microsoft.EntityFrameworkCore.Migrations.Operations;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext context;

        public  CategoryRepository category { get; private set; }
        public ProductRepository product { get; private set; }
        public UnitOfWork(ApplicationDbContext _context)
        {
            context = _context;
            category = new CategoryRepository(context);
            product = new ProductRepository(context);
        }


        public void save()
        {
           context.SaveChanges();
        }
    }
}
