using customer_service.Models;
using Microsoft.EntityFrameworkCore;

namespace customer_service.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    id = 1,
                    firstname = "Anas",
                    lastname = "Chatt",
                    email = "chattanas22@gmail.com"
                }
            );
            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    id = 2,
                    firstname = "Aimane",
                    lastname = "Chanaa",
                    email = "aimane99@gmail.com"
                }
            );
        }
    }
}
