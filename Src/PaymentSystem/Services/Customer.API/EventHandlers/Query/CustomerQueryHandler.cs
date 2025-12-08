using Customer.API.Domain.DTO.Response;
using Customer.API.Domain.Mappers;
using Customer.API.EventHandlers.Query.Interfaces;
using Customer.API.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Customer.API.EventHandlers.Query
{
    public class CustomerQueryHandler : ICustomerQueryHandler
    {
        // TODO: Create new dbContext with read permission (to only read entries)
        private readonly AppDbContext _dbContext;

        public CustomerQueryHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CustomerResponseDto?> GetByIdAsync(int Id)
        {
            var clientModel = await _dbContext.Clients.FirstOrDefaultAsync(c => c.Id == Id);
            var customerResponse = clientModel?.ToCustomerResponse();

            return customerResponse;
        }

        public async Task<List<CustomerResponseDto>> GetAllAsync()
        {
            var clientQueryable = _dbContext.Clients.AsQueryable();

            var customerResponseList = await clientQueryable.Select(c => c.ToCustomerResponse()).ToListAsync();

            return customerResponseList;
        }
    }
}
