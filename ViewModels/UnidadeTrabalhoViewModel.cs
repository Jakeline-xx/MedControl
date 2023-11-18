using MedControl.Models;
using System.ComponentModel.DataAnnotations;

namespace MedControl.ViewModels
{
    public class UnidadeTrabalhoViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo Logradouro é obrigatório.")]
        public string Logradouro { get; set; }

        //UnidadeTrabalhoViewModel -> UnidadeTrabalho
        public static implicit operator UnidadeTrabalho(UnidadeTrabalhoViewModel viewModel)
        {
            return new UnidadeTrabalho
            {
                Id = viewModel.Id,
                Nome = viewModel.Nome,
                Logradouro = viewModel.Logradouro
            };
        }
        //UnidadeTrabalho -> UnidadeTrabalhoViewModel
        public static implicit operator UnidadeTrabalhoViewModel(UnidadeTrabalho unidadeTrabalho)
        {
            return new UnidadeTrabalhoViewModel
            {
                Id = unidadeTrabalho.Id,
                Nome = unidadeTrabalho.Nome,
                Logradouro = unidadeTrabalho.Logradouro
            };
        }
    }
}
