namespace MedControl.Models
{
    public class Funcionario
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }

        public Funcionario()
        {
            Id = Guid.NewGuid();
        }

    }
}
