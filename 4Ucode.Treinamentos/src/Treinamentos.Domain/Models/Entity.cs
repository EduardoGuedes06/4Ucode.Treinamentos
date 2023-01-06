namespace Domain.Models
{
    public abstract class Entity
    {
        protected Entity()
        {
            Id = Guid.NewGuid();

            DataCadastro = DateTime.Now;

        }


        public DateTime DataCadastro { get; set; }
        public Guid Id { get; set; }
    }
}
