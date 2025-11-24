using Customer.API.Domain.DTO.Request;
using Customer.API.Domain.DTO.Response;
using Customer.API.Infrastructure.Models;

namespace Customer.API.Domain.Mappers
{
    public static class CustomerMapper
    {
        public static Client ToClientFromCommand(this CustomerRequestDto customerRequest)
        {
            return new Client
            {
                Name = customerRequest.Name,
                Email = customerRequest.Email,
                CPF = customerRequest.CPF,
                BirthDate = customerRequest.BirthDate,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
            };
        }

        public static CustomerResponseDto ToCustomerResponseFromCommand(this Client client)
        {
            return new CustomerResponseDto
            {
                Name = client.Name,
                Email = client.Email,
                CPF = client.CPF,
                BirthDate = client.BirthDate,
                CreatedAt = client.CreatedAt,
                UpdatedAt = client.UpdatedAt,
            };
        }
    }
}
