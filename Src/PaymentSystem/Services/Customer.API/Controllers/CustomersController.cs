using Customer.API.Domain.DTO.Request;
using Customer.API.Domain.DTO.Response;
using Microsoft.AspNetCore.Mvc;

namespace Customer.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ILogger<CustomersController> _logger;

        public CustomersController(ILogger<CustomersController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = "Lista de usuarios";

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Post([FromBody] CustomerRequestDto customerRequest)
        {
            var customerResponse = new CustomerResponseDto();

            return Ok(customerResponse);
        }
    }
}
