using Microsoft.EntityFrameworkCore.Migrations;

namespace IronFit.Adapter.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Active", "Admin", "Name", "PasswordHash", "UserName" },
                values: new object[] { 1, true, true, "Gabriel Mazzoco", "$2a$11$RkvIr.UTqL/NxSqEN7t1FuvBGQqFmpp2nDCB6Z53tPtfRyt7aIeyS", "mazzoco" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Active", "Admin", "Name", "PasswordHash", "UserName" },
                values: new object[] { 2, true, true, "Brenner Mazzoco", "$2a$11$tAeruA/iFeGwNpzuK/2F/Oj2aLcKP.99gww4DNdQOMWq0iqbFF9Xm", "brenner" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
