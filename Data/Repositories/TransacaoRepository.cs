using MedControl.Data.Contexts;
using MedControl.Data.Repositories.Abstractions;
using MedControl.Models;

namespace MedControl.Data.Repositories
{
    public class TransacaoRepository : Repository<Transacao>, ITransacaoRepository
    {
        public TransacaoRepository(MedControlDbContext db) : base(db)
        {
        }
    }
}
