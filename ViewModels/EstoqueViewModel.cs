using MedControl.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace MedControl.ViewModels
{
    public class EstoqueViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "A quantidade disponível é obrigatória")]
        public int QuantidadeDisponivel { get; set; }

        [Required(ErrorMessage = "O ID do Medicamento é obrigatório")]
        public Guid IdMedicamento { get; set; }

        // EstoqueViewModel -> Estoque
        public static implicit operator Estoque(EstoqueViewModel viewModel)
        {
            return new Estoque
            {
                Id = viewModel.Id,
                QuantidadeDisponivel = viewModel.QuantidadeDisponivel,
                IdMedicamento = viewModel.IdMedicamento
            };
        }

        // Estoque -> EstoqueViewModel
        public static implicit operator EstoqueViewModel(Estoque estoque)
        {
            return new EstoqueViewModel
            {
                Id = estoque.Id,
                QuantidadeDisponivel = estoque.QuantidadeDisponivel,
                IdMedicamento = estoque.IdMedicamento
            };
        }
    }
}
