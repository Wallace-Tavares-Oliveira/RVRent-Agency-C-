using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RVRentAgencia.Migrations
{
    public partial class RVRenteAgencia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contatos",
                columns: table => new
                {
                    Id_Contato = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mensagem = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contatos", x => x.Id_Contato);
                });

            migrationBuilder.CreateTable(
                name: "Destinos",
                columns: table => new
                {
                    Id_Destino = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Partida = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Retorno = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Destinos", x => x.Id_Destino);
                });

            migrationBuilder.CreateTable(
                name: "Promocoes",
                columns: table => new
                {
                    Id_Promocao = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Preco = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promocoes", x => x.Id_Promocao);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id_Cliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DestinoId_destino = table.Column<int>(type: "int", nullable: false),
                    PromocaoId_promocao = table.Column<int>(type: "int", nullable: false),
                    ContatoId_contato = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id_Cliente);
                    table.ForeignKey(
                        name: "FK_Clientes_Contatos_ContatoId_contato",
                        column: x => x.ContatoId_contato,
                        principalTable: "Contatos",
                        principalColumn: "Id_Contato",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Clientes_Destinos_DestinoId_destino",
                        column: x => x.DestinoId_destino,
                        principalTable: "Destinos",
                        principalColumn: "Id_Destino",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Clientes_Promocoes_PromocaoId_promocao",
                        column: x => x.PromocaoId_promocao,
                        principalTable: "Promocoes",
                        principalColumn: "Id_Promocao",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_ContatoId_contato",
                table: "Clientes",
                column: "ContatoId_contato");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_DestinoId_destino",
                table: "Clientes",
                column: "DestinoId_destino");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_PromocaoId_promocao",
                table: "Clientes",
                column: "PromocaoId_promocao");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Contatos");

            migrationBuilder.DropTable(
                name: "Destinos");

            migrationBuilder.DropTable(
                name: "Promocoes");
        }
    }
}
