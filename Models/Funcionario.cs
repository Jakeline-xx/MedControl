namespace MedControl.Models
{
    public class Funcionario : Entidade
    {
        public Guid IdUnidadeTrabalho{ get; set; }
        public string Nome { get; set; }
        public string Cargo { get; set; }
        public string Identificacao { get; set; }
        //EF Core Relations
        public UnidadeTrabalho UnidadeTrabalho { get; set; }
    }
}
