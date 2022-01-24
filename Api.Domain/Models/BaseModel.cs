namespace Api.Domain.Models
{
    public abstract class BaseModel<T>
    {
        public BaseModel()
        {
            CreatedAt = DateTime.Now;
        }

        public T ID { get; set; } = default!;
        public DateTime CreatedAt { get; private set; }
        public bool IsActive { get; set; }
    }
}
