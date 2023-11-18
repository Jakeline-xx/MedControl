using MedControl.Data.Contexts;
using MedControl.Data.Repositories.Abstractions;
using MedControl.Models;

namespace MedControl.Data.Repositories
{
    public class DepartamentoRepository : Repository<Departamento>, IDepartamentoRepository
    {
        public DepartamentoRepository(MedControlDbContext db) : base(db)
        {
        }
    }
}
