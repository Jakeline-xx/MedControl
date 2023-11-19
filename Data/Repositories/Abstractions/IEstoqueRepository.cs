using MedControl.Models;

namespace MedControl.Data.Repositories.Abstractions
{
    public interface IEstoqueRepository : IRepository<Estoque>
    {
        Task<List<Estoque>> ObterEstoqueMedicamentos();
    }
}
