namespace MedControl.Models
{
    public class Departamento : Entidade
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }

        //EF Core Relations
        public List<Funcionario> Funcionarios { get; set; }
    }
}
