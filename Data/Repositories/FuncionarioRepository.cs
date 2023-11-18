using MedControl.Data.Contexts;
using MedControl.Data.Repositories.Abstractions;
using MedControl.Models;

namespace MedControl.Data.Repositories
{
    public class FuncionarioRepository : Repository<Funcionario>, IFuncionarioRepository
    {
        public FuncionarioRepository(MedControlDbContext db) : base(db)
        {
        }
    }
}
