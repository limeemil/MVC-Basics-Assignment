using Microsoft.EntityFrameworkCore.Migrations;

namespace MVC_Basics__Assignment.Migrations
{
    public partial class Addedadminanduserroles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d44c2c18-756a-4b70-8f7f-dbe59788cef0", "aeec39e3-a085-48af-9368-3b927b8cce75", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3faf8ae7-1347-48e2-8dee-d7705c4a6e48", "63611be9-4d66-49d4-8c89-087ea65c9f0c", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3faf8ae7-1347-48e2-8dee-d7705c4a6e48");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d44c2c18-756a-4b70-8f7f-dbe59788cef0");
        }
    }
}
