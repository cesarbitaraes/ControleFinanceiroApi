using ControleFinanceiroApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleFinanceiroApi.Data.Mappings;

public class TiposGastosMap : IEntityTypeConfiguration<TipoGasto>
{
    public void Configure(EntityTypeBuilder<TipoGasto> builder)
    {
        builder.ToTable("TiposGastos");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        builder.Property(x => x.Descricao)
            .IsRequired()
            .HasColumnName("Descricao")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(50);
    }
}