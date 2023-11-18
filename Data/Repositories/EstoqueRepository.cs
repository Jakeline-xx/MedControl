using MedControl.Data.Contexts;
using MedControl.Data.Repositories.Abstractions;
using MedControl.Models;

namespace MedControl.Data.Repositories
{
    public class EstoqueRepository : Repository<Estoque>, IEstoqueRepository
    {
        public EstoqueRepository(MedControlDbContext db) : base(db)
        {
        }
    }
}
