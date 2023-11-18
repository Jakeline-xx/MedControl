using MedControl.Models;
using System.ComponentModel.DataAnnotations;

namespace MedControl.ViewModels
{
    public class DepartamentoViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo Descrição é obrigatório.")]
        public string Descricao { get; set; }

        //DepartamentoViewModel -> Departamento
        public static implicit operator Departamento(DepartamentoViewModel viewModel)
        {
            return new Departamento
            {
                Id = viewModel.Id,
                Nome = viewModel.Nome,
                Descricao = viewModel.Descricao
            };
        }
        //Departamento -> DepartamentoViewModel
        public static implicit operator DepartamentoViewModel(Departamento departamento)
        {
            return new DepartamentoViewModel
            {
                Id = departamento.Id,
                Nome = departamento.Nome,
                Descricao = departamento.Descricao
            };
        }
    }
}
