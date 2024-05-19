using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace back.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ongs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Cnpj = table.Column<string>(type: "TEXT", maxLength: 18, nullable: false),
                    Endereco = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Telefone = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ongs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tutores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    CpfCnpj = table.Column<string>(type: "TEXT", maxLength: 18, nullable: false),
                    Telefone = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Endereco = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tutores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Servicos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true),
                    OngId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Servicos_Ongs_OngId",
                        column: x => x.OngId,
                        principalTable: "Ongs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Animais",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Tipo = table.Column<string>(type: "TEXT", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Raca = table.Column<string>(type: "TEXT", maxLength: 25, nullable: false),
                    Porte = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Peso = table.Column<float>(type: "REAL", nullable: false),
                    Sexo = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false),
                    Observacao = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true),
                    OngId = table.Column<int>(type: "INTEGER", nullable: false),
                    TutorId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animais", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Animais_Ongs_OngId",
                        column: x => x.OngId,
                        principalTable: "Ongs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Animais_Tutores_TutorId",
                        column: x => x.TutorId,
                        principalTable: "Tutores",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RedeSociais",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Url = table.Column<string>(type: "TEXT", nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    OngId = table.Column<int>(type: "INTEGER", nullable: true),
                    TutorId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RedeSociais", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RedeSociais_Ongs_OngId",
                        column: x => x.OngId,
                        principalTable: "Ongs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RedeSociais_Tutores_TutorId",
                        column: x => x.TutorId,
                        principalTable: "Tutores",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AnimalFotos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Url = table.Column<string>(type: "TEXT", nullable: false),
                    AnimalId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimalFotos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnimalFotos_Animais_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animais_OngId",
                table: "Animais",
                column: "OngId");

            migrationBuilder.CreateIndex(
                name: "IX_Animais_TutorId",
                table: "Animais",
                column: "TutorId");

            migrationBuilder.CreateIndex(
                name: "IX_AnimalFotos_AnimalId",
                table: "AnimalFotos",
                column: "AnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_RedeSociais_OngId",
                table: "RedeSociais",
                column: "OngId");

            migrationBuilder.CreateIndex(
                name: "IX_RedeSociais_TutorId",
                table: "RedeSociais",
                column: "TutorId");

            migrationBuilder.CreateIndex(
                name: "IX_Servicos_OngId",
                table: "Servicos",
                column: "OngId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnimalFotos");

            migrationBuilder.DropTable(
                name: "RedeSociais");

            migrationBuilder.DropTable(
                name: "Servicos");

            migrationBuilder.DropTable(
                name: "Animais");

            migrationBuilder.DropTable(
                name: "Ongs");

            migrationBuilder.DropTable(
                name: "Tutores");
        }
    }
}
