using Customer.API.Domain.DTO.Request;
using Customer.API.EventHandlers.Command.Interfaces;
using Customer.API.EventHandlers.Query.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Customer.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ILogger<CustomersController> _logger;
        private readonly ICustomerCommandHandler _customerCommandHandler;
        private readonly ICustomerQueryHandler _customerQueryHandler;

        public CustomersController(ILogger<CustomersController> logger,
            ICustomerCommandHandler customerCommandHandler, ICustomerQueryHandler customerQueryHandler)
        {
            _logger = logger;
            _customerCommandHandler = customerCommandHandler;
            _customerQueryHandler = customerQueryHandler;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var customerResponse = await _customerQueryHandler.GetByIdAsync(id);

            if (customerResponse == null)
                return NotFound();

            return Ok(customerResponse);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _customerQueryHandler.GetAllAsync();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CustomerRequestDto customerRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var customerResponse = await _customerCommandHandler.AddClient(customerRequest);

            return CreatedAtAction(nameof(GetById), new { id = customerResponse.Id }, customerResponse);
        }
    }
}
