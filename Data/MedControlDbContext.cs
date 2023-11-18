using MedControl.Models;
using Microsoft.EntityFrameworkCore;

namespace MedControl.Data
{
    public class MedControlDbContext : DbContext
    {
        public DbSet<Funcionario> Funcionario { get; set; }
        public DbSet<Medicamento> Medicamento{ get; set; }
        public DbSet<Departamento> Departamento{ get; set; }
        public DbSet<Estoque> Estoque { get; set; }
        public DbSet<Transacao> Transacao{ get; set; }
        public DbSet<UnidadeTrabalho> UnidadeTrabalho { get; set; }

        public MedControlDbContext() : base()
        {
            
        }
    }
}
