using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CNDer.Migrations
{
    public partial class AddModelObjETipo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Denuncias");

            migrationBuilder.DropTable(
                name: "Penalidades");

            migrationBuilder.DropTable(
                name: "Processos");

            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "Tipos");

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Tipos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Numero",
                table: "Tipos",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Objetos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServidorId = table.Column<int>(nullable: false),
                    NumeroSei = table.Column<string>(nullable: true),
                    TipoId = table.Column<int>(nullable: false),
                    Penalidade = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true),
                    DataInicio = table.Column<DateTime>(nullable: false),
                    DataFim = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Objetos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Objetos_Servidores_ServidorId",
                        column: x => x.ServidorId,
                        principalTable: "Servidores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Objetos_Tipos_TipoId",
                        column: x => x.TipoId,
                        principalTable: "Tipos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Objetos_ServidorId",
                table: "Objetos",
                column: "ServidorId");

            migrationBuilder.CreateIndex(
                name: "IX_Objetos_TipoId",
                table: "Objetos",
                column: "TipoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Objetos");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Tipos");

            migrationBuilder.DropColumn(
                name: "Numero",
                table: "Tipos");

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "Tipos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Denuncias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnexoId = table.Column<int>(type: "int", nullable: true),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ServidorId = table.Column<int>(type: "int", nullable: false),
                    SetorOrigem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    TextoDenuncia = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroSei = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    TipoId = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "Penalidades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Duracao = table.Column<int>(type: "int", nullable: false),
                    ProcessoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Penalidades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Penalidades_Processos_ProcessoId",
                        column: x => x.ProcessoId,
                        principalTable: "Processos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Denuncias_AnexoId",
                table: "Denuncias",
                column: "AnexoId");

            migrationBuilder.CreateIndex(
                name: "IX_Denuncias_ServidorId",
                table: "Denuncias",
                column: "ServidorId");

            migrationBuilder.CreateIndex(
                name: "IX_Penalidades_ProcessoId",
                table: "Penalidades",
                column: "ProcessoId");

            migrationBuilder.CreateIndex(
                name: "IX_Processos_TipoId",
                table: "Processos",
                column: "TipoId");
        }
    }
}
