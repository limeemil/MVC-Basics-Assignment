using Microsoft.EntityFrameworkCore.Migrations;

namespace MVC_Basics__Assignment.Migrations
{
    public partial class Resetusertable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "c141f8dd-0ce8-44fc-b767-f5e2dce9f51e", "f932ffef-e502-4507-bc57-275ca0c7e124", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "444c4893-6aa7-4e51-baa8-27427f8740b8", "64a42a00-6d48-4638-9478-0806e5e0174c", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "444c4893-6aa7-4e51-baa8-27427f8740b8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c141f8dd-0ce8-44fc-b767-f5e2dce9f51e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "89a7aec7-049d-4cbe-b996-625d9ec7f4e3", "4b269023-ebd4-4754-9547-87eb75f0641c", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "69505706-e3bd-42b1-9858-83201608f1b2", "6567c9e0-0dc8-4465-89c3-47b9d16b5f33", "User", "USER" });
        }
    }
}
