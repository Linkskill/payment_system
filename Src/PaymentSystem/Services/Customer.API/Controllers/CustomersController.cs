using Customer.API.Domain.DTO.Request;
using Customer.API.EventHandlers.Command.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Customer.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ILogger<CustomersController> _logger;
        private readonly ICustomerCommandHandler _customerCommandHandler;

        public CustomersController(ILogger<CustomersController> logger, ICustomerCommandHandler customerCommandHandler)
        {
            _logger = logger;
            _customerCommandHandler = customerCommandHandler;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = "Lista de usuarios";

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CustomerRequestDto customerRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var customerResponse = await _customerCommandHandler.AddClient(customerRequest);

            return Ok(customerResponse);
        }
    }
}
