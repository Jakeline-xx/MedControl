using MedControl.Models;

namespace MedControl.Data.Repositories.Abstractions
{
    public interface IMedicamentoRepository : IRepository<Medicamento>
    {
        Task<Medicamento> ObterMedicamentoEstoque(Guid id);
    }
}
