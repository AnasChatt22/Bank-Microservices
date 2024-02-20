using customer_service.Models;

namespace customer_service.Interfaces
{
    public interface ICustomerRepository
    {
        List<Customer> GetCustomers();
        Customer GetCustomer(long id);
        bool IsCustomerExists(long id);

    }
}
