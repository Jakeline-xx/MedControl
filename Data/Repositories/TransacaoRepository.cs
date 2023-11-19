using MedControl.Data.Contexts;
using MedControl.Data.Repositories.Abstractions;
using MedControl.Models;
using Microsoft.EntityFrameworkCore;

namespace MedControl.Data.Repositories
{
    public class TransacaoRepository : Repository<Transacao>, ITransacaoRepository
    {
        public TransacaoRepository(MedControlDbContext db) : base(db)
        {
        }

        public async Task<List<Transacao>> ObterTransacaoFuncionarioEstoqueMedicamento()
        {
            return await Db.Transacao
           .AsNoTracking()
           .Include(t => t.Funcionario)
           .Include(t => t.Estoque)
           .ThenInclude(e => e.Medicamento)
           .ToListAsync();
        }

        public async void RemoverMultiplos(IEnumerable<Transacao> transacoes)
        {
            foreach (var transacao in transacoes)
                Db.Entry(transacao).State = EntityState.Detached;

            Db.Transacao.RemoveRange(transacoes);
            await SaveChanges();
        }
    }
}
