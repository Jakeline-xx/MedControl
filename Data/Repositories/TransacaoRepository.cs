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

        public async Task<List<Transacao>> ObterTransacaoEstoqueMedicamento()
        {
            return await Db.Transacao
           .AsNoTracking()
           .Include(t => t.Estoque)
           .ThenInclude(e => e.Medicamento)
           .ToListAsync();
        }
    }
}
