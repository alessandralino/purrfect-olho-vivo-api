using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace purrfect_olho_vivo_api.Migrations
{
    /// <inheritdoc />
    public partial class AddLinhaParadaRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LinhaId",
                table: "Parada",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Parada_LinhaId",
                table: "Parada",
                column: "LinhaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Parada_Linhas_LinhaId",
                table: "Parada",
                column: "LinhaId",
                principalTable: "Linhas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parada_Linhas_LinhaId",
                table: "Parada");

            migrationBuilder.DropIndex(
                name: "IX_Parada_LinhaId",
                table: "Parada");

            migrationBuilder.DropColumn(
                name: "LinhaId",
                table: "Parada");
        }
    }
}
