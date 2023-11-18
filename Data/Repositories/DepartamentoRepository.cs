using MedControl.Data.Contexts;
using MedControl.Data.Repositories.Abstractions;
using MedControl.Models;
using Microsoft.EntityFrameworkCore;

namespace MedControl.Data.Repositories
{
    public class DepartamentoRepository : Repository<Departamento>, IDepartamentoRepository
    {
        public DepartamentoRepository(MedControlDbContext db) : base(db)
        {
        }

        public async Task<Departamento> ObterDepartamentoFuncionarios(Guid id)
        {
            return await Db.Departamento.AsNoTracking()
                  .Include(c => c.Funcionarios)
                  .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
