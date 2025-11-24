using Customer.API.Domain.DTO.Response;

namespace Customer.API.EventHandlers.Query.Interfaces
{
    public interface ICustomerQueryHandler
    {
        Task<CustomerResponseDto?> GetByIdAsync(int Id);
        Task<List<CustomerResponseDto>> GetAllAsync();
    }
}
