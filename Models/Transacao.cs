namespace MedControl.Models
{
    public class Transacao : Entidade
    {
        public DateTime DataTransacao { get; set; }
        public Guid IdEstoque { get; set; }
        public Guid IdFuncionario{ get; set; }
        public int Quantidade { get; set; }

        //EF Core Relations
        public Estoque Estoque { get; set; }
        public Funcionario Funcionario { get; set; }
    }
}
