using account_service.Interfaces;
using account_service.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace account_service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : Controller
    {
        private readonly IAccountRepository _accountRepository;
        private readonly HttpClient _httpClient;

        public AccountsController(IAccountRepository accountRepository, HttpClient httpClient)
        {
            _accountRepository = accountRepository;
            _httpClient = httpClient;
        }

        // GET: api/<AccountsController>
        [HttpGet]
        public async Task<IActionResult> GetAccounts()
        {
            // Assuming you want to retrieve customer information for each account
            var accounts = _accountRepository.GetAccounts();
            foreach (var account in accounts)
            {
                var customerId = account.customerId;
                var response = await _httpClient.GetAsync($"https://localhost:8080/api/customers/{customerId}");
                if (!response.IsSuccessStatusCode)
                {
                    return BadRequest(); // Handle error appropriately
                }
                var customerData = await _httpClient.GetFromJsonAsync<Customer>($"https://localhost:8080/api/customers/{customerId}"); // Assuming Customer class exists
                account.customer = customerData;
            }
            return Ok(accounts);
        }

        // GET api/<AccountsController>/5
        [HttpGet("{id}")]
        public IActionResult GetAccount(string id)
        {   
            if (!_accountRepository.IsAccountExists(id))
            {
                return NotFound();
            }

            var account = _accountRepository.GetAccount(id);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(account);
        }

        [HttpGet("byCustomer/{id}")]
        public IActionResult GetAccountsByCustomer(long id)
        {
            var accounts = _accountRepository.GetAccountsByCustomer(id);
            if (accounts.Count == 0)
            {
                return NotFound($"No accounts found for customer with ID {id}");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(accounts);
        }


    }
}
