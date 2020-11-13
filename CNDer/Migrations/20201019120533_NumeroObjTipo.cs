using Microsoft.EntityFrameworkCore.Migrations;

namespace CNDer.Migrations
{
    public partial class NumeroObjTipo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Numero",
                table: "Tipos");

            migrationBuilder.AddColumn<string>(
                name: "NumeroTipo",
                table: "Objetos",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumeroTipo",
                table: "Objetos");

            migrationBuilder.AddColumn<string>(
                name: "Numero",
                table: "Tipos",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
