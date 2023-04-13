using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleFinanceiroApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTableTiposPagamentos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Vencimento",
                table: "TiposPagamentos");

            migrationBuilder.AddColumn<short>(
                name: "DiaVencimento",
                table: "TiposPagamentos",
                type: "SMALLINT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiaVencimento",
                table: "TiposPagamentos");

            migrationBuilder.AddColumn<DateTime>(
                name: "Vencimento",
                table: "TiposPagamentos",
                type: "DATE",
                nullable: true);
        }
    }
}
