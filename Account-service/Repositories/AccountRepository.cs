using account_service.Data;
using account_service.Interfaces;
using account_service.Models;

namespace account_service.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly DataContext _context;

        public AccountRepository(DataContext context) {
            _context = context;
        }

        public Account GetAccount(string id)
        {
            return _context.Accounts.First<Account>(acc => acc.accountId == id);
        }

        public List<Account> GetAccounts()
        {
            return _context.Accounts.ToList();
        }

        public bool IsAccountExists(string id)
        {
            return _context.Accounts.Any(acc => acc.accountId == id);
        }
    }
}
