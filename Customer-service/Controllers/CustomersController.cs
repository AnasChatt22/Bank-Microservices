using customer_service.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace customer_service.Controllers
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
        public IActionResult GetCustomers()
        {
            var customers = _customerRepository.GetCustomers();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(customers);
        }

        // GET api/Customers/id
        [HttpGet("{id}")]
        public IActionResult GetCustomerByID(long id)
        {
            if (!_customerRepository.IsCustomerExists(id))
                return NotFound();

            var customer = _customerRepository.GetCustomer(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(customer);
        }
        
    }
}
