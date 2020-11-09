using Microsoft.EntityFrameworkCore.Migrations;

namespace IronFit.Adapter.Migrations
{
    public partial class InformacoesAluno : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cidade",
                table: "Aluno",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ddd",
                table: "Aluno",
                maxLength: 2,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Numero",
                table: "Aluno",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NumeroTelefone",
                table: "Aluno",
                maxLength: 9,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Rua",
                table: "Aluno",
                maxLength: 300,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$//iwnHrjPahU.1yVYPTKmeyBw.VdyEa.BLTWU6VfDerFlByXkw9d2");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$11$L1Z3PpMH7OlQaM8gCKVBnuEl3ZU/PIqZmwMFAZVgu7Pu0s5rHmr4y");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cidade",
                table: "Aluno");

            migrationBuilder.DropColumn(
                name: "Ddd",
                table: "Aluno");

            migrationBuilder.DropColumn(
                name: "Numero",
                table: "Aluno");

            migrationBuilder.DropColumn(
                name: "NumeroTelefone",
                table: "Aluno");

            migrationBuilder.DropColumn(
                name: "Rua",
                table: "Aluno");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$WjExMPSkZyYh7j6OqTllreT0s8RTsyLnvSKbvTHFICDfh5K8emZNK");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$11$RLh92bMCORQKoW4bnjOzEunGmRxxf9NoCvCI.NO40rQgX2WMWTdUC");
        }
    }
}
