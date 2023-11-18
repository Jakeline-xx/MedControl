using MedControl.Models;
using System.ComponentModel.DataAnnotations;

namespace MedControl.ViewModels
{
    public class FuncionarioViewModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo Cargo é obrigatório")]
        public string Cargo { get; set; }

        [Required(ErrorMessage = "O campo Identificação é obrigatório")]
        public string Identificacao { get; set; }

        [Phone(ErrorMessage = "O campo Telefone não é um número de telefone válido")]
        public string Telefone { get; set; }

        //FuncionarioViewModel -> Funcionario
        public static implicit operator Funcionario(FuncionarioViewModel viewModel)
        {
            return new Funcionario
            {
                Id = viewModel.Id,
                Nome = viewModel.Nome,
                Cargo = viewModel.Cargo,
                Identificacao = viewModel.Identificacao,
                Telefone = viewModel.Telefone
            };
        }
        //Funcionario -> FuncionarioViewModel
        public static implicit operator FuncionarioViewModel(Funcionario funcionario)
        {
            return new FuncionarioViewModel
            {
                Id = funcionario.Id,
                Nome = funcionario.Nome,
                Cargo = funcionario.Cargo,
                Identificacao = funcionario.Identificacao,
                Telefone = funcionario.Telefone
            };
        }
    }
}