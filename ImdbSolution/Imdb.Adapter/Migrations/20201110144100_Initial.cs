using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IronFit.Adapter.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Modalidade",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Active = table.Column<bool>(nullable: false),
                    Nome = table.Column<string>(maxLength: 200, nullable: false),
                    ValorPadrao = table.Column<decimal>(nullable: false),
                    IdAcademia = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modalidade", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Active = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    UserName = table.Column<string>(maxLength: 50, nullable: false),
                    PasswordHash = table.Column<string>(nullable: false),
                    Admin = table.Column<bool>(nullable: false),
                    Academias = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Aluno",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Active = table.Column<bool>(nullable: false),
                    Nome = table.Column<string>(maxLength: 200, nullable: false),
                    DataNascimento = table.Column<DateTime>(nullable: false),
                    Cpf = table.Column<string>(nullable: true),
                    DataMatricula = table.Column<DateTime>(nullable: false),
                    Ddd = table.Column<string>(maxLength: 2, nullable: true),
                    NumeroTelefone = table.Column<string>(maxLength: 9, nullable: true),
                    Cidade = table.Column<string>(maxLength: 100, nullable: true),
                    Rua = table.Column<string>(maxLength: 300, nullable: true),
                    Numero = table.Column<int>(nullable: true),
                    IdModalidade = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aluno", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Aluno_Modalidade_IdModalidade",
                        column: x => x.IdModalidade,
                        principalTable: "Modalidade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Avaliacao",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Active = table.Column<bool>(nullable: false),
                    Peso = table.Column<decimal>(nullable: false),
                    Altura = table.Column<decimal>(nullable: false),
                    PercentualGordura = table.Column<decimal>(nullable: false),
                    DataAvaliacao = table.Column<DateTime>(nullable: false),
                    IdAluno = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avaliacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Avaliacao_Aluno_IdAluno",
                        column: x => x.IdAluno,
                        principalTable: "Aluno",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pagamento",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Active = table.Column<bool>(nullable: false),
                    DataPagamento = table.Column<DateTime>(nullable: false),
                    Valor = table.Column<decimal>(nullable: false),
                    MesReferencia = table.Column<int>(nullable: false),
                    AnoReferencia = table.Column<int>(nullable: false),
                    QuantidadeDias = table.Column<int>(nullable: false),
                    IdAluno = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pagamento_Aluno_IdAluno",
                        column: x => x.IdAluno,
                        principalTable: "Aluno",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Academias", "Active", "Admin", "Name", "PasswordHash", "UserName" },
                values: new object[] { 1, "1,2", true, true, "Gabriel Mazzoco", "$2a$11$Blz/XOhZmy0HR5P87fm62uqRQD.QK07Z2GyIusLP680Dt3ySH4VHC", "mazzoco" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Academias", "Active", "Admin", "Name", "PasswordHash", "UserName" },
                values: new object[] { 2, "1,2", true, true, "Brenner Mazzoco", "$2a$11$MllzrW5U.yFb8zWQhXbzr.FegtG78OVoc/RFy6MmJEvy7HIhInB.6", "brenner" });

            migrationBuilder.CreateIndex(
                name: "IX_Aluno_IdModalidade",
                table: "Aluno",
                column: "IdModalidade");

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacao_IdAluno",
                table: "Avaliacao",
                column: "IdAluno");

            migrationBuilder.CreateIndex(
                name: "IX_Pagamento_IdAluno",
                table: "Pagamento",
                column: "IdAluno");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Avaliacao");

            migrationBuilder.DropTable(
                name: "Pagamento");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Aluno");

            migrationBuilder.DropTable(
                name: "Modalidade");
        }
    }
}
