using MedControl.Models;
using System.ComponentModel.DataAnnotations;

namespace MedControl.ViewModels
{
    public class MedicamentoViewModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo Descricao é obrigatório")]
        public string Descricao { get; set; }


        //MedicamentoViewModel -> Medicamento
        public static implicit operator Medicamento(MedicamentoViewModel viewModel)
        {
            return new Medicamento
            {
                Id = viewModel.Id,
                Nome = viewModel.Nome,
                Descricao = viewModel.Descricao
            };
        }
        //Medicamento -> MedicamentoViewModel
        public static implicit operator MedicamentoViewModel(Medicamento medicamento)
        {
            return new MedicamentoViewModel
            {
                Id = medicamento.Id,
                Nome = medicamento.Nome,
                Descricao = medicamento.Descricao
            };
        }

    }
}
