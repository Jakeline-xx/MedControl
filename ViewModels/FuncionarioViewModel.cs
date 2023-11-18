using MedControl.Models;
using System.ComponentModel.DataAnnotations;

namespace MedControl.ViewModels
{
    public class FuncionarioViewModel
    {

        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo Cargo é obrigatório")]
        public string Cargo { get; set; }

        [Required(ErrorMessage = "O campo Identificação é obrigatório")]
        public string Identificacao { get; set; }

        [Phone(ErrorMessage = "O campo Telefone não é um número de telefone válido")]
        public string Telefone { get; set; }

        public static implicit operator Funcionario(FuncionarioViewModel viewModel)
        {
            return new Funcionario
            {
                Nome = viewModel.Nome,
                Cargo = viewModel.Cargo,
                Identificacao = viewModel.Identificacao,
                Telefone = viewModel.Telefone
            };
        }
    }
}