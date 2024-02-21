using account_service.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace account_service.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Account> Accounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Account>().HasData(
            new Account
                {
                    accountId = "A1",
                    balance = 12,
                    createdAt = DateTime.UtcNow,
                    currency = "DHs",
                    accountType = AccountType.CURRENT_ACCOUNT.ToString(),
                    customerId = 1
            }
            );
            modelBuilder.Entity<Account>().HasData(
                new Account
                {
                    accountId = "A2",
                    balance = 14,
                    createdAt = DateTime.UtcNow,
                    currency = "Dollar",
                    accountType = AccountType.SAVING_ACCOUNT.ToString(),
                    customerId = 2
                }
            );
        }
    }
}
