using MedControl.Data.Repositories.Abstractions;

namespace MedControl.ViewModels
{
    public class RelatorioAnaliticoViewModel
    {
        public int QtdFuncionarios { get; set; }
        public int QtdDepartamentos { get; set; }
        public int QtdMedicamentos { get; set; }
        public int QtdTransacoes { get; set; }
        public int QtdUnidadeTrabalho { get; set; }
    }
}
