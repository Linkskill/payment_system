namespace Customer.API.Domain.DTO.Response
{
    public class CustomerResponseDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public DateTime BirthDate { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
