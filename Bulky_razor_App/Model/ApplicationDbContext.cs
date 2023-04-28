namespace Bulky_razor_App
{
    using Bulky_razor_App.Model;
    using Microsoft.EntityFrameworkCore;

    public class ApplicationDbContext :DbContext
    {
        //public ApplicationDbContext()
        //{
            
        //}
        public ApplicationDbContext( DbContextOptions<ApplicationDbContext> options): base(options)
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category {Id=1 , Name="Cat 1" , CategoryOrder=1 },
                new Category {Id=2 , Name="Cat 2" , CategoryOrder=2 },
                new Category {Id=3 , Name="Cat 3" , CategoryOrder=3 },
                new Category {Id=4 , Name="Cat 4" , CategoryOrder=4 },
                new Category {Id=5 , Name="Cat 5" , CategoryOrder=5 },
                new Category {Id=6 , Name="Cat 6" , CategoryOrder=6 }
                );

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Category> Categories { get; set; }
    }
}
