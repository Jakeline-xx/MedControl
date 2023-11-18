using MedControl.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedControl.Data.Mappings
{
    public class EstoqueMap : IEntityTypeConfiguration<Estoque>
    {
        public void Configure(EntityTypeBuilder<Estoque> builder)
        {
            builder.HasKey(e => e.Id);

            // 1 : N => Estoque : Transacoes
            builder.HasMany(e => e.Transacoes)
                .WithOne(t => t.Estoque)
                .HasForeignKey(t => t.IdEstoque);

            builder.ToTable("Estoque");
        }
    }
}
