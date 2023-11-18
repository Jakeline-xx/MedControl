namespace MedControl.Models
{
    public class Medicamento : Entidade
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }

        //EF Core Relations
        public Estoque Estoque { get; set; }
    }
}
