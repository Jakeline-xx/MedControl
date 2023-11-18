namespace MedControl.Models
{
    public class Transacao : Entidade
    {
        public Guid IdEstoque { get; set; }
        public Guid IdFuncionario{ get; set; }
        public int Quantidade { get; set; }
        public DateTime DataTransacao { get; set; }

        //EF Core Relations
        public Estoque Estoque { get; set; }
        public Funcionario Funcionario { get; set; }
    }
}
