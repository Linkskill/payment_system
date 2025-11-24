using Customer.API.Domain.DTO.Request;
using Customer.API.Domain.DTO.Response;
using Customer.API.Domain.Mappers;
using Customer.API.EventHandlers.Command.Interfaces;
using Customer.API.Infrastructure.Data;

namespace Customer.API.EventHandlers.Command
{
    public class CustomerCommandHandler : ICustomerCommandHandler
    {
        private readonly AppDbContext _dbContext;

        public CustomerCommandHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CustomerResponseDto> AddClient(CustomerRequestDto customerRequest)
        {
            var client = customerRequest.ToClientFromCommand();

            await _dbContext.Clients.AddAsync(client);
            await _dbContext.SaveChangesAsync();
            
            return client.ToCustomerResponseFromCommand();
        }

    }
}
