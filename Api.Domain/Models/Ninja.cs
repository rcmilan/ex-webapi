namespace Api.Domain.Models
{
    public class Ninja : BaseModel<int>
    {
        public string Cla { get; set; }

        public string Nome { get; set; }
    }
}
