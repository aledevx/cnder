using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CNDer.Migrations
{
    public partial class ModelsRefeitas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Penalidades_Servidores_ServidorId",
                table: "Penalidades");

            migrationBuilder.DropIndex(
                name: "IX_Penalidades_ServidorId",
                table: "Penalidades");

            migrationBuilder.DropColumn(
                name: "DescricaoPenalidade",
                table: "Penalidades");

            migrationBuilder.DropColumn(
                name: "Processo",
                table: "Penalidades");

            migrationBuilder.DropColumn(
                name: "ServidorId",
                table: "Penalidades");

            migrationBuilder.DropColumn(
                name: "Tipo",
                table: "Penalidades");

            migrationBuilder.AddColumn<DateTime>(
                name: "Data",
                table: "Penalidades",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "Penalidades",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProcessoId",
                table: "Penalidades",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Anexos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mime = table.Column<string>(nullable: true),
                    Nome = table.Column<string>(nullable: true),
                    LocalizadorDoAnexo = table.Column<string>(nullable: true),
                    Bytes = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anexos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tipos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Denuncias",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SetorOrigem = table.Column<string>(nullable: true),
                    Data = table.Column<DateTime>(nullable: false),
                    ServidorId = table.Column<int>(nullable: false),
                    TextoDenuncia = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    AnexoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Denuncias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Denuncias_Anexos_AnexoId",
                        column: x => x.AnexoId,
                        principalTable: "Anexos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Denuncias_Servidores_ServidorId",
                        column: x => x.ServidorId,
                        principalTable: "Servidores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Processos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroSei = table.Column<string>(nullable: true),
                    TipoId = table.Column<int>(nullable: false),
                    Data = table.Column<DateTime>(nullable: false),
                    Descricao = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Processos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Processos_Tipos_TipoId",
                        column: x => x.TipoId,
                        principalTable: "Tipos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Penalidades_ProcessoId",
                table: "Penalidades",
                column: "ProcessoId");

            migrationBuilder.CreateIndex(
                name: "IX_Denuncias_AnexoId",
                table: "Denuncias",
                column: "AnexoId");

            migrationBuilder.CreateIndex(
                name: "IX_Denuncias_ServidorId",
                table: "Denuncias",
                column: "ServidorId");

            migrationBuilder.CreateIndex(
                name: "IX_Processos_TipoId",
                table: "Processos",
                column: "TipoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Penalidades_Processos_ProcessoId",
                table: "Penalidades",
                column: "ProcessoId",
                principalTable: "Processos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Penalidades_Processos_ProcessoId",
                table: "Penalidades");

            migrationBuilder.DropTable(
                name: "Denuncias");

            migrationBuilder.DropTable(
                name: "Processos");

            migrationBuilder.DropTable(
                name: "Anexos");

            migrationBuilder.DropTable(
                name: "Tipos");

            migrationBuilder.DropIndex(
                name: "IX_Penalidades_ProcessoId",
                table: "Penalidades");

            migrationBuilder.DropColumn(
                name: "Data",
                table: "Penalidades");

            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "Penalidades");

            migrationBuilder.DropColumn(
                name: "ProcessoId",
                table: "Penalidades");

            migrationBuilder.AddColumn<string>(
                name: "DescricaoPenalidade",
                table: "Penalidades",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Processo",
                table: "Penalidades",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ServidorId",
                table: "Penalidades",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Tipo",
                table: "Penalidades",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Penalidades_ServidorId",
                table: "Penalidades",
                column: "ServidorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Penalidades_Servidores_ServidorId",
                table: "Penalidades",
                column: "ServidorId",
                principalTable: "Servidores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
