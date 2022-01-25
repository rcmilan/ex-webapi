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

        public User(Guid id, string name, string email) : this(id)
        {
            Name = name;
            Email = email;
        }

        public string Name { get; set; } = default!;
        public string Email { get; set; } = default!;
    }
}