namespace MedControl.Models
{
    public class Funcionario : Entidade
    {
        public Guid IdUnidadeTrabalho { get; set; }
        public Guid IdDepartamento { get; set; }
        public string Nome { get; set; }
        public string Cargo { get; set; }
        public string Identificacao { get; set; }
        public string Telefone { get; set; }
        //EF Core Relations
        public UnidadeTrabalho UnidadeTrabalho { get; set; }
        public Departamento Departamento { get; set; }
        public List<Transacao> Transacoes { get; set; }
    }
}
