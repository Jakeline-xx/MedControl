using MedControl.Models;
using Microsoft.EntityFrameworkCore;

namespace MedControl.Data.Contexts
{
    public class MedControlDbContext : DbContext
    {
        public MedControlDbContext(DbContextOptions<MedControlDbContext> options) : base(options)
        { }
        public DbSet<Funcionario> Funcionario { get; set; }
        public DbSet<Medicamento> Medicamento { get; set; }
        public DbSet<Departamento> Departamento { get; set; }
        public DbSet<Estoque> Estoque { get; set; }
        public DbSet<Transacao> Transacao { get; set; }
        public DbSet<UnidadeTrabalho> UnidadeTrabalho { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MedControlDbContext).Assembly);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(modelBuilder);
        }

    }
}
