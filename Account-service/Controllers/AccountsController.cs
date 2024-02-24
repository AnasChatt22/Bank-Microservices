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

            var accounts = await _accountRepository.GetAccounts();
            if ( !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(accounts);

        }

        // GET api/<AccountsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAccount(string id)
        {   
            if (!_accountRepository.IsAccountExists(id))
            {
                return NotFound();
            }

            var account = await _accountRepository.GetAccount(id);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(account);
        }

        [HttpGet("byCustomer/{id}")]
        public async Task<IActionResult> GetAccountsByCustomer(long id)
        {
            var accounts = await _accountRepository.GetAccountsByCustomer(id);
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
