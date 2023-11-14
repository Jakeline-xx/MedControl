using MedControl.Models;
using Microsoft.EntityFrameworkCore;

namespace MedControl.Data
{
    public class MedControlDbContext : DbContext
    {
        public DbSet<Funcionario> Funcionarios { get; set; }

        public MedControlDbContext() : base()
        {
            
        }
    }
}
