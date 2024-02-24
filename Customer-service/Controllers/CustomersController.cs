using account_service.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace account_service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomersController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        // GET: api/Customers
        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            var customers = await _customerRepository.GetCustomersWithAccounts();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(customers);
        }

        // GET api/Customers/id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerByID(long id)
        {
            if (!_customerRepository.IsCustomerExists(id))
                return NotFound();

            var customer = await _customerRepository.GetCustomer(id);

            if (customer == null)
                return NotFound();

            return Ok(customer);
        }

    }
}
