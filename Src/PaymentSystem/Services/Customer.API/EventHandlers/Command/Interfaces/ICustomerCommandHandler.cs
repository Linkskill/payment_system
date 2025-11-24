using Customer.API.Domain.DTO.Request;
using Customer.API.Domain.DTO.Response;

namespace Customer.API.EventHandlers.Command.Interfaces
{
    public interface ICustomerCommandHandler
    {
        Task<CustomerResponseDto> AddClient(CustomerRequestDto customerRequest);
    }
}
