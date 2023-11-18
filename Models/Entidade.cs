namespace MedControl.Models
{
    public abstract class Entidade
    {
        protected Guid Id { get; set; }
        protected Entidade()
        {
            Id = Guid.NewGuid();
        }
    }
}
