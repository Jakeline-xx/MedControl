using MedControl.Models;

namespace MedControl.Data.Repositories.Abstractions
{
    public interface ITransacaoRepository : IRepository<Transacao>
    {
        Task<List<Transacao>> ObterTransacaoEstoqueMedicamento();
    }
}
