using customer_service.Data;
using customer_service.Interfaces;
using customer_service.Models;
using Microsoft.EntityFrameworkCore;

namespace customer_service.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        public readonly DataContext _context;
        public CustomerRepository(DataContext context)
        {

            _context = context;

        }
        public Customer GetCustomer(long id)
        {
            return _context.Customers.First<Customer>(cus => cus.id == id);
        }

        public List<Customer> GetCustomers()
        {
            return _context.Customers.OrderBy(cus => cus.id).ToList();
        }

        public bool IsCustomerExists(long id)
        {
            return _context.Customers.Any(cus => cus.id == id);
        }
    }
}
