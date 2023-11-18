using System.ComponentModel.DataAnnotations;

namespace MedControl.ViewModels
{
    public class FuncionarioViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo Cargo é obrigatório")]
        public string Cargo { get; set; }

        [Required(ErrorMessage = "O campo Identificação é obrigatório")]
        public string Identificacao { get; set; }

        [Phone(ErrorMessage = "O campo Telefone não é um número de telefone válido")]
        public string Telefone { get; set; }
    }
}