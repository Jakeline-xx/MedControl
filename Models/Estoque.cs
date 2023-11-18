namespace MedControl.Models
{
    public class Estoque : Entidade
    {
        public int QuantidadeDisponivel { get; set; }
        public Guid IdMedicamento { get; set; }

        //EF Core Relations
        public Medicamento Medicamento { get; set; }
        public List<Transacao> Transacoes { get; set; }
    }
}
