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
    }
}
