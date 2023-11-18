using MedControl.Models;

namespace MedControl.Data.Repositories.Abstractions
{
    public interface IUnidadeTrabalhoRepository : IRepository<UnidadeTrabalho>
    {
        Task<UnidadeTrabalho> ObterUnidadeTrabalhoFuncionarios(Guid id);
    }
}
