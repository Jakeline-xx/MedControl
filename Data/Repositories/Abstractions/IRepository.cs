using MedControl.Models;
using System.Linq.Expressions;

namespace MedControl.Data.Repositories.Abstractions
{
    public interface IRepository<TEntidade> : IDisposable where TEntidade : Entidade
    {
        Task Adicionar(TEntidade entidade);
        Task<TEntidade> ObterPorId(Guid id);
        Task<List<TEntidade>> ObterTodos();
        Task Atualizar(TEntidade entidade);
        Task Remover(Guid id);
        Task<IEnumerable<TEntidade>> Buscar(Expression<Func<TEntidade, bool>> predicate);
        Task<int> SaveChanges();
    }
}
