using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace purrfect_olho_vivo_api.Migrations
{
    /// <inheritdoc />
    public partial class AddLinhaParadaRelationshipFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parada_Linhas_LinhaId",
                table: "Parada");

            migrationBuilder.AlterColumn<int>(
                name: "LinhaId",
                table: "Parada",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Parada_Linhas_LinhaId",
                table: "Parada",
                column: "LinhaId",
                principalTable: "Linhas",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parada_Linhas_LinhaId",
                table: "Parada");

            migrationBuilder.AlterColumn<int>(
                name: "LinhaId",
                table: "Parada",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Parada_Linhas_LinhaId",
                table: "Parada",
                column: "LinhaId",
                principalTable: "Linhas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
