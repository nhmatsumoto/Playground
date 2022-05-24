namespace Playground.Domain.Entities
{
    public abstract class Entity
    {
        public Guid Id { get; set; }
        public bool Status { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAlteracao { get; set; }

        protected Entity()
        {
            Id = Guid.NewGuid();
        }
    }
}
