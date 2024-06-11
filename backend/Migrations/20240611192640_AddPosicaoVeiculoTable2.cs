using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace purrfect_olho_vivo_api.Migrations
{
    /// <inheritdoc />
    public partial class AddPosicaoVeiculoTable2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PosicaoVeiculo",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Latitude = table.Column<long>(type: "bigint", nullable: false),
                    Longitude = table.Column<long>(type: "bigint", nullable: false),
                    VeiculoFkId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PosicaoVeiculo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PosicaoVeiculo_Veiculo_VeiculoFkId",
                        column: x => x.VeiculoFkId,
                        principalTable: "Veiculo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PosicaoVeiculo_VeiculoFkId",
                table: "PosicaoVeiculo",
                column: "VeiculoFkId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PosicaoVeiculo");
        }
    }
}
