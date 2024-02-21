using account_service.Models;

namespace account_service.Interfaces
{
    public interface IAccountRepository
    {
        List<Account> GetAccounts();
        Account GetAccount(string id);
        bool IsAccountExists(string id);
    }
}
