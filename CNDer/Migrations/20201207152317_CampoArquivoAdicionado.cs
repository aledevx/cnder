using Microsoft.EntityFrameworkCore.Migrations;

namespace CNDer.Migrations
{
    public partial class CampoArquivoAdicionado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Arquivo",
                table: "Objetos",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Arquivo",
                table: "Objetos");
        }
    }
}
