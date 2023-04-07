using ControleFinanceiroApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleFinanceiroApi.Data.Mappings;

public class GastosMap : IEntityTypeConfiguration<Gasto>
{
    public void Configure(EntityTypeBuilder<Gasto> builder)
    {
        builder.ToTable("Gastos");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        builder.Property(x => x.Descricao)
            .IsRequired()
            .HasColumnName("Descricao")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(80);
        
        builder.Property(x => x.Valor)
            .IsRequired()
            .HasColumnName("Valor")
            .HasColumnType("DECIMAL(10,2)");
    }
}