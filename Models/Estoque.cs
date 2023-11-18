namespace MedControl.Models
{
    public class Estoque : Entidade
    {
        public Guid IdMedicamento{ get; set; }
        public int QuantidadeDisponivel{ get; set; }

        //EF Core Relations
        public Medicamento Medicamento { get; set; }
        public List<Transacao> Transacoes{ get; set; }
    }
}
