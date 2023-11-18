namespace MedControl.Models
{
    public abstract class Entidade
    {
        public Guid Id { get; set; }
        protected Entidade()
        {
            Id = Guid.NewGuid();
        }
    }
}
