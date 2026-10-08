using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestaoMicroestrutural.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AdicionaRestricoesDeTamanhoBlocoSala : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Topologia");

            migrationBuilder.CreateTable(
                name: "Bloco",
                schema: "Topologia",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Descricao = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bloco", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Insumo",
                schema: "Topologia",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Tipo = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    UnidadeMedida = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    QuantidadeDisponivel = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    EstoqueMinimo = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    TenantId = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Natureza = table.Column<string>(type: "text", nullable: false),
                    Patrimonio = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Descricao = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Insumo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sala",
                schema: "Topologia",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BlocoId = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Tipo = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sala", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sala_Bloco_BlocoId",
                        column: x => x.BlocoId,
                        principalSchema: "Topologia",
                        principalTable: "Bloco",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sala_BlocoId",
                schema: "Topologia",
                table: "Sala",
                column: "BlocoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Insumo",
                schema: "Topologia");

            migrationBuilder.DropTable(
                name: "Sala",
                schema: "Topologia");

            migrationBuilder.DropTable(
                name: "Bloco",
                schema: "Topologia");
        }
    }
}
