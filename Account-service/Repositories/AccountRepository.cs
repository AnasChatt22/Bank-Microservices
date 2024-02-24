using account_service.Data;
using account_service.Interfaces;
using account_service.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace account_service.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly DataContext _context;
        private readonly IHttpClientFactory _httpClientFactory;
        private IMapper _mapper;

        public AccountRepository(DataContext context, IHttpClientFactory httpClientFactory, IMapper mapper)
        {
            _context = context;
            _httpClientFactory = httpClientFactory;
            _mapper = mapper;
        }

        public async Task<AccountDto> GetAccount(string id)
        {
            var account = await _context.Accounts.FirstOrDefaultAsync(acc => acc.accountId == id);

            if (account == null)
                return null;
            var httpClient = _httpClientFactory.CreateClient("Customer");
            var response = await httpClient.GetAsync($"api/Customers/{account.customerId}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var customer = JsonConvert.DeserializeObject<Customer>(content);
                account.customer = customer;
            }

            var accountDto = _mapper.Map<AccountDto>(account);
            return accountDto;
        }

        public async Task<List<AccountDto>> GetAccounts()
        {   
            var accounts = await _context.Accounts.OrderBy(cus => cus.customerId).ToListAsync();

            if (accounts == null)
                return null;

            foreach (var account in accounts)
            {
                var httpClient = _httpClientFactory.CreateClient("Customer");
                var response = await httpClient.GetAsync($"api/Customers/{account.customerId}");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var customer = JsonConvert.DeserializeObject<Customer>(content);
                    account.customer = customer;
                }
            }

            var accountsDto = _mapper.Map<List<AccountDto>>(accounts);

            return accountsDto;
        }

        public bool IsAccountExists(string id)
        {
            return _context.Accounts.Any(acc => acc.accountId == id);
        }

        public async Task<List<AccountDto>> GetAccountsByCustomer(long  id)
        {
            var accounts = await _context.Accounts.Where(acc => acc.customerId == id).ToListAsync();

            if (accounts == null)
                return null;

            foreach(var account in accounts)
            {
                var httpClient = _httpClientFactory.CreateClient("Customer");
                var response = await httpClient.GetAsync($"api/Customers/{account.customerId}");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var customer = JsonConvert.DeserializeObject<Customer>(content);
                    account.customer = customer;
                }
            }
            
            var accountsDto = _mapper.Map<List<AccountDto>>(accounts);

            return accountsDto;
        }
    }
}
