using customer_service.Models;

namespace customer_service.Interfaces
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetCustomersWithAccounts();
        Task<Customer> GetCustomer(long id);
        bool IsCustomerExists(long id);

    }
}
