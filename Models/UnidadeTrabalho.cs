namespace MedControl.Models
{
    public class UnidadeTrabalho : Entidade
    {
        public Guid IdFuncionario { get; set; }
        public string Nome { get; set; }
        public string Logradouro { get; set; }

        //EF Core Relations
        public Funcionario Funcionario { get; set; }
    }
}
