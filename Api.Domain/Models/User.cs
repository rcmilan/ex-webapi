namespace Api.Domain.Models
{
    public class User : BaseModel<Guid>
    {
        public User() : base()
        {

        }

        public User(Guid id) : base(id)
        {

        }

        public string Name { get; set; } = default!;
        public string Email { get; set; } = default!;
    }
}