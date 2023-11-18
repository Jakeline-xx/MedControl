using MedControl.Data.Contexts;
using MedControl.Data.Repositories.Abstractions;
using MedControl.Models;
using Microsoft.EntityFrameworkCore;

namespace MedControl.Data.Repositories
{
    public class UnidadeTrabalhoRepository : Repository<UnidadeTrabalho>, IUnidadeTrabalhoRepository
    {
        public UnidadeTrabalhoRepository(MedControlDbContext db) : base(db)
        { }

        public async Task<UnidadeTrabalho> ObterUnidadeTrabalhoFuncionarios(Guid id)
        {
            return await Db.UnidadeTrabalho.AsNoTracking()
                  .Include(c => c.Funcionarios)
                  .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
