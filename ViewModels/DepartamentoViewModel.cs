using MedControl.Models;
using System.ComponentModel.DataAnnotations;

namespace MedControl.ViewModels
{
    public class DepartamentoViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo Descrição é obrigatório.")]
        public string Descricao { get; set; }

        public static implicit operator Departamento(DepartamentoViewModel viewModel)
        {
            return new Departamento
            {
                Nome = viewModel.Nome,
                Descricao = viewModel.Descricao
            };
        }
    }
}
