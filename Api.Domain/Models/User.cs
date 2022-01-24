namespace Api.Domain.Models
{
    public class User : BaseModel<Guid>
    {
        public string Name { get; set; } = default!;
        public string Email { get; set; } = default!;
    }
}