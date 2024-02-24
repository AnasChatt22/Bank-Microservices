using customer_service.Data;
using customer_service.Interfaces;
using customer_service.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace customer_service.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        public readonly DataContext _context;
        private readonly IHttpClientFactory _httpClientFactory;
        public CustomerRepository(DataContext context, IHttpClientFactory httpClientFactory)
        {
            _context = context;
            _httpClientFactory = httpClientFactory;
        }
        public async Task<Customer> GetCustomer(long id)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(cus => cus.id == id);

            if (customer == null)
                return null;
            var httpClient = _httpClientFactory.CreateClient("Account");
            var response = await httpClient.GetAsync($"api/Accounts/byCustomer/{id}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var accounts = JsonConvert.DeserializeObject<List<AccountDto>>(content);
                customer.accounts = accounts;
            }
            
            return customer;
        }

        public async Task<List<Customer>> GetCustomersWithAccounts()
        {
            var customers = await _context.Customers.OrderBy(cus => cus.id).ToListAsync();
            if (customers == null)
                return null;

            foreach (var customer in customers)
            {
                var httpClient = _httpClientFactory.CreateClient("Account");
                var response = await httpClient.GetAsync($"api/Accounts/byCustomer/{customer.id}");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var accounts = JsonConvert.DeserializeObject<List<AccountDto>>(content);
                    customer.accounts = accounts;
                }
            }

            return customers;
        }


        public bool IsCustomerExists(long id)
        {
            return _context.Customers.Any(cus => cus.id == id);
        }
    }
}
