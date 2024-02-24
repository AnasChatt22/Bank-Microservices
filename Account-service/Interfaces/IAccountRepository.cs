using account_service.Models;

namespace account_service.Interfaces
{
    public interface IAccountRepository
    {
        Task<List<AccountDto>> GetAccounts();
        Task<AccountDto> GetAccount(string id);
        bool IsAccountExists(string id);
        Task<List<AccountDto>> GetAccountsByCustomer(long id);
    }
}
