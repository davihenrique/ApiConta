using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiConta.Infra.Migrations
{
    /// <inheritdoc />
    public partial class RegraCalculo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "REGRA_CALCULO_CONTA",
                table: "CONTA_DATABASE",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "REGRA_CALCULO_CONTA",
                table: "CONTA_DATABASE");
        }
    }
}
