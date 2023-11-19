using MedControl.Data.Contexts;
using MedControl.Data.Repositories.Abstractions;
using MedControl.Models;
using Microsoft.EntityFrameworkCore;

namespace MedControl.Data.Repositories
{
    public class EstoqueRepository : Repository<Estoque>, IEstoqueRepository
    {
        public EstoqueRepository(MedControlDbContext db) : base(db)
        {
        }
        public async Task<List<Estoque>> ObterEstoqueMedicamentos()
        {
            return await Db.Estoque.AsNoTracking()
                                       .Include(c => c.Medicamento)
                                       .ToListAsync();
        }
    }
}
