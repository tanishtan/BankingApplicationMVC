using Microsoft.EntityFrameworkCore;

namespace BankingApplicationMVC.Models
{
    public class Bank
    {
        public class ProductsDbContextcs : DbContext
        {
            public DbSet<Bank> Banks { get; set; }

            public ProductsDbContextcs(DbContextOptions<ProductsDbContextcs> options) : base(options) { }
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer(
                    connectionString: @"server=(local);database=Banking;integrated security=sspi;trustservercertificate=true"
                    );
            }
        }
    }
}
