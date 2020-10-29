using Microsoft.EntityFrameworkCore.Migrations;

namespace IronFit.Adapter.Migrations
{
    public partial class Ajustes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Academias",
                table: "User",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "QuantidadeDias",
                table: "Pagamento",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdAcademia",
                table: "Modalidade",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Academias", "PasswordHash" },
                values: new object[] { "1,2", "$2a$11$WjExMPSkZyYh7j6OqTllreT0s8RTsyLnvSKbvTHFICDfh5K8emZNK" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Academias", "PasswordHash" },
                values: new object[] { "1,2", "$2a$11$RLh92bMCORQKoW4bnjOzEunGmRxxf9NoCvCI.NO40rQgX2WMWTdUC" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Academias",
                table: "User");

            migrationBuilder.DropColumn(
                name: "QuantidadeDias",
                table: "Pagamento");

            migrationBuilder.DropColumn(
                name: "IdAcademia",
                table: "Modalidade");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$RkvIr.UTqL/NxSqEN7t1FuvBGQqFmpp2nDCB6Z53tPtfRyt7aIeyS");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$11$tAeruA/iFeGwNpzuK/2F/Oj2aLcKP.99gww4DNdQOMWq0iqbFF9Xm");
        }
    }
}
