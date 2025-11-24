namespace Customer.API.Domain.DTO.Request
{
    public class CustomerRequestDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public DateTime BirthDate { get; set; }

    }
}
