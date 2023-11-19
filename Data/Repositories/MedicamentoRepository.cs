using MedControl.Data.Contexts;
using MedControl.Data.Repositories.Abstractions;
using MedControl.Models;
using Microsoft.EntityFrameworkCore;

namespace MedControl.Data.Repositories
{
    public class MedicamentoRepository : Repository<Medicamento>, IMedicamentoRepository
    {
        public MedicamentoRepository(MedControlDbContext db) : base(db)
        {
        }

        public async Task<Medicamento> ObterMedicamentoEstoque(Guid id)
        {

            return await Db.Medicamento.AsNoTracking()
                           .Include(c => c.Estoque)
                           .SingleOrDefaultAsync(x => x.Id == id);
        }
    }
}