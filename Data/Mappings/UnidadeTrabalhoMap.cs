using MedControl.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedControl.Data.Mappings
{
    public class UnidadeTrabalhoMap : IEntityTypeConfiguration<UnidadeTrabalho>
    {
        public void Configure(EntityTypeBuilder<UnidadeTrabalho> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Nome)
                   .IsRequired()
                   .HasColumnType("varchar(200)");

            builder.Property(u => u.Logradouro)
                   .IsRequired()
                   .HasColumnType("varchar(200)");

            // 1 : N => UnidadeTrabalho : Funcionarios
            builder.HasMany(u => u.Funcionarios)
                .WithOne(f => f.UnidadeTrabalho)
                .HasForeignKey(f => f.IdUnidadeTrabalho);

            builder.ToTable("UnidadeTrabalho");
        }
    }
}
