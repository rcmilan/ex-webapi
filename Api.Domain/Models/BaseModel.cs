namespace Api.Domain.Models
{
    public abstract class BaseModel<TID>
    {
        public BaseModel()
        {
            CreatedAt = DateTime.Now;
        }

        public BaseModel(TID id) : this()
        {
            ID = id;
            IsActive = true;
        }

        public TID ID { get; set; } = default!;
        public DateTime CreatedAt { get; private set; }
        public bool IsActive { get; set; }
    }
}
