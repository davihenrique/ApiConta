using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiConta.Infra.Migrations
{
    /// <inheritdoc />
    [ExcludeFromCodeCoverage]
    public partial class AddColumnNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "ID_CONTA",
                table: "CONTA_DATABASE");

            migrationBuilder.RenameColumn(
                name: "ValorOriginal",
                table: "CONTA_DATABASE",
                newName: "VALOR_ORIGINAL_CONTA");

            migrationBuilder.RenameColumn(
                name: "ValorCorrigido",
                table: "CONTA_DATABASE",
                newName: "VALOR_CORRIGIDO_CONTA");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "CONTA_DATABASE",
                newName: "NOME_CONTA");

            migrationBuilder.RenameColumn(
                name: "DiasAtrasados",
                table: "CONTA_DATABASE",
                newName: "DIAS_ATRASADOS_CONTA");

            migrationBuilder.RenameColumn(
                name: "DataVencimento",
                table: "CONTA_DATABASE",
                newName: "DATA_VENCIMENTO_CONTA");

            migrationBuilder.RenameColumn(
                name: "DataPagamento",
                table: "CONTA_DATABASE",
                newName: "DATA_PAGAMENTO_CONTA");

            migrationBuilder.RenameColumn(
                name: "IdConta",
                table: "CONTA_DATABASE",
                newName: "ID_CONTA");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CONTA_DATABASE",
                table: "CONTA_DATABASE",
                column: "ID_CONTA");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CONTA_DATABASE",
                table: "CONTA_DATABASE");

            migrationBuilder.RenameColumn(
                name: "VALOR_ORIGINAL_CONTA",
                table: "CONTA_DATABASE",
                newName: "ValorOriginal");

            migrationBuilder.RenameColumn(
                name: "VALOR_CORRIGIDO_CONTA",
                table: "CONTA_DATABASE",
                newName: "ValorCorrigido");

            migrationBuilder.RenameColumn(
                name: "NOME_CONTA",
                table: "CONTA_DATABASE",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "DIAS_ATRASADOS_CONTA",
                table: "CONTA_DATABASE",
                newName: "DiasAtrasados");

            migrationBuilder.RenameColumn(
                name: "DATA_VENCIMENTO_CONTA",
                table: "CONTA_DATABASE",
                newName: "DataVencimento");

            migrationBuilder.RenameColumn(
                name: "DATA_PAGAMENTO_CONTA",
                table: "CONTA_DATABASE",
                newName: "DataPagamento");

            migrationBuilder.RenameColumn(
                name: "ID_CONTA",
                table: "CONTA_DATABASE",
                newName: "IdConta");

            migrationBuilder.AddPrimaryKey(
                name: "ID_CONTA",
                table: "CONTA_DATABASE",
                column: "IdConta");
        }
    }
}
