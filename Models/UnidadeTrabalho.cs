namespace MedControl.Models
{
    public class UnidadeTrabalho : Entidade
    {
        public string Nome { get; set; }
        public string Logradouro { get; set; }

        //EF Core Relations
        public List<Funcionario> Funcionarios { get; set; }
    }
}
