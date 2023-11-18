using MedControl.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedControl.Data.Mappings
{
    public class DepartamentoMap : IEntityTypeConfiguration<Departamento>
    {
        public void Configure(EntityTypeBuilder<Departamento> builder)
        {
            builder.HasKey(d => d.Id);

            builder.Property(d => d.Nome)
                   .IsRequired()
                   .HasColumnType("varchar(200)");

            builder.Property(d => d.Descricao)
                   .IsRequired()
                   .HasColumnType("varchar(200)");

            // 1 : N => Departamento : Funcionarios
            builder.HasMany(d => d.Funcionarios)
                .WithOne(f => f.Departamento)
                .HasForeignKey(f => f.IdDepartamento);

            builder.ToTable("Departamento");
        }
    }
}
