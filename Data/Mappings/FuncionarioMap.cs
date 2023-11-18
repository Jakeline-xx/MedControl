using MedControl.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedControl.Data.Mappings
{
    public class FuncionarioMap : IEntityTypeConfiguration<Funcionario>
    {
        public void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            builder.HasKey(f => f.Id);

            builder.Property(p => p.Nome)
                   .IsRequired()
                   .HasColumnType("varchar(200)");

            builder.Property(p => p.Cargo)
                   .IsRequired()
                   .HasColumnType("varchar(200)");

            builder.Property(p => p.Identificacao)
                   .IsRequired()
                   .HasColumnType("varchar(200)");

            // 1 : N => Transacao : Funcionarios
            builder.HasMany(f => f.Transacoes)
                .WithOne(t => t.Funcionario)
                .HasForeignKey(t => t.IdFuncionario);

            builder.ToTable("Funcionario");
        }
    }
}
