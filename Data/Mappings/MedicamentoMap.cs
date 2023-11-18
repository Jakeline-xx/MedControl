using MedControl.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedControl.Data.Mappings
{
    public class MedicamentoMap : IEntityTypeConfiguration<Medicamento>
    {
        public void Configure(EntityTypeBuilder<Medicamento> builder)
        {
            builder.HasKey(m => m.Id);

            builder.Property(m => m.Nome)
                   .IsRequired()
                   .HasColumnType("varchar(200)");

            builder.Property(m => m.Descricao)
                   .IsRequired()
                   .HasColumnType("varchar(200)");

            // 1 : 1 => Medicamento : Estoque
            builder.HasOne(m => m.Estoque)
                .WithOne(e => e.Medicamento);

            builder.ToTable("Medicamento");
        }
    }
}
