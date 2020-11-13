using Microsoft.EntityFrameworkCore.Migrations;

namespace CNDer.Migrations
{
    public partial class AddTabelas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Servidores",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: true),
                    Cpf = table.Column<string>(nullable: true),
                    Matricula = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servidores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Penalidades",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServidorId = table.Column<int>(nullable: false),
                    Processo = table.Column<string>(nullable: true),
                    DescricaoPenalidade = table.Column<string>(nullable: true),
                    Tipo = table.Column<string>(nullable: true),
                    Duracao = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Penalidades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Penalidades_Servidores_ServidorId",
                        column: x => x.ServidorId,
                        principalTable: "Servidores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Penalidades_ServidorId",
                table: "Penalidades",
                column: "ServidorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Penalidades");

            migrationBuilder.DropTable(
                name: "Servidores");
        }
    }
}
