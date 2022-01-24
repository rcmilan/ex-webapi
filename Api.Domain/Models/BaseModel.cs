namespace Api.Domain.Models
{
    public abstract class BaseModel<T>
    {
        public BaseModel()
        {
            CreatedAt = DateTime.Now;
        }

        public BaseModel(T id) : this()
        {
            ID = id;
            IsActive = true;
        }

        public T ID { get; set; } = default!;
        public DateTime CreatedAt { get; private set; }
        public bool IsActive { get; set; }
    }
}
