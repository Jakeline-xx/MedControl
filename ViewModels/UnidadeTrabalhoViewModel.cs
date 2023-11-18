using MedControl.Models;
using System.ComponentModel.DataAnnotations;

namespace MedControl.ViewModels
{
    public class UnidadeTrabalhoViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo Logradouro é obrigatório.")]
        public string Logradouro { get; set; }

        public static implicit operator UnidadeTrabalho(UnidadeTrabalhoViewModel viewModel)
        {
            return new UnidadeTrabalho
            {
                Nome = viewModel.Nome,
                Logradouro = viewModel.Logradouro
            };
        }
    }
}
