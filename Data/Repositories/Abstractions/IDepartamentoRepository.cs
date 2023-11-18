using MedControl.Models;

namespace MedControl.Data.Repositories.Abstractions
{
    public interface IDepartamentoRepository : IRepository<Departamento>
    {
        Task<Departamento> ObterDepartamentoFuncionarios(Guid id);
    }
}
