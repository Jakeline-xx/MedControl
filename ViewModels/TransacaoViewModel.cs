using MedControl.Models;
using System.ComponentModel.DataAnnotations;

namespace MedControl.ViewModels
{
    public class TransacaoViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo ID do Estoque é obrigatório")]
        public Guid IdEstoque { get; set; }

        [Required(ErrorMessage = "O campo ID do Funcionário é obrigatório")]
        public Guid IdFuncionario { get; set; }

        [Required(ErrorMessage = "O campo Quantidade é obrigatório")]
        public int Quantidade { get; set; }
        public Estoque Estoque { get; set; }
        public Funcionario Funcionario{ get; set; }

        public DateTime DataTransacao { get; set; }

        // TransacaoViewModel -> Transacao
        public static implicit operator Transacao(TransacaoViewModel viewModel)
        {
            return new Transacao
            {
                Id = viewModel.Id,
                IdEstoque = viewModel.IdEstoque,
                IdFuncionario = viewModel.IdFuncionario,
                Quantidade = viewModel.Quantidade,
                DataTransacao = viewModel.DataTransacao,
                Estoque = viewModel.Estoque,
                Funcionario = viewModel.Funcionario
            };
        }

        // Transacao -> TransacaoViewModel
        public static implicit operator TransacaoViewModel(Transacao transacao)
        {
            return new TransacaoViewModel
            {
                Id = transacao.Id,
                IdEstoque = transacao.IdEstoque,
                IdFuncionario = transacao.IdFuncionario,
                Quantidade = transacao.Quantidade,
                DataTransacao = transacao.DataTransacao,
                Estoque = transacao.Estoque,
                Funcionario = transacao.Funcionario
            };
        }
    }
}
