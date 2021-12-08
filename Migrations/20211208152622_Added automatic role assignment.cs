using Microsoft.EntityFrameworkCore.Migrations;

namespace MVC_Basics__Assignment.Migrations
{
    public partial class Addedautomaticroleassignment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3faf8ae7-1347-48e2-8dee-d7705c4a6e48");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d44c2c18-756a-4b70-8f7f-dbe59788cef0");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "89a7aec7-049d-4cbe-b996-625d9ec7f4e3", "4b269023-ebd4-4754-9547-87eb75f0641c", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "69505706-e3bd-42b1-9858-83201608f1b2", "6567c9e0-0dc8-4465-89c3-47b9d16b5f33", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "69505706-e3bd-42b1-9858-83201608f1b2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "89a7aec7-049d-4cbe-b996-625d9ec7f4e3");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d44c2c18-756a-4b70-8f7f-dbe59788cef0", "aeec39e3-a085-48af-9368-3b927b8cce75", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3faf8ae7-1347-48e2-8dee-d7705c4a6e48", "63611be9-4d66-49d4-8c89-087ea65c9f0c", "User", "USER" });
        }
    }
}
