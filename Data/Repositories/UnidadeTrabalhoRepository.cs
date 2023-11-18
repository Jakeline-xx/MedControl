using MedControl.Data.Contexts;
using MedControl.Data.Repositories.Abstractions;
using MedControl.Models;

namespace MedControl.Data.Repositories
{
    public class UnidadeTrabalhoRepository : Repository<UnidadeTrabalho>, IUnidadeTrabalhoRepository
    {
        public UnidadeTrabalhoRepository(MedControlDbContext db) : base(db)
        {
        }
    }
}
