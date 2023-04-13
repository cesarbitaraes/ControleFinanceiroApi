﻿// <auto-generated />
using ControleFinanceiroApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ControleFinanceiroApi.Migrations
{
    [DbContext(typeof(ApiDataContext))]
    partial class ApiDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ControleFinanceiroApi.Models.Gasto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Descricao");

                    b.Property<decimal>("Valor")
                        .HasColumnType("DECIMAL(10,2)")
                        .HasColumnName("Valor");

                    b.HasKey("Id");

                    b.ToTable("Gastos", (string)null);
                });

            modelBuilder.Entity("ControleFinanceiroApi.Models.TipoGasto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Descricao");

                    b.HasKey("Id");

                    b.ToTable("TiposGastos", (string)null);
                });

            modelBuilder.Entity("ControleFinanceiroApi.Models.TipoPagamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<short?>("DiaVencimento")
                        .HasColumnType("SMALLINT")
                        .HasColumnName("DiaVencimento");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Nome");

                    b.HasKey("Id");

                    b.ToTable("TiposPagamentos", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
